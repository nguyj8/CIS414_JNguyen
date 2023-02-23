using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 2.0f;
    [SerializeField] private Rigidbody rb; 

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { gameObject.SetActive(false); } }
    }
