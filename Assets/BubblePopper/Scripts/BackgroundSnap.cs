using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackgroundSnap : MonoBehaviour
{

    public RectTransform panel;
    public List<RectTransform> backgrounds;
    public RectTransform center;
    public GameObject prefab;

    public float[] distance;
    private bool dragging = false;
    public int backgroundDistance;
    public int closestBackground;
    public float minDistance;



    // Start is called before the first frame update
    private void Awake()
    {

        setDistance();
        backgroundDistance = (int)Mathf.Abs(backgrounds[1].anchoredPosition.x - backgrounds[0].anchoredPosition.x);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - backgrounds[i].transform.position.x);
        }


        minDistance = Mathf.Min(distance);

        //print(Mathf.Min(distance));

        for(int a = 0; a <backgrounds.Count; a++)

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

    public float calcDist(RectTransform rect) {
        return Mathf.Abs(center.transform.position.x - rect.transform.position.x);

    } 

    public void setDistance() 
    {
        distance = new float[backgrounds.Count];

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


    public void deleteBackground(RectTransform background) {
        if (background != null)
        {
                        
            backgrounds.Remove(background);
            Destroy(background.gameObject);
            setDistance();
            adjustBackgrounds();
        }
    }

    public void adjustBackgrounds()
    {
        int i = 0;
        foreach (RectTransform g in backgrounds)
        {
            if (g.anchoredPosition.x != i * backgroundDistance)
            {
                g.anchoredPosition = new Vector3(i * backgroundDistance, 0, 0);
            }


            i++;
        }

        

    }

}
