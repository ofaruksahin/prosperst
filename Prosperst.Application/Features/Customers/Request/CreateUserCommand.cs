﻿namespace Prosperst.Application.Features.Customers.Request
{
    public class CreateUserCommand : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNo { get; set; }
    }
}