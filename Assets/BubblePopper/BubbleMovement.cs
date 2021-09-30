using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public int MovementType = 0;
    public float speed = 1f;
    public float bearing;
    public float startX = 0f;
    public float startY = 0f;

    Vector2 screenPos;
    Vector2 direction = new Vector2(1.5f, 2f);
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Mathf.Cos(bearing), Mathf.Sin(bearing));
        screenPos = new Vector2(startX, startY);
    }

    // Update is called once per frame
    void Update()
    {
        Bounce();
        Movement();
    }

    void Movement()
    {
        screenPos = screenPos + (speed * direction);
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
