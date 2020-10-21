using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class fileGUI : MonoBehaviour
{
    fileManager fileManager = new fileManager();
    public GameObject obje, go_transition;
    Renderer rend;
    List<DBTransition> transitions = new List<DBTransition>();
    DBPlace place = new DBPlace();
    DBImage image = new DBImage();
    Database db = new Database();
    List<string> item = new List<string>() { "ItemLeft", "ItemMid", "ItemRight" };
    List<int> id = new List<int>();
    List<int> id2 = new List<int>() { 0, 1, 2 };
    string path;
    public static int image_id = 0;
    int k;

    private void Awake()
    {
        //path = Application.dataPath + "/Resources";
        path = Application.persistentDataPath + "/Resources";

        db.createDatabase();
        db.Add("insert into place('name', 'path', 'detail', 'status', 'location_id', 'starting_image_id', 'category_id', 'contact_id') values('İlk Mekan', 'mekan1', 'Deneme Mekanı', 1, 1, 1, 1, 1)");
        db.Add("insert into place('name', 'path', 'detail', 'status', 'location_id', 'starting_image_id', 'category_id', 'contact_id') values('İkinci Mekan', 'mekan2', 'Deneme Mekanı', 1, 1, 2, 1, 1)");
        db.Add("insert into place('name', 'path', 'detail', 'status', 'location_id', 'starting_image_id', 'category_id', 'contact_id') values('Üçüncü Mekan', 'mekan3', 'Deneme Mekanı', 1, 1, 3, 1, 1)");
        db.Add("insert into place('name', 'path', 'detail', 'status', 'location_id', 'starting_image_id', 'category_id', 'contact_id') values('Dördüncü Mekan', 'mekan4', 'Deneme Mekanı', 1, 1, 4, 1, 1)");

        db.Add("insert into image('name','url','place_id') values('İlk Resim','i1',1)");
        db.Add("insert into image('name','url','place_id') values('İlk Resim','i4',2)");
        db.Add("insert into image('name','url','place_id') values('İlk Resim','i3',3)");
        db.Add("insert into image('name','url','place_id') values('İlk Resim','i5',4)");
        db.Add("insert into image('name','url','place_id') values('İkinci Resim','i3',1)");
        db.Add("insert into image('name','url','place_id') values('İkinci Resim','i5',2)");
        db.Add("insert into image('name','url','place_id') values('Üçüncü Resim','i5',1)");
    }
    void Start()
    {
        print("Dosya yöneticisi arayüzü çalıştırılıyor...");
        //path = Application.dataPath + "/Resources";
        path = Application.persistentDataPath + "/Resources";
        //Yeni bir fileManager Instance'si oluştur ve onu çalıştır
        fileManager.Instance.initialize();
        k = db.firstLast(0);
        reload(k);
        
    }

    void OnGUI()
    {
 
    }

    public void imageChanger(string path, string tag)
    {
        obje = GameObject.FindGameObjectWithTag(tag);
        rend = obje.GetComponent<Renderer>();

        rend.material.mainTexture = Resources.Load(path) as Texture;
    }

    public void reload(int i)
    {        
        id = db.showPlacesId(i, 0);
        if(id.Count < 3)
        {
            switch (id.Count)
            {
                case 0:
                    k = db.firstLast(0);
                    id = db.showPlacesId(k, 0);
                    break;
                case 1:
                    foreach (int a in db.showPlacesId(db.firstLast(0), 0))
                    {
                        id.Add(a);
                    }
                    break;
                case 2:
                    foreach (int a in db.showPlacesId(db.firstLast(0), 0))
                    {
                        id.Add(a);
                    }
                    break;
            }

        }

        for(int j = 0; j < 3; j++)
        {
            place = db.showPlace(id[j]);
            image = db.showImage(place.StartingImageId);
            imageChanger(place.Path + "/" + image.Url, item[j]);
            id2[j] = id[j];
        }

    }

    public void reload2(int i)
    {
        id = db.showPlacesId(i, 1);
        if (id.Count < 3)
        {
            switch (id.Count)
            {
                case 0:
                    k = db.firstLast(1);
                    id = db.showPlacesId(k, 1);
                    break;
                case 1:
                    foreach (int a in db.showPlacesId(db.firstLast(1), 1))
                    {
                        id.Add(a);
                    }
                    break;
                case 2:
                    foreach (int a in db.showPlacesId(db.firstLast(1), 1))
                    {
                        id.Add(a);
                    }
                    break;
            }

        }

        for (int j = 0; j < 3; j++)
        {
            place = db.showPlace(id[2-j]);
            image = db.showImage(place.StartingImageId);
            imageChanger(place.Path + "/" + image.Url, item[j]);
            id2[j] = id[2 - j];
        }

    }

    public void next()
    {
        k = id[1];
        reload(k);
    }
    public void prev()
    {
        k = id[1];
        reload2(k);
    }

    public void enterDirectory(GameObject go)
    {
        if (go.name == item[0])
        {
            place = db.showPlace(id2[0]);
        }
        else if (go.name == item[1])
        {
            place = db.showPlace(id2[1]);
        }
        else if (go.name == item[2])
        {
            place = db.showPlace(id2[2]);
        }

        image = db.showImage(place.StartingImageId);
        load(image.Id);
    }

    public void load(int imageId)
    {
        image_id = imageId;
        SceneManager.LoadScene("Scene");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
