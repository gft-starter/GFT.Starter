﻿using System;
using Microsoft.Azure.WebJobs.Description;

namespace GFT.Starter.Function.IoC
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}
