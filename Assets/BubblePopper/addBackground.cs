using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addBackground : MonoBehaviour
{
    private BackgroundSnap bSnap;
    private BackgroundSaving bSave;
    // Start is called before the first frame update

    private void Awake()
    {

        bSnap = this.GetComponent<BackgroundSnap>();
        bSave = this.GetComponent<BackgroundSaving>();
    }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayBackground(Texture2D texture) {

        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        GameObject customBackground = Instantiate(bSnap.prefab, new Vector3(bSnap.panel.transform.position.x, bSnap.panel.transform.position.y, bSnap.panel.transform.position.z), Quaternion.identity);

        RectTransform pos = customBackground.GetComponent<RectTransform>();

        bSnap.backgrounds.Add(pos);
        customBackground.transform.SetParent(bSnap.panel);

        pos.anchorMin = new Vector2(0.5f, 0.5f);
        pos.anchorMax = new Vector2(0.5f, 0.5f);
        pos.anchoredPosition = new Vector3((bSnap.backgrounds.Count - 1) * bSnap.backgroundDistance, 0, 0);
        pos.localScale = new Vector3(1, 1, 1);
        pos.sizeDelta = new Vector2(2000, 2000);


        Image text = customBackground.GetComponent<Image>();
        text.sprite = newSprite;


        bSnap.setDistance();

    }


    public void Background()
    {
        //Debug.Log("addBackground");
        try
        {
            NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
            {
                Texture2D texture = NativeGallery.LoadImageAtPath(path,-1,false);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                DisplayBackground(texture);
                bSave.SaveTextureToFile(texture);
            });

        }
        catch (Exception e) {
            Debug.Log(e.ToString());
        }
    }
}
