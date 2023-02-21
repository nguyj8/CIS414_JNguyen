using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CareTaker : MonoBehaviour
{
    // Responsible for the mementos' safekeeping
    // Never operates on or examines the contents of the mementos 
    Stack<IMemento> mementos = new Stack<IMemento>();

    public Stack<IMemento> Memento
    {
        get { return this.mementos; }
        set { this.mementos = value; }
    }

    public void Add(IMemento state)
    {
        Memento.Push(state); 
    }

    public IMemento Retrieve()
    {
        IMemento mem = null;
        if (mementos.ToArray().Length > 0)
        {
            mem = mementos.Pop();
        }
        return mem;
    }

    // Get count of saved states
    public int GetCount()
    {
        return mementos.Count();
    }

    // Player can pass itself in and may search for Memento gameObject
    // Then removes Mementos associated from the list 


    
}
