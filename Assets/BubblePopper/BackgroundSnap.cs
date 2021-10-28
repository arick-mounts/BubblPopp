using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackgroundSnap : MonoBehaviour
{

    public RectTransform panel;
    public RectTransform[] backgrounds;
    public RectTransform center;

    private float[] distance;
    private bool dragging = false;
    private int backgroundDistance;
    private int closestBackground;

    // Start is called before the first frame update
    void Start()
    {
        distance = new float[backgrounds.Length];

        backgroundDistance = (int)Mathf.Abs(backgrounds[1].anchoredPosition.x - backgrounds[0].anchoredPosition.x);
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<backgrounds.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - backgrounds[i].transform.position.x);
        }


        float minDistance = Mathf.Min(distance);

        //print(Mathf.Min(distance));

        for(int a = 0; a <backgrounds.Length; a++)

        {
            if(minDistance == distance[a])
            {
                closestBackground = a;
            }
        }

        if (!dragging)
        {
            LerpToBackground(closestBackground * -backgroundDistance);
        }
        
    }

    void LerpToBackground(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position,Time.deltaTime * 15f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}
