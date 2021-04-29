using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IAvatarRepository
    {
        IEnumerable<Avatar> GetAvatars();
        Avatar GetAvatarById(int id);
        void CreateAvatar(Avatar avatar);
        void DeleteAvatar(int avatarId);
        void UpdateAvatar(Avatar avatar);
        void Save();
    }
}
