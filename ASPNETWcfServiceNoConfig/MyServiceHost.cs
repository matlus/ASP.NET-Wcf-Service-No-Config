using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ASPNETWcfServiceNoConfig
{
    public class MyServiceHost : ServiceHost
    {
        /// <summary>
        /// Max Received Message Size
        /// </summary>
        private static int MaxReceivedMessageSize = 2147483647;

        /// <summary>
        /// Max Buffer Size
        /// </summary>
        private static int MaxBufferSize = 2147483647;

        /// <summary>
        /// Max Buffer Pool Size
        /// </summary>
        private static int MaxBufferPoolSize = 65536;


        public MyServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();
            var mexBehavior = Description.Behaviors.Find<ServiceMetadataBehavior>();

            if (mexBehavior == null)
            {
                mexBehavior = new ServiceMetadataBehavior();
                Description.Behaviors.Add(mexBehavior);
            }

            mexBehavior.HttpGetEnabled = true;
            mexBehavior.HttpsGetEnabled = true;

            var debugBehavior = Description.Behaviors.Find<ServiceDebugBehavior>();
            debugBehavior.IncludeExceptionDetailInFaults = true;

            AddServiceEndpoint(typeof(IMyService), GetBasicHttpBinding(), "");
            ////***************************************************************
            //// If you need to support the HTTPS binding you can uncomment the
            //// line of code below
            //// Also uncomment the method GetBasicHttpsBinding() below
            ////***************************************************************
            ////AddServiceEndpoint(typeof(IMyService), GetBasicHttpsBinding(), "");
        }

        private static BasicHttpBinding GetBasicHttpBinding()
        {
            return new BasicHttpBinding
            {
                MaxReceivedMessageSize = MaxReceivedMessageSize,
                MaxBufferSize = MaxBufferSize,
                MaxBufferPoolSize = MaxBufferPoolSize,
                TransferMode = TransferMode.Buffered,
                BypassProxyOnLocal = false,
                HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                UseDefaultWebProxy = true,
            };
        }


        ////private static BasicHttpsBinding GetBasicHttpsBinding()
        ////{
        ////    var basicHttpsBinding = new BasicHttpsBinding
        ////    {
        ////        MaxReceivedMessageSize = MaxReceivedMessageSize,
        ////        MaxBufferSize = MaxBufferSize,
        ////        MaxBufferPoolSize = MaxBufferPoolSize,
        ////        TransferMode = TransferMode.Buffered,
        ////        BypassProxyOnLocal = false,
        ////        HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
        ////        UseDefaultWebProxy = true,
        ////    };

        ////    basicHttpsBinding.Security.Mode = BasicHttpsSecurityMode.Transport;
        ////    basicHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
        ////    basicHttpsBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

        ////    return basicHttpsBinding;
        ////}

    }
}