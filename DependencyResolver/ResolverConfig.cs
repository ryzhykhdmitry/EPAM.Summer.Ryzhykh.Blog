using BLL.Interface;
using BLL.Interface.Services;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using Ninject;
using Ninject.Web.Common;
using DAL.Interface.Repository;
using DAL;
using DAL.Concrete;


namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<BlogModel>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<IArticleRepository>().To<ArticleRepository>();            
            kernel.Bind<IUserService>().To<UserService>();//.WithConstructorArgument("path", WebConfigurationManager.AppSettings["Path"]);
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ITagService>().To<TagService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IArticleService>().To<ArticleService>();
           
            //kernel.Bind<IFileService>().To<FileService>().WithConstructorArgument("path", WebConfigurationManager.AppSettings["Path"]);
        }
    }
}
