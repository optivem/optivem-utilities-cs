﻿using AutoMapper;
using Optivem.Core.Application;

namespace Optivem.Infrastructure.AutoMapper
{
    public abstract class ResponseProfile<T, TResponse> : Profile
        where TResponse : IResponse
    {
        public ResponseProfile()
        {
            var map = CreateMap<T, TResponse>();
            Extend(map);
        }

        protected virtual void Extend(IMappingExpression<T, TResponse> map)
        {
            // NOTE: No default implementation
        }
    }
}