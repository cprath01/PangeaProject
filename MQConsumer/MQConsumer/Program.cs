using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using RabbitMQConsumerService;
using DAL;
using ReposAPIService;
using Domain.Converters;
using Microsoft.Practices.Unity;
using Domain.Converters.Interfaces;
using RabbitMQConsumerService.Interfaces;
using Domain.DAL.Interfaces;

namespace MQConsumerService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = StartUp();

                var consumer = new RabbitMQConsumer(container);
                HostFactory.Run(x =>
                    {
                        x.Service<RabbitMQConsumer>(s =>
                        {
                            s.ConstructUsing(name => consumer);
                            s.WhenStarted(tc => tc.Start());
                            s.WhenStopped(tc => tc.Stop());
                        });
                        x.RunAsLocalSystem();

                        x.SetDescription("RabbitMQ Consumer service listening to the local queue");
                        x.SetDisplayName("PangeaMQConsumer");
                        x.SetServiceName("PangeaMqConsumer");
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static IUnityContainer StartUp()
        {
            var container = new UnityContainer();
            container.RegisterInstance<IUnityContainer>(container);

            container.RegisterType<IReposAPI, ReposAPI>(new PerThreadLifetimeManager());
            container.RegisterType<IRepoCopyConverter, RepoCopyConverter>(new TransientLifetimeManager());
            container.RegisterType<IRepoConverter, RepoConverter>(new TransientLifetimeManager());
            container.RegisterType<ILoadDataRequestConverter, LoadDataRequestConverter>(new TransientLifetimeManager());
            container.RegisterType<IMessageProcessor, MessageProcessor>(new TransientLifetimeManager());
            container.RegisterType<IMessageProcessorFactory, MessageProcessorFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPangeaRepoDBEntities,PangeaRepoDBEntities>( new TransientLifetimeManager());
            container.RegisterType<IRepoDAL_Save, RepoDAL>(new TransientLifetimeManager());
            container.RegisterType<IMQClientWrapper, RabbitMQClient>(new TransientLifetimeManager());

            
            return container;
        } 
    }
}
