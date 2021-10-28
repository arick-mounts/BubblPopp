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
    }

    // Update is called once per frame


    void Update()
    {
        if (BubblesCurrent.Count < maxBubbles) {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer  <= 0f)
            {
                spawnBubble();
                spawnTimer = interval;
            }
        }
    }

    public void spawnBubble()
    {
        GameObject bubble = Instantiate(BubblePrefab, this.transform);
        float scale = Random.Range(.15f, .3f);
        bubble.transform.localScale = new Vector3(scale,scale, scale);
        BubbleControl bubbleC = bubble.GetComponent<BubbleControl>();

        bubbleC.spawner = this;
        bubbleC.bearing = Random.Range(0f, 360f);
        bubbleC.speed = Random.Range(.05f, .75f);
        bubbleC.startX = Random.Range(0f, Screen.width);
        bubbleC.startY = Random.Range(0f, Screen.height);
        addBubbleToList( bubble);
    }

    public void addBubbleToList(GameObject bubble) {
        BubblesCurrent.Add(bubble);
    }
    public void removeBubbleFromList(GameObject bubble)
    {
        BubblesCurrent.Remove(bubble);
    }
}

