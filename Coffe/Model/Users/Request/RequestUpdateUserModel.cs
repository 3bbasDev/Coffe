﻿namespace Coffe.Models.Users.Request
{
    public class RequestUpdateUserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserTypeId { get; set; }
    }
}