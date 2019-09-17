using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBreakScript : MonoBehaviour
{
    float posX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX++;
        transform.position = new Vector3(posX, 0f, 0f);
    }
}
