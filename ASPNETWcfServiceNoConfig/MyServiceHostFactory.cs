﻿using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace ASPNETWcfServiceNoConfig
{
    public class MyServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new MyServiceHost(serviceType, baseAddresses);
        }
    }
}