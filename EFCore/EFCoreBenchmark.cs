using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore
{
    [MediumRunJob]
    [KeepBenchmarkFiles]
    [HtmlExporter]
    [MemoryDiagnoser]
    public class EFCoreBenchmark
    {
        private readonly EFCoreContext _context;
        private readonly Consumer consumer = new Consumer();
        public EFCoreBenchmark()
        {
            var services = new ServiceCollection();

            //MySql DB
            services.AddDbContextPool<EFCoreContext>(builder =>
            {
                var mySQLConnection = "Server=localhost;Database=Benchmark;Uid=root;Pwd=abc001;";
                builder.UseMySql(mySQLConnection, ServerVersion.AutoDetect(mySQLConnection));
            });

            var serviceProvider = services.BuildServiceProvider();
            _context = serviceProvider.GetService<EFCoreContext>();
        }

        [Benchmark]
        public async Task GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            users.Consume(consumer);
        }

        [Benchmark]
        public async Task<User?> GetFirstUserAsync()
        {
            return await _context.Users.FirstOrDefaultAsync();
        }

        [Benchmark]
        public async Task AddUserAsync()
        {
            await _context.Users.AddAsync(
                new User
                {
                    UserId = Guid.NewGuid(),
                    Name = "TesteEFCore",
                    Birthday = DateTime.Now
                });

            await _context.SaveChangesAsync();
        }

        [Benchmark]
        public async Task RemoveUserAsync()
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        [Benchmark]
        public async Task AddManyUserAsync()
        {
            var users = new List<User>();

            for(int i = 0; i < 500; i++)
            {
                users.Add(new User
                {
                    UserId = Guid.NewGuid(),
                    Name = "TesteEFCore",
                    Birthday = DateTime.Now
                });
            }

            await _context.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        [Benchmark]
        public async Task RemoveAllUserAsync()
        {
            var users = await _context.Users.ToListAsync();
            _context.RemoveRange(users);
            await _context.SaveChangesAsync();
        }

    }
}
