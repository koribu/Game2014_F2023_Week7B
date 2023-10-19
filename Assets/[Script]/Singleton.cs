using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public abstract class Singleton<T> where T : Singleton<T>
{
  protected Singleton() { }

    public static T Instance { get; } = Create();

    private static T Create()
    {
        Type t = typeof(T);
        var flags = BindingFlags.Instance | BindingFlags.NonPublic;
        var constructor = t.GetConstructor(flags, null, Type.EmptyTypes, null);
        var instance =constructor.Invoke(null);

        return Instance;
    }
}
