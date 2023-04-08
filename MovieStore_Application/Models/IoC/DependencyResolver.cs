using Autofac;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using MovieStore_Application.Mapping;
using MovieStore_Application.Services.AppUserServices;
using MovieStore_Application.Services.CategoryServices;
using MovieStore_Application.Services.DirectorServices;
using MovieStore_Application.Services.LanguageServices;
using MovieStore_Application.Services.MovieServices;
using MovieStore_Application.Services.StarringServices;
using MovieStore_Domain.Repository;
using MovieStore_Infrastructure.Reporsitories;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            
            builder.RegisterType<DirectorService>().As<IDirectorService>().InstancePerLifetimeScope();
            builder.RegisterType<DirectorRepository>().As<IDirectorRepository>().InstancePerLifetimeScope();

            builder.RegisterType<LanguageRepository>().As<ILanguageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();

            builder.RegisterType<MovieService>().As<IMovieService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();

            builder.RegisterType<StarringRepository>().As<IStarringRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StarringService>().As<IStarringService>().InstancePerLifetimeScope();

            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();


            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<MappingProfile>(); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
            }
            )).AsSelf().SingleInstance();



            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
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
