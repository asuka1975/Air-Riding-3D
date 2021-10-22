using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedParams : MonoBehaviour
{
    public string Value = null;

    public T Get<T>()
    {
        return JsonUtility.FromJson<T>(Value);
    }

    public void Set<T>(T value)
    {
        Value = JsonUtility.ToJson(value);
    }
}
