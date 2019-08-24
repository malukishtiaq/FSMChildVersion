using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FSMChildVersion.Common.Model.Login
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public UserModel User { get; set; } = new UserModel();
        private LoginResponse(bool success)
        {
            Success = success;
        }
        private LoginResponse(bool success, UserModel model) : this(success)
        {
            Success = success;
            User = model;
        }

        private LoginResponse(bool success, string message, UserModel user) : this(success)
        {
            Message = message;
            User = user;
        }

        public static LoginResponse WithStatus(bool success)
        {
            return new LoginResponse(success);
        }

        public static LoginResponse WithStatusAndMessageAndUser(bool success, string message, UserModel user)
        {
            return new LoginResponse(success, message, user);
        }

        public static LoginResponse WithStatusAndUser(bool success, UserModel user)
        {
            return new LoginResponse(success, user);
        }
    }
}
