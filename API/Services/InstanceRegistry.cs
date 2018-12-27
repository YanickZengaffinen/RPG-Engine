using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Registry for all singletons... can always use this registry rather than
/// implementing the singleton pattern a hundred times.
/// </summary>
public sealed class InstanceRegistry
{
    private static InstanceRegistry instance;
    public static InstanceRegistry getInstance()
    {
        if( instance == null )
        {
            instance = new InstanceRegistry();
        }

        return instance;
    }

    private Dictionary<Type, System.Object> services = new Dictionary<Type, object>();

    private InstanceRegistry() { }

    /// <summary>
    /// Get the service for a specific type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T getService<T>()
    {
        object returnValue;

        if( !services.TryGetValue(typeof(T), out returnValue ) )
        {
            Debug.LogWarningFormat("Couldn't find service of type {0}", typeof(T));
            return default;
        }

        return (T)returnValue;
    }
}
