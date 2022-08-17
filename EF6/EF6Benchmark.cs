using BenchmarkDotNet.Attributes;
using EF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF6
{
    [MediumRunJob]
    [KeepBenchmarkFiles]
    [HtmlExporter]
    [MemoryDiagnoser]
    public class EF6Benchmark
    {
        private readonly EF6Context _context;
        public EF6Benchmark()
        {
            _context = new EF6Context("Server=localhost;Database=Benchmark;Uid=root;Pwd=abc001;");
        }

        [Benchmark]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }


        [Benchmark]
        public User GetFirstUser()
        {
            return _context.Users.FirstOrDefault();
        }

        [Benchmark]
        public void AddUser()
        {
             _context.Users.Add(
                new User
                {
                    UserId = Guid.NewGuid(),
                    Name = "TesteEFCore",
                    Birthday = DateTime.Now
                });

            _context.SaveChangesAsync();
        }

        [Benchmark]
        public void RemoveUser()
        {
            var user = _context.Users.FirstOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        [Benchmark]
        public void AddManyUser()
        {
            var users = new List<User>();

            for (int i = 0; i < 500; i++)
            {
                users.Add(new User
                {
                    UserId = Guid.NewGuid(),
                    Name = "TesteEFCore",
                    Birthday = DateTime.Now
                });
            }

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        [Benchmark]
        public void RemoveAllUser()
        {
            var users = _context.Users.ToList();
            _context.Users.RemoveRange(users);
            _context.SaveChangesAsync();
        }
    }
}
