using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] CareTaker caretaker;

    int savedStates = 0, currentState = 0;

    public void Save(string text)
    {
        player.SetState(text);
        caretaker.Add(player.SaveState());
        savedStates = caretaker.GetCount();
        currentState = savedStates;
    }

    public void Undo()
    {
        if (currentState > 0)
        {
            currentState -= 1; 
        }
        IMemento previous = caretaker.Retrieve();
        string previousState = player.RestoreState(previous);
        Debug.Log(previousState);
    }

    public void Redo()
    {
        if (currentState < savedStates)
        {
            currentState += 1;
        }
        IMemento next = caretaker.Retrieve();
        string nextState = player.RestoreState(next);
        Debug.Log(nextState);
    }
 
}
