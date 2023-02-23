using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Player player;
    private Rigidbody rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var moveDirection = new Vector3(horizontal, 0, vertical).normalized; // ensure adds up to 1 
        transform.Translate((moveDirection * (speed * Time.deltaTime)));

        if (transform.position.y < 0) { Die(); }

        if (Input.GetKeyDown(KeyCode.Space)) { Fire(); }
    }

    public void Die()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }

    public void Fire()
    {
        Debug.Log("Pew");
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = bulletPosition.position;
            bullet.SetActive(true);
        }
    }
}
