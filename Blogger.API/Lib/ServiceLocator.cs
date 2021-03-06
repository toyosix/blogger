﻿using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Blogger.API.Lib
{
    public class ServiceLocator : IServiceLocator
    {
        // a map between contracts -> concrete implementation classes
        private IDictionary<Type, Type> servicesType;
        private static readonly object TheLock = new Object();
        private static IServiceLocator instance;

        // a map containing references to concrete implementation already instantiated
        // (the service locator uses lazy instantiation).
        private IDictionary<Type, object> instantiatedServices;

        private ServiceLocator()
        {
            this.servicesType = new Dictionary<Type, Type>();
            this.instantiatedServices = new Dictionary<Type, object>();
        }

        public static IServiceLocator Instance
        {
            get
            {
                lock (TheLock) // thread safety
                {
                    if (instance == null)
                    {
                        instance = new ServiceLocator();
                    }
                }

                return instance;
            }
        }

        

        public T GetService<T>(BloggerContext dbcontext)
        {
            if (this.instantiatedServices.ContainsKey(typeof(T)))
            {
                return (T)this.instantiatedServices[typeof(T)];
            }
            else
            {
                // lazy initialization
                try
                {
                    // use reflection to invoke the service
                    Type[] types = new Type[1];
                    types[0] = typeof(BloggerContext); // add the parameter type into an array

                    ConstructorInfo constructor = servicesType[typeof(T)].GetConstructor(types);
                    Debug.Assert(constructor != null, "Cannot find a suitable constructor for " + typeof(T));

                    T service = (T)constructor.Invoke(new object[] { dbcontext });

                    // add the service to the ones that we have already instantiated

                    instantiatedServices.Add(typeof(T), service);

                    return service;
                }
                catch (KeyNotFoundException ex)
                {
                    throw new ApplicationException("The requested service is not registered" + ex);
                }
            }
        }

        public void Register<I, C>()
        {
            servicesType.Add(typeof(I), typeof(C));
        }

    }
}
