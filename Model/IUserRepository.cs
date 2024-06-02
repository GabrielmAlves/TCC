using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PlayerClassifier.WPF.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser (NetworkCredential credential);
        bool Add(NetworkCredential credential, string userName, string userEmail, string cargo);
        bool AddProfilePicture(byte[] profileImage, UserAccountModel currentUser, string user);
        bool AddUploadedFile(string path, UserAccountModel currentUser, string user);
        bool EditPassword(NetworkCredential credential);
        string ClassifyPlayer(string filePath);
        void Edit (UserModel userModel);
        void Remove(int id);
        UserModel GetById (int id);
        UserModel GetProfilePicture (string username);
        UserModel GetByUserName (string username);
        UserAccountModel GetUploadedFile(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
