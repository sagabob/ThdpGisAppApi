using System;
using System.Collections.Concurrent;
using System.Linq;
using MediatR;
using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.QuerySvc.Factory
{
    public class QueryRegister
    {
        private static readonly ConcurrentDictionary<SourceType, Type> ProviderRequests =
            new ConcurrentDictionary<SourceType, Type>();

        public QueryRegister()
        {
            ScanAssembliesForClasses(); //set up the dictionary
        }

        public Type Get(SourceType sourceType)
        {
            return ProviderRequests[sourceType];
        }

        public Type GetOrAdd(SourceType sourceType, Type type)
        {
            return ProviderRequests.GetOrAdd(sourceType, type);
        }

        public Type AddOrUpdate(SourceType sourceType, Type type)
        {
            return ProviderRequests.AddOrUpdate(sourceType, type, (key, oldValue) => type);
        }

        public void ScanAssembliesForClasses()
        {
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes()
                    .Where(type => type.IsClass)).ToList()
                .ForEach(type =>
                {
                    type.GetInterfaces()
                        .Where(typeInterface => typeInterface.IsGenericType
                                                && typeInterface.GetGenericTypeDefinition() ==
                                                typeof(IRequest<>).GetGenericTypeDefinition()).ToList()
                        .ForEach(typeInterface =>
                        {
                            var sourceType = type.GetProperty("SourceDbType")?.GetValue(Activator.CreateInstance(type));
                            if (sourceType != null)
                                ProviderRequests.AddOrUpdate((SourceType) sourceType, type, (key, oldValue) => type);
                        });
                });
        }
    }
}