using Domain.Interfaces;
using Domain.Entities;
using DataBase;
using System;

namespace Infrastructure.Services
{
    ///<inheritdoc/>
    public class LogService : ILogService
    {
        ///<inheritdoc/>
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
