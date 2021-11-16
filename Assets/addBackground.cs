using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addBackground : MonoBehaviour
{
    public BackgroundSnap bs;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Background()
    {
        Debug.Log("addBackground");
        try
        {
            NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
            {
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                GameObject customBackground = Instantiate(bs.prefab, new Vector3(bs.panel.transform.position.x, bs.panel.transform.position.y, bs.panel.transform.position.z), Quaternion.identity);

                RectTransform pos = customBackground.GetComponent<RectTransform>();

                bs.backgrounds.Add(pos);
                customBackground.transform.SetParent(bs.panel);

                pos.anchorMin = new Vector2(0.5f, 0.5f);
                pos.anchorMax = new Vector2(0.5f, 0.5f);
                pos.anchoredPosition = new Vector3((bs.backgrounds.Count - 1) * bs.backgroundDistance, 0, 0);
                pos.localScale = new Vector3(1, 1, 1);
                pos.sizeDelta = new Vector2(2000, 2000);


                Image text = customBackground.GetComponent<Image>();
                text.sprite = newSprite;


                bs.setDistance();
            });


        }
        catch (Exception e) { 
            
        }
    }
}
