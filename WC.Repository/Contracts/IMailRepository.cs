using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IMailRepository
    {
        IEnumerable<Mail> GetMails();
        Mail GetMailById(int id);
        void CreateMail(Mail mail);
        void DeleteMail(int mailId);
        void UpdateMail(Mail mail);
        void Save();
    }
}
