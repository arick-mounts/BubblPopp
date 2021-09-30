using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    public GameObject BubblePrefab;
    public List<GameObject> BubblesCurrent;
    public int maxBubbles = 15;

    public float interval = 8;

    public float spawnTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        BubblesCurrent = new List<GameObject>();
        spawnTimer = interval;
        Debug.Log("I'm alive in here");
    }

    // Update is called once per frame
    void Update()
    {
        if (BubblesCurrent.Count < maxBubbles) {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer  <= 0f)
            {
                BubblesCurrent.Add(spawnBubble());
                spawnTimer = interval;
            }
        }
    }

    GameObject spawnBubble()
    {
        GameObject bubble = Instantiate(BubblePrefab, this.transform);
        BubbleMovement bubbleMovement = bubble.GetComponent<BubbleMovement>();
        bubbleMovement.bearing = Random.Range(0f, 360f);
        bubbleMovement.speed = Random.Range(.5f, 2.5f);
        bubbleMovement.startX = Random.Range(0f, Screen.width);
        bubbleMovement.startY = Random.Range(0f, Screen.height);
        return bubble;
    }

    
}

