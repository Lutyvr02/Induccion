using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float switchTime = 53;
    public float speed = 2;
    private float distanceToDestroy = 53;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

        InvokeRepeating("SwitchMovement", 0, switchTime);
    }
    
    void SwitchMovement()
    {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }

    private void Update()
    {
        float xcam = Camera.main.transform.position.x;
        float xpipe = this.transform.position.x;
        if (xcam > xpipe+distanceToDestroy)
        {
           Destroy(this.gameObject);
        }
    }
}
