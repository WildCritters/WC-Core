using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Context;
using WC.Model;
using WC.Repository.Contracts;

namespace WC.Repository.Implementations
{
    public class MailRepository : IMailRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public MailRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public void CreateMail(Mail mail)
        {
            mail.Active = true;
            mail.DateOfCreation = DateTimeOffset.Now;
            mail.LastUpdate = DateTimeOffset.Now;
            context.Mails.Add(mail);
        }

        public void DeleteMail(int mailId)
        {
            Mail mail = context.Mails.Find(mailId);
            context.Mails.Remove(mail);
        }

        public Mail GetMailById(int id)
        {
            return context.Mails.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Mail> GetMails()
        {
            return context.Mails.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMail(Mail mail)
        {
            mail.LastUpdate = DateTimeOffset.Now;
            context.Entry(mail).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
