using Domain.Interfaces;
using Domain.Entities;
using DataBase;
using HlynovTestv2;
using System;

namespace Infrastructure.Services
{
    public class LogService : ILogService
    {
        public void Log(string message) 
        {
           using (var context = new AppDbContext())
            {
                var log = new ActionLog
                {
                    Action = message,
                    TimeStamp = DateTime.Now
                };
                context.ActionLog.Add(log);
                context.SaveChanges();
            }
        }
    }
}
