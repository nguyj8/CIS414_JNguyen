using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memento : IMemento
{
    public GameObject player;
    public Rigidbody rb;
    public string state;

    public string GetSaved()
    {
        return "State: " + this.state;
    }

    // Restore from Memento 
    public String RestoreState(IMemento memento)
    {
        state = memento.GetSaved();
        Debug.Log("From Originator: Previously Saved Memento: " + state + "\n");
        return state;
    }
}
