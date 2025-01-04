using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject mainGamera;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        mainGamera = GameObject.Find("Main Camera");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var speedX = Input.GetAxisRaw("Horizontal") * speed;
        var speedY = Input.GetAxisRaw("Vertical") * speed;
        rigidBody.velocity = new Vector2(speedX, speedY);
        mainGamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainGamera.transform.position.z);
    }
}
