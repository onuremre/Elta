using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBPlace
{
    private int id;
    private string name;
    private string path;
    private string detail;
    private int status;
    private int locationId;
    private int startingImageId;
    private int categoryId;
    private int contactId;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Path { get => path; set => path = value; }
    public string Detail { get => detail; set => detail = value; }
    public int Status { get => status; set => status = value; }
    public int LocationId { get => locationId; set => locationId = value; }
    public int StartingImageId { get => startingImageId; set => startingImageId = value; }
    public int CategoryId { get => categoryId; set => categoryId = value; }
    public int ContactId { get => contactId; set => contactId = value; }
}

public class DBImage
{
    private int id;
    private string name;
    private string url;
    private int placeId;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Url { get => url; set => url = value; }
    public int PlaceId { get => placeId; set => placeId = value; }
}

public class DBTransition
{
    private int id;
    private int nextImageId;
    private string xCoordinate;
    private string yCoordinate;
    private int imageId;

    public int Id { get => id; set => id = value; }
    public int NextImage { get => nextImageId; set => nextImageId = value; }
    public string XCoordinate { get => xCoordinate; set => xCoordinate = value; }
    public string YCoordinate { get => yCoordinate; set => yCoordinate = value; }
    public int ImageId { get => imageId; set => imageId = value; }
}

public class DBInformation
{
    private int id;
    private string title;
    private string description;
    private string xCoordinate;
    private string yCoordinate;
    private string mediaUrl;
    private int imageId;

    public int Id { get => id; set => id = value; }
    public string Title { get => title; set => title = value; }
    public string Description { get => description; set => description = value; }
    public string XCoordinate { get => xCoordinate; set => xCoordinate = value; }
    public string YCoordinate { get => yCoordinate; set => yCoordinate = value; }
    public string MediaUrl { get => mediaUrl; set => mediaUrl = value; }
    public int ImageId { get => imageId; set => imageId = value; }
}

public class DBLocation
{
    private int id;
    private string country;
    private string state;
    private string city;
    private string zipCode;

    public int Id { get => id; set => id = value; }
    public string Country { get => country; set => country = value; }
    public string State { get => state; set => state = value; }
    public string City { get => city; set => city = value; }
    public string ZipCode { get => zipCode; set => zipCode = value; }
}

public class DBContact
{
    private int id;
    private string name;
    private string surname;
    private string mail;
    private string webSite;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public string Mail { get => mail; set => mail = value; }
    public string WebSite { get => webSite; set => webSite = value; }
}

public class DBCategory
{
    private int id;
    private string name;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
}