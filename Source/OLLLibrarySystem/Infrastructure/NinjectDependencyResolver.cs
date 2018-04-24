using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;
using OLLLibrarySystem.Domain.Concrete;

namespace OLLLibrarySystem.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IEntitiesRepository>().To<EFEntitiesRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);

            //Mock<IEntitiesRepository> mock = new Mock<IEntitiesRepository>();
            //mock.Setup(m => m.Book).Returns(new List<Book>
            //            {
            //                new Book {  BookID = 1, LexileLower = 1, LexileUpper = 3, Location = 1, CheckedOutIn = 1,
            //                            RecAge = 3, Title = "Book One", Author = "My Author", Genre = "Fiction",
            //                            Description = "A book about one", Photo = "image here", ReplacementCost = 2,
            //                            ISBN = 16957852},
            //                new Book {  BookID = 2, LexileLower = 2, LexileUpper = 3, Location = 1, CheckedOutIn = 1,
            //                            RecAge = 3, Title = "Book Two", Author = "My Author", Genre = "Non-Fiction",
            //                            Description = "A book about two", Photo = "image here", ReplacementCost = 2,
            //                            ISBN = 16957850},
            //                new Book {  BookID = 3, LexileLower = 3, LexileUpper = 3, Location = 1, CheckedOutIn = 1,
            //                            RecAge = 3, Title = "Book Three", Author = "My Author", Genre = "Fiction",
            //                            Description = "A book about three", Photo = "image here", ReplacementCost = 2,
            //                            ISBN = 16957848}
            //                });
            //kernel.Bind<IEntitiesRepository>().ToConstant(mock.Object);

        }
    }
}
