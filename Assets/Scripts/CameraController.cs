using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform bird;

    public float offsetX = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowBird();
    }

    private void FollowBird()
    {
        transform.position = new Vector3(bird.position.x + offsetX, transform.position.y, transform.position.z);
    }
}
