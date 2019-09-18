using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBreakScript : MonoBehaviour
{
    float breakSpeed = 0.4f;
    float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = breakSpeed;
        transform.position += new Vector3(horizontalMovement, 0f, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Floor")
        {
            if(gameObject.tag == "ShootBreak")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            if(gameObject.tag == "ShootGreen")
            {
                Destroy(gameObject);

            }
        }
    }
}
