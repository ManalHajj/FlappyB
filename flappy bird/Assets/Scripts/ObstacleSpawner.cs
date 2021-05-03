using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public float minY ;
    public float maxY;
    public float Distance;
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag == "Obstacle")
        {
            Debug.Log("hhha");
            float obstacleY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(transform.position.x + Distance, obstacleY, 0);
            col.gameObject.transform.position = spawnPosition;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
