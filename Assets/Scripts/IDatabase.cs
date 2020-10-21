using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDatabase
{
    DBPlace showPlace(int place_id);

    DBImage showImage(int image_id);

    List<DBImage> showImages(int place_id);
}
