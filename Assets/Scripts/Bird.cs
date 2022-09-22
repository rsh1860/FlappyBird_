using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    public float jumpForce = 5f;
    private bool keyJump = false;

    private Vector3 birdRotation;
    public float maxRotation = 30f;
    public float minRotation = -60f;

    //회전속도
    public float upRotate = 5f;
    public float downRotate = -5f;

    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        keyJump |= Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        RotateBird();

        MoveBird();
    }

    private void FixedUpdate()
    {
        if (keyJump)
        {
            JumpBird();
            keyJump = false;
        }
    }

    private void JumpBird()
    {
        rigidbody.velocity = Vector2.up * jumpForce;
    }

    private void RotateBird()
    {
        float degree = 0f;

        if (rigidbody.velocity.y < 0)
        {
            degree = downRotate;
        }
        if (rigidbody.velocity.y > 0)
        {
            degree = upRotate;
        }

        birdRotation = new Vector3(0f, 0f, Mathf.Clamp(birdRotation.z + degree, -90f, 30f));
        transform.eulerAngles = birdRotation;
    }

    private void MoveBird()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
