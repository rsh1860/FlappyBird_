using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    //��ġ ���� �̿��ؼ� ����
    /*
    public static float collectorPosX;
    void Update()
    {
        
        collectorPosX = transform.position.x;
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
