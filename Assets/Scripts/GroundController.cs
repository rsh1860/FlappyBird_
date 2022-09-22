using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }

    private void MoveGround()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
        
        if (transform.localPosition.x < -8.4f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 8.4f, transform.localPosition.y, transform.localPosition.z);

        }    
    
    }
}
