using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMemento
{
    // Stores internal state of Originator (Player)
    // Protects against accessibilities upon other objects other than the Originator



    //public Memento(string saveState) { this.state = saveState; }

    public string GetSaved();
}
