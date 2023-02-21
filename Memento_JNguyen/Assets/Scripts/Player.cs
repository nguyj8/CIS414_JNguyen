using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Originator:
// Creates a memento containing a snapshot of its internal state
// Uses memento to restore its internal state
public class Player : MonoBehaviour, IMemento
{
    public float speed = 5.0f;
    public float jumpForce = 1.0f;
    public string state;
    public GameObject player;
    public Rigidbody rb;

    public string State
    {
        get { return this.state; }
        set { this.state = value; Debug.Log("State: " + this.state); }
    }

    // First frame that initializes when object spawns
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Every frame updates afterwards
    public void Update()
    {
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        transform.Translate(direction * speed * Time.deltaTime);

        // Player may jump 
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            rb.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
        }
        rb.useGravity = true;
        // Add space condition -> # of jumps maxxed to 1; reset to # as 0 

        if (player.transform.position.y < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Game Over");
        Destroy(player);
    }

    // Buttons? 
    public string SetState(string newState)
    {
        Debug.Log("From Originator: Current Version " + newState);
        return this.state = newState;
    }

    // Store in Memento 
    public IMemento SaveState()
    {
        Debug.Log("From Originator: Saving to Memento");
        //gameObject.AddComponent<Memento>();
        return gameObject.GetComponent<IMemento>();
    }

    // Restore from Memento 
    public String RestoreState(IMemento memento)
    {
        state = memento.GetSaved();
        Debug.Log("From Originator: Previously Saved Memento: " + state + "\n");
        return state;
    }

    // Inheriting from Interace Memento
    public string GetSaved()
    {
        return this.state;
    }
}
