﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerClassifier.WPF.Model
{
    public class UserAccountModel
    {
        public string userName {get; set;}
        public string displayName { get; set;}
        public Bitmap profilePicture { get; set;}
        public string cargo { get; set;}
    }
}
