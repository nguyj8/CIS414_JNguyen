using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : BounceElement
{
    public float speed = 2.5f; 
    private float horizontalInput;
    private float verticalInput;

    public void MoveCunt()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        application.view.player.transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        application.view.player.transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            application.view.player.transform.Translate(0, 1, 0);
        }

        if (application.view.player.transform.position.y < 0)
        {
            application.view.player.enabled = false;
            application.view.player.GetComponent<Rigidbody>().isKinematic = true;
            Die();
        }
        if (application.model.condition >= 3)
        {
            application.view.player.enabled = false;
            application.view.player.GetComponent<Rigidbody>().isKinematic = true;
            GameComplete();
        }
    }

    public void Die()
    {
        GameObject.Find("Player");
        Destroy(this.gameObject);
        Debug.Log("You DIED, you FUCK.");
    }

    public void GameComplete()
    {
        Debug.Log("You WON, CUNT!");
    }

    // Every frame
    public void Update()
    {
        MoveCunt();
    }
}
