using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMenu : MonoBehaviour
{




    public GameObject menu;
    public bool menuBool = false;
    public GameObject[] buttons;


    private addBackground addBack;
    // Start is called before the first frame update

    private void Awake()
    {
        addBack = GetComponent<addBackground>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenu() {
     
        menuBool = !menuBool;
        menu.SetActive(menuBool);
    }

    public void buttonBackgroundAdd(int i) {
        addBack.Background(i);
    }

    public void buttonBackgroundDelete(int i) { 
        addBack.deleteBackground(i);
    }
}
