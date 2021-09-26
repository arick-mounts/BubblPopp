using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    int MovementType = 0;
    Vector2 screenPos = new Vector2(0f, 0f);
    Vector2 direction = new Vector2(1.5f, 2f);
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        Bounce();
        Movement();
    }

    void Movement()
    {
        screenPos = screenPos + direction;
        pos = new Vector3(screenPos.x, screenPos.y, 2);
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    void Bounce()
    {
        
        if(screenPos.x > Screen.width)
        {
            direction.x *= -1;
        }
        if (screenPos.y < 0)
        {
            direction.y *= -1;
        }
        if (screenPos.y > Screen.height)
        {
            direction.y *= -1;
        }
        if (screenPos.x < 0)
        {
            direction.x *= -1;
        }
    }
}
