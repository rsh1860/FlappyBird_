using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody2D rigidbody;
    private AudioSource audioSource;

    public float jumpForce = 5f;
    private bool keyJump = false;

    private Vector3 birdRotation;
    public float maxRotation = 30f;
    public float minRotation = -60f;

    //회전속도
    public float upRotate = 5f;
    public float downRotate = -5f;

    public float moveSpeed = 2f;

    public float readyForce = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateBird();

        if (gameManager.isBirdDead)
            return;

        InputBird();
        
        if (gameManager.isStart)
        {
            MoveBird();
        }
        else
        {
            //대기
            if (keyJump)
            {
                gameManager.StartPlay();
            }
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.isBirdDead)
            return;

        if (!gameManager.isStart)
        {
            ReadyBird();
        }

        if (keyJump)
        {
            JumpBird();
            keyJump = false;
        }
    }

    private void InputBird()
    {
#if UNITY_EDITOR
        keyJump |= Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
#else
        if (Input.touchCount > 0)
        {
            keyJump = true;
        }
#endif
    }

    private void JumpBird()
    {
        rigidbody.velocity = Vector2.up * jumpForce;
    }

    private void ReadyBird()
    {
        if (rigidbody.transform.position.y < 0f)
        {
            rigidbody.velocity = Vector2.up * readyForce;
        }
        else if (rigidbody.transform.position.y > 0f)
        {
            rigidbody.velocity = Vector2.down * readyForce;
        }
    }

    private void RotateBird()
    {
        if (!gameManager.isStart)
            return;

        if (gameManager.isBirdDead)
        {
            transform.eulerAngles = new Vector3(0f, 0f, -90f);
            return;
        }

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
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
    }

    private void SpeedUp()
    {
        if (gameManager.score % 5 == 0)
            moveSpeed += 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            gameManager.score++;
            audioSource.Play();
            SpeedUp();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Pipe")
        {
            gameManager.isBirdDead = true;
            gameManager.GameOver();
        }
    }

}
