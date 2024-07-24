using BSol.API.DTOs.Auth;
using BSol.API.Models.Requests;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BSol.API.CQRS.Command.Auth
{
    public class RegisterUserCommand : IRequest<NResponse>
    {
        public RegisterUserCommand(RequestRegister request)
        {
            Email = request.Email;
            Mobile = request.Mobile;
            UserType = request.UserType;
            Password = request.Password;
            Proffession = request.Proffession;
            Company = request.Company;
            WorkExperience = request.WorkingExperience;
            CTC = request.CTC;
            UserType = request.UserType;
        }
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Proffession { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string WorkExperience { get; set; } = string.Empty;
        public double CTC { get; set; }
    }
}
