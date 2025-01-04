using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.up;
    public float bulletSpeed = 30.0f;
    public GameObject mainCamera;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var camera = mainCamera.GetComponent<Camera>();
        var topYOfCamera = mainCamera.transform.position.y + camera.orthographicSize;
        var bottomYOfCamera = mainCamera.transform.position.y - camera.orthographicSize;
        var rightXOfCamera = mainCamera.transform.position.x + camera.orthographicSize * camera.aspect;
        var leftXOfCamera = mainCamera.transform.position.x - camera.orthographicSize * camera.aspect;
        if (transform.position.y > topYOfCamera || transform.position.y < bottomYOfCamera || transform.position.x > rightXOfCamera || transform.position.x < leftXOfCamera)
        {
            Destroy(gameObject);
            return;
        }
        rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y) * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            Debug.Log("Bullet destroyed");
        }
    }
}
