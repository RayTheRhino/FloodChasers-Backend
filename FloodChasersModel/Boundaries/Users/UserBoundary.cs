﻿using FloodChasersModel.Commons;
using FloodChasersModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Boundaries.Users
{
    public class UserBoundary
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public ImageData ProfileImage { get; set; }
    }
}
