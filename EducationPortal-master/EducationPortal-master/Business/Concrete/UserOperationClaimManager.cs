using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Results.State;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager  : IUserOperationClaimService
    {
        private IUserOperationClaimDal UserOperationClaimDal { get; }

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            UserOperationClaimDal = userOperationClaimDal;
        }

        public IListDataResult<UserOperationClaim> GetUserOperationClaims()
        {
            return new SuccessListDataResult<UserOperationClaim>(UserOperationClaimDal.GetAll());
        }

        public IListDataResult<UserOperationClaimDto> GetByUserClaims(User user)
        {
            return new SuccessListDataResult<UserOperationClaimDto>(UserOperationClaimDal.GetDtoUserOperationClaims(user));
        }

        [SecuredOperation("useroperationclaim.manager")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            UserOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.SuccessAddOperation);
        }

        [SecuredOperation("useroperationclaim.manager")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            UserOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.SuccessDeleteOperation);
        }

        [SecuredOperation("useroperationclaim.manager")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            UserOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.SuccessUpdateOperation);
        }
    }
}
