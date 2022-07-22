using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Models.Users.Requests
{
    public class BaseModel<TD>
    {
        public TD Id { get; set; }
    }

    public class RequestCreateUserModel
    {
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Guid UserTypeId { get; set; }
    }
    public class RequestCreateUserValidator : AbstractValidator<RequestCreateUserModel>
    {
        public RequestCreateUserValidator()
        {
            RuleFor(f => f.FullName).NotEmpty().NotNull().Length(6, 15).WithMessage("asd");
            RuleFor(f => f.UserName).NotEmpty().NotNull().Length(6, 15);
            RuleFor(f => f.Password).NotEmpty().NotNull().Length(6, 15);
            RuleFor(f => f.UserTypeId).NotEmpty().NotNull();
        }
    }
}
