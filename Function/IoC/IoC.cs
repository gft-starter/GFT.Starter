using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace GFT.Starter.Function.IoC
{
    internal static class IoC
    {
        public static readonly ConcurrentDictionary<Guid, IServiceScope> Scopes =
            new ConcurrentDictionary<Guid, IServiceScope>();

        public static IServiceProvider ServiceProvider;
    }
}
