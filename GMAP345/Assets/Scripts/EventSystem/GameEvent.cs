using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{

    public List<EventListener> listeners = new List<EventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i>= 0; i--)
        {
            listeners[i].OnRaised();
        }
    }

    public void AddListener(EventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(EventListener listener)
    {
        listeners.Remove(listener);
    }
}
