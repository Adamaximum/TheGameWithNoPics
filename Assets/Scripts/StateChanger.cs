using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public Rigidbody2D objRB;
    public SpriteRenderer objSR;

    // Start is called before the first frame update
    void Start()
    {
        objRB = gameObject.GetComponent<Rigidbody2D>();
        objSR = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ShootGreen")
        {
            objRB.gravityScale = 1;
            //objSR.color.a();
        }
    }
}
