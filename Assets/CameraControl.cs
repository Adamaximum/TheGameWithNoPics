using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTR;
    public float cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerTR = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTR.position.x+cameraOffset, 0, transform.position.z);
    }
}
