﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.DependencyInjection.Core.Application;
using Optivem.Framework.DependencyInjection.Core.Domain;
using Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper;
using Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.DependencyInjection.Infrastructure.FluentValidation;
using Optivem.Framework.DependencyInjection.Infrastructure.MediatR;
using Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Optivem.Template.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var coreModuleTypes = new List<Type>
            {
                typeof(Core.Application.Module),
                typeof(Core.Domain.Module),
            };

            var infrastructureModuleTypes = new List<Type>
            {
                typeof(Infrastructure.AutoMapper.Module),
                typeof(Infrastructure.EntityFrameworkCore.Module),
                typeof(Infrastructure.FluentValidation.Module),
                typeof(Infrastructure.MediatR.Module),
            };

            var moduleTypes = new List<Type>();
            moduleTypes.AddRange(coreModuleTypes);
            moduleTypes.AddRange(infrastructureModuleTypes);

            var assemblies = moduleTypes.Select(e => e.Assembly).ToArray();

            // var assemblies = null;

            // Core
            services.AddApplicationCore(assemblies);
            services.AddDomainCore(assemblies);

            // Infrastructure
            var connectionKey = ConfigurationKeys.DatabaseConnectionKey;
            var connection = configuration.GetConnectionString(connectionKey);
            services.AddEntityFrameworkCoreInfrastructure<DatabaseContext>(options => options.UseSqlServer(connection), assemblies);
            services.AddAutoMapperInfrastructure(assemblies);
            services.AddFluentValidationInfrastructure(assemblies);
            services.AddMediatRInfrastructure(assemblies);
            services.AddNewtonsoftJsonInfrastructure(assemblies);
        }
    }
}