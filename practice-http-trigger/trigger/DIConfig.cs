using Autofac;
using AzureFunctions.Autofac.Configuration;

namespace Practice.Http.Trigger
{
    public class DIConfig
    {
        public DIConfig(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                //Implicity registration
                builder.RegisterType<TwilioService>().As<ITwilioService>();
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
}