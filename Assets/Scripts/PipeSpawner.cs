using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject pipePrefab;

    public float maxY = 2.5f;
    public float minY = -1.5f;

    private float countdown = 0.5f;
    private float spawnMinTime = 2f;
    private float spawnMaxTime = 4f;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isBirdDead)
            return;

        if (!gameManager.isStart)
            return;

        if (countdown <= 0)
        {
            Spawn();
            countdown = Random.Range(spawnMinTime, spawnMaxTime);
        }
        countdown -= Time.deltaTime;
    }

    private void Spawn()
    {
        float posY = transform.position.y + Random.Range(minY, maxY);
        Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);
        
        GameObject p = Instantiate(pipePrefab, pos, Quaternion.identity);
    }

}
