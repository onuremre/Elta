using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public GameObject gameObject;
    fileGUI fileGUI = new fileGUI();
    List<DBTransition> transitions = new List<DBTransition>();
    Database db = new Database();
    DBPlace place = new DBPlace();
    DBImage image = new DBImage();

    void Start()
    {
        showImage(fileGUI.image_id);
    }

    public void showImage(int imageId)
    {
        image = db.showImage(imageId);
        place = db.showPlace(image.PlaceId);
        fileGUI.imageChanger(place.Path + "/" + image.Url, "kure");
        imageTransition(image.Id);
    }

    public void imageTransition(int imageId)
    {
        transitions = db.showTransitions(imageId);
        foreach (DBTransition transition in transitions)
        {
            gameObject.name = transition.NextImage.ToString();
            GameObject.Instantiate(gameObject, new Vector3((float)Convert.ToDecimal(transition.XCoordinate), (float)Convert.ToDecimal(transition.YCoordinate)), Quaternion.identity);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
