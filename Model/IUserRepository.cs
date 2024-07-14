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
        bool AddUploadedFiles(string path1, string path2, string user);
        bool AddPlayerOnHold(string playerInfos);
        bool EditPassword(NetworkCredential credential);
        string ClassifyPlayer(string filePath);
        string ComparePlayers(string jsonPaths);
        void Edit (UserModel userModel);
        void Remove(int id);
        UserModel GetById (int id);
        bool GetPlayerInfo(string playerName);
        UserModel GetProfilePicture (string username);
        UserModel GetByUserName (string username);
        UserAccountModel GetUploadedFile(string username);
        UserAccountModel GetUploadedFiles(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
