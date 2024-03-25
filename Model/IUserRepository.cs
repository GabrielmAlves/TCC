﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlayerClassifier.WPF.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser (NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit (UserModel userModel);
        void Remove(int id);
        UserModel GetById (int id);
        UserModel GetByEmail (string email);
        IEnumerable<UserModel> GetByAll();
    }
}
