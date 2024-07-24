using BSol.API.DTOs.Auth;
using BSol.API.Models.Auth;
using BSol.API.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace BSol.API.Services.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<UserOne> _userOneManager;
        private readonly UserManager<UserTwo> _userTwoManager;
        private readonly UserManager<UserThree> _userThreeManager;
        private readonly UserManager<UserFour> _userFourManager;

        public AuthServices(
            UserManager<UserOne> userOneManager, UserManager<UserTwo> userTwoManager,
            UserManager<UserThree> userThreeManager, UserManager<UserFour> userFourManager
            )
        {
            _userOneManager = userOneManager;
            _userTwoManager = userTwoManager;
            _userThreeManager = userThreeManager;
            _userFourManager = userFourManager;
        }

        // REGISTER USER ONE- FOUR
        public async Task<NResponse> RegisterAsync(RequestRegister request)
        {
            if(request != null)
            {
                if (request.UserType == "One") return await RegisterUserOneAsync(request);
                else if (request.UserType == "Two") return await RegisterUserTwoAsync(request);
                else if (request.UserType == "Three") return await RegisterUserThreeAsync(request);
            }
            return new NResponse
            {
                Code = 0,
                Message = "Null Request"
            };
        }

        private async Task<NResponse> RegisterUserOneAsync(RequestRegister request)
        {
            var userExist = await CheckUserExists(request.Email);
            if (userExist == true)
            {
                return new NResponse
                {
                    Code = 0,
                    Message = $"{request.Email} already exists"
                };
            }

            UserOne user = new()
            {
                UserName = request.Email,
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = request.Mobile,
                UserType = request.UserType,
                Company = request.Company,
                WorkExperience = request.WorkingExperience,
                CTC = request.CTC,
                Proffession = request.Proffession,
            };
            var createUserResult = await _userOneManager.CreateAsync(user, request.Password);
            if (!createUserResult.Succeeded)
            {
                return new NResponse
                {
                    Code = 0,
                    Message = $"Failed to register user, Error => {createUserResult.Errors.First().Description}"
                };
            }

            // ASSIGN ROLE
            //var roleResult = await _userOneManager.AddToRoleAsync(user, request.UserType);
            //if (!roleResult.Succeeded)
            //{
            //    return new NResponse
            //    {
            //        Code = 0,
            //        Message = $"Failed to register user, Error => {roleResult.Errors.First().Description}"
            //    };
            //}

            return new NResponse
            {
                Code = 1,
                Message = "Registered Successfully"
            };
        }

        private async Task<NResponse> RegisterUserTwoAsync(RequestRegister request)
        {
            var userExist = await CheckUserExists(request.Email);
            if (userExist == true)
            {
                return new NResponse
                {
                    Code = 0,
                    Message = $"{request.Email} already exists"
                };
            }

            UserTwo user = new()
            {
                UserName = request.Email,
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = request.Mobile,
                UserType = request.UserType,
                Company = request.Company,
                WorkExperience = request.WorkingExperience,
                CTC = request.CTC,
                Proffession = request.Proffession,
            };
            var createUserResult = await _userTwoManager.CreateAsync(user, request.Password);
            if (!createUserResult.Succeeded)
            {
                return new NResponse
                {
                    Code = 0,
                    Message = $"Failed to register user, Error => {createUserResult.Errors.First().Description}"
                };
            }

            // ASSIGN ROLE
            //var roleResult = await _userOneManager.AddToRoleAsync(user, request.UserType);
            //if (!roleResult.Succeeded)
            //{
            //    return new NResponse
            //    {
            //        Code = 0,
            //        Message = $"Failed to register user, Error => {roleResult.Errors.First().Description}"
            //    };
            //}

            return new NResponse
            {
                Code = 1,
                Message = "Registered Successfully"
            };
        }

        private async Task<NResponse> RegisterUserThreeAsync(RequestRegister request)
        {
            var userExist = await CheckUserExists(request.Email);
            if (userExist == true)
            {
                return new NResponse
                {
                    Code = 0,
                    Message = $"{request.Email} already exists"
                };
            }

            UserThree user = new()
            {
                UserName = request.Email,
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = request.Mobile,
                UserType = request.UserType,
                Company = request.Company,
                WorkExperience = request.WorkingExperience,
                CTC = request.CTC,
                Proffession = request.Proffession,
            };
            var createUserResult = await _userThreeManager.CreateAsync(user, request.Password);
            if (!createUserResult.Succeeded)
            {
                return new NResponse
                {
                    Code = 0,
                    Message = $"Failed to register user, Error => {createUserResult.Errors.First().Description}"
                };
            }

            // ASSIGN ROLE
            //var roleResult = await _userOneManager.AddToRoleAsync(user, request.UserType);
            //if (!roleResult.Succeeded)
            //{
            //    return new NResponse
            //    {
            //        Code = 0,
            //        Message = $"Failed to register user, Error => {roleResult.Errors.First().Description}"
            //    };
            //}

            return new NResponse
            {
                Code = 1,
                Message = "Registered Successfully"
            };
        }

        //private async Task<NResponse> RegisterUserFourAsync(RequestRegister request)
        //{
        //    var userExist = await _userFourManager.FindByEmailAsync(request.Email);
              //var userExist = await CheckUserExists(request.Email);
        //    if (userExist == true)
        //    {
        //        return new NResponse
        //        {
        //            Code = 0,
        //            Message = $"{request.Email} already exists"
        //        };
        //    }

        //    UserFour user = new()
        //    {
        //        UserName = request.Email,
        //        Email = request.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        PhoneNumber = request.Mobile,
        //        UserType = request.UserType,
        //        Company = request.Company,
        //        WorkExperience = request.WorkingExperience,
        //        CTC = request.CTC,
        //        Proffession = request.Proffession,
        //    };
        //    var createUserResult = await _userFourManager.CreateAsync(user, request.Password);
        //    if (!createUserResult.Succeeded)
        //    {
        //        return new NResponse
        //        {
        //            Code = 0,
        //            Message = $"Failed to register user, Error => {createUserResult.Errors.First().Description}"
        //        };
        //    }

        //    // ASSIGN ROLE
        //    //var roleResult = await _userOneManager.AddToRoleAsync(user, request.UserType);
        //    //if (!roleResult.Succeeded)
        //    //{
        //    //    return new NResponse
        //    //    {
        //    //        Code = 0,
        //    //        Message = $"Failed to register user, Error => {roleResult.Errors.First().Description}"
        //    //    };
        //    //}

        //    return new NResponse
        //    {
        //        Code = 1,
        //        Message = "Registered Successfully"
        //    };
        //}


        private async Task<bool> CheckUserExists(string email)
        {
            var inOne = await _userOneManager.FindByEmailAsync(email);
            if(inOne != null)
            {
                return true;
            }
            var inTwo = await _userTwoManager.FindByEmailAsync(email);   
            if(inTwo != null)
            {
                return true;
            }
            var inThree = await _userThreeManager.FindByEmailAsync (email);
            if(inThree != null)
            {
                return true;
            }
            return false;
        }


    }
}
