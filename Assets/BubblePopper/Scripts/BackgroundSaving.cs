using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class BackgroundSaving : MonoBehaviour
{

    private addBackground addBack;
    private string dirPath;
    private int numTextures = 0;

    private void Awake()
    {

        addBack = this.GetComponent<addBackground>();
    }

    // Start is called before the first frame update
    void Start()
    {


        if (!Directory.Exists(Application.persistentDataPath + "/background"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/background");
        }
        dirPath = Application.persistentDataPath + "/background"; ;
        //Debug.Log(dirPath);
        


        DirectoryInfo Dir = new DirectoryInfo(dirPath);
        FileInfo[] fileNames = Dir.GetFiles("*.*");

        foreach (FileInfo i in fileNames) {
            //Debug.Log(i.Name);
            Texture2D tex =  ReadTextureFromFile(dirPath +"/" + i.Name);
            //Debug.Log(tex);
            addBack.DisplayBackground(tex,int.Parse(i.Name));
            numTextures += 1;
        
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture2D ReadTextureFromFile(string path) {
        byte[] bytes = File.ReadAllBytes(path);

        Texture2D tex = new Texture2D(2,2);
        tex.LoadImage(bytes);
        tex.Apply();

        return tex;


    }

    public void SaveTextureToFile(Texture2D texture, int file = -1 ) {
        if (file == -1) {
            file = numTextures;
        }
        string path =  dirPath +  "/" + file;
        //if (!File.Exists(path)) {
        //    File.Create(path);
        // }


        byte[] bytes = texture.EncodeToPNG();

        File.WriteAllBytes(path, bytes);

        numTextures += 1;

        Debug.Log("Written to file");
    }

    public void deleteTextureFile(int file)
    {
        string path = dirPath + "/" + file;
        File.Delete(path);
    }
}
