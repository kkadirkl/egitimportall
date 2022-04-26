using Business.Abstract;
using Core.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Rules;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT.Abstract;
using Core.Utilities.Security.JWT.Models;
using Entities.Dtos;
using Results.State;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IUserService UserService { get; }
        private ITokenHelper TokenHelper { get; }
        public AuthenticationManager(IUserService userService, ITokenHelper tokenHelper)
        {
            UserService = userService;
            TokenHelper = tokenHelper;
        }

        public IDataResult<AuthenticatedDto> Login(UserForLoginDto userForLoginDto)
        {
            var checkUser = CheckUser(userForLoginDto.Email);
            if (checkUser.Status == false)
            {
                return new ErrorDataResult<AuthenticatedDto>(checkUser.Message);
            }
            var createAccessToken = this.CreateAccessToken(checkUser.SingleData);
            var authenticatedDto = new AuthenticatedDto()
            {
                Expiration = createAccessToken.Data.Expiration,
                Token = createAccessToken.Data.Token,
                UserEmail = checkUser.SingleData.Email,
                UserFirstName = checkUser.SingleData.FirstName,
                UserLastName = checkUser.SingleData.LastName
            };

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,checkUser.SingleData.PasswordHash,checkUser.SingleData.PasswordSalt))
            {
                return new ErrorDataResult<AuthenticatedDto>(authenticatedDto,"Hatalı şifre");
            }

            return new SuccessDataResult<AuthenticatedDto>(authenticatedDto,Messages.SuccessLoginOperation);
        }

        public IDataResult<AuthenticatedDto> Register(UserForRegisterDto userForRegisterDto)
        {
            var checkUser = CheckUser(userForRegisterDto.Email);
            if (checkUser.Status == true)
            {
                return new ErrorDataResult<AuthenticatedDto>(checkUser.Message);
            }

            var hashingHelper = HashingHelper.CreatePasswordHash(userForRegisterDto.Password);

            User newUser = new User()
            {
                //Email = checkUser.SingleData.Email,
                //FirstName = checkUser.SingleData.FirstName,
                //LastName = checkUser.SingleData.LastName,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                IsApproved = true,
                PasswordHash = hashingHelper.Hash,
                PasswordSalt = hashingHelper.Salt
            };

            UserService.Add(newUser);

            var createAccessToken = this.CreateAccessToken(newUser);

            var authenticatedDto = new AuthenticatedDto()
            {
                Expiration = createAccessToken.Data.Expiration,
                Token = createAccessToken.Data.Token,
                //UserEmail = checkUser.SingleData.Email,
                //UserFirstName = checkUser.SingleData.FirstName,
                //UserLastName = checkUser.SingleData.LastName
                UserEmail = newUser.Email,
                UserFirstName = newUser.FirstName,
                UserLastName = newUser.LastName
            };

            return new SuccessDataResult<AuthenticatedDto>(authenticatedDto,Messages.SuccessRegisterOperation);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationCliams = new List<OperationClaim>();

            var userOperationClaimsDto = UserService.GetClaims(user);     
            
            foreach (var userOperationClaimDto in userOperationClaimsDto.ListData)
            {
                operationCliams.Add(
                        new OperationClaim() 
                        {
                            Id = userOperationClaimDto.OperationClaimId,
                            Name = userOperationClaimDto.OperationClaimName,
                            IsApproved = userOperationClaimDto.OperationClaimIsApproved 
                        }
                    );
            }

            var accessToken = TokenHelper.CreateToken(user, operationCliams);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.CreatedAccessToken);
        }

        private ISingleDataResult<User> CheckUser(string email)
        {
            var result = UserService.GetByUserEmail(email);
            if (result.SingleData == null)
            {
                return new ErrorSingleDataResult<User>(result.SingleData,Messages.UserNotFound);
            }
            return new SuccessSingleDataResult<User>(result.SingleData,Messages.UserFound);
        }
    }
}
