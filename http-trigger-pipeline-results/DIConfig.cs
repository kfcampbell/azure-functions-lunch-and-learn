using Autofac;
using AzureFunctions.Autofac.Configuration;

namespace HttpTrigger.Pipeline.Results
{
    public class DIConfig
    {
        public DIConfig(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                //Implicity registration
                builder.RegisterType<ServiceOne>().As<IServiceOne>();
                //Explicit registration
                //builder.Register<Example>(c => new Example(c.Resolve<ISample>())).As<IExample>();
                //Registration by autofac module
                //builder.RegisterModule(new TestModule());
                //Named Instances are supported
                //builder.RegisterType<Thing1>().Named<IThing>("OptionA");
                //builder.RegisterType<Thing2>().Named<IThing>("OptionB");
            }, functionName);
        }
    } 

    public class ServiceOne : IServiceOne
    {
        public string Execute()
        {
            return "This is a result of an injection";
        }
    }

    public interface IServiceOne { string Execute(); }
}