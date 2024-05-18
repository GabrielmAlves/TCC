using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerClassifier.WPF.Model
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserJob { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string UploadedFile { get; set; }
    }
}
