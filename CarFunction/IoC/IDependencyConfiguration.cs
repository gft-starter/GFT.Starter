using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarFunction.IoC
{
    public interface IDependencyConfiguration
    {
        /// <summary>
        /// Creates an instance of an <see cref="IServiceProvider"/>.
        /// </summary>
        /// <returns></returns>
        void RegisterServices(IServiceCollection collection);
    }
}
