﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Xunit
{
    /// <summary>
    /// Provides a data source for a data theory, with the data coming from a class
    /// which must implement IEnumerable&lt;object[]&gt;.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ClassDataAttribute : DataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassDataAttribute"/> class.
        /// </summary>
        /// <param name="class">The class that provides the data.</param>
        public ClassDataAttribute(Type @class)
        {
            Class = @class;
        }

        /// <summary>
        /// Gets the type of the class that provides the data.
        /// </summary>
        public Type Class { get; private set; }

        /// <inheritdoc/>
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return (IEnumerable<object[]>)Activator.CreateInstance(Class);
        }
    }
}
