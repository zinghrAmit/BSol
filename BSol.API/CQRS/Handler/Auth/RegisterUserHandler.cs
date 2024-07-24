using BSol.API.CQRS.Command.Auth;
using BSol.API.DTOs.Auth;
using BSol.API.Models.Requests;
using BSol.API.Services.Auth;
using MediatR;

namespace BSol.API.CQRS.Handler.Auth
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, NResponse>
    {
        private readonly IAuthServices _services;
        public RegisterUserHandler(IAuthServices services)
        {
            _services = services;
        }

        public async Task<NResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            RequestRegister commandDto = new()
            {
                Email = request.Email,
                Mobile = request.Mobile,
                UserType = request.UserType,
                Password = request.Password,
                Proffession = request.Proffession,
                Company = request.Company,
                CTC = request.CTC,
                WorkingExperience = request.WorkExperience
            };
            return await _services.RegisterAsync(commandDto);
        }
    }
}
