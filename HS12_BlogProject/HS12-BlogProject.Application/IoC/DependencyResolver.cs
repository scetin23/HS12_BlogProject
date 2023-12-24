using Autofac;
using AutoMapper;
using HS12_BlogProject.Application.AutoMapper;
using HS12_BlogProject.Application.Services.AppUserService;
using HS12_BlogProject.Application.Services.AuthorService;
using HS12_BlogProject.Application.Services.GenreService;
using HS12_BlogProject.Application.Services.PostService;
using HS12_BlogProject.Domain.Repositories;
using HS12_BlogProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.IoC 
{

    // Nuget: autofac.extensions.dependencyInjection 
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();

            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
           
            builder.RegisterType<GenreService>().As<IGenreService>().InstancePerLifetimeScope();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerLifetimeScope();

            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();

            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>(); 
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {

                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion


            base.Load(builder);
        }
    }
}
