using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    string[] piece;
    fileGUI fileGUI = new fileGUI();
    Database db = new Database();
    DBImage image = new DBImage();
    public GameObject transition;
    public void changer(GameObject gameObject)
    {
        piece = gameObject.name.Split('(');
        image = db.showImage(Convert.ToInt32(piece[0]));
        print(image.Id);
        fileGUI.load(image.Id);
    }
}
