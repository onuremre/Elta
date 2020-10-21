using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Data;

public class Database : MonoBehaviour, IDatabase
{
    string conn;
    IDbConnection dbconn;

    public void createDatabase()
    {
        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "create table if not exists 'place' ( " +
            "id integer primary key AUTOINCREMENT," +
            "name nvarchar(200) not null," +
            "path nvarchar(300) not null," +
            "detail text," +
            "status integer not null," +
            "location_id integer," +
            "starting_image_id integer not null," +
            "category_id integer not null," +
            "contact_id integer" +
            ");";
        dbcmd.ExecuteNonQuery();

        dbcmd.CommandText = "create table if not exists 'image' ( " +
            "id integer primary key AUTOINCREMENT," +
            "name nvarchar(200) not null," +
            "url nvarchar(300) not null," +
            "place_id integer not null" +
            ");";
        dbcmd.ExecuteNonQuery();

        dbcmd.CommandText = "create table if not exists 'transition' ( " +
            "id integer primary key AUTOINCREMENT," +
            "x_coordinate nvarchar(100) not null," +
            "y_coordinate nvarchar(100) not null," +
            "next_image_id integer not null," +
            "image_id integer not null" +
            ");";
        dbcmd.ExecuteNonQuery();

        dbcmd.CommandText = "create table if not exists 'information' ( " +
            "id integer primary key AUTOINCREMENT," +
            "title nvarchar(200) not null," +
            "description text," +
            "x_coordinate nvarchar(100) not null," +
            "y_coordinate nvarchar(100) not null," +
            "media_url nvarchar(300)," +
            "image_id integer not null" +
            ");";
        dbcmd.ExecuteNonQuery();

        dbcmd.CommandText = "create table if not exists 'location' ( " +
            "id integer primary key autoincrement," +
            "country nvarchar(200) not null," +
            "state nvarchar(200)," +
            "city nvarchar(200)," +
            "zip_code nvarchar(100)" +
            ");";
        dbcmd.ExecuteNonQuery();

        dbcmd.CommandText = "create table if not exists 'contact' ( " +
            "id integer primary key autoincrement," +
            "name nvarchar(200) not null," +
            "surname nvarchar(200)," +
            "mail nvarchar(200)," +
            "web_site nvarchar(300)" +
            ");";
        dbcmd.ExecuteNonQuery();

        dbcmd.CommandText = "create table if not exists 'category' ( " +
            "id integer primary key autoincrement," +
            "name nvarchar(200) not null" +
            ");";
        dbcmd.ExecuteNonQuery();

        print("Veritabanı oluşturuldu");
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public DBPlace showPlace(int place_id)
    {
        DBPlace result = new DBPlace();
        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM place where id = " + place_id;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            result.Id = reader.GetInt32(0);
            result.Name = reader.GetString(1);
            result.Path = reader.GetString(2);
            result.Detail = reader.GetString(3);
            result.Status = reader.GetInt32(4);
            result.LocationId = reader.GetInt32(5);
            result.StartingImageId = reader.GetInt32(6);
            result.CategoryId = reader.GetInt32(7);
            result.ContactId = reader.GetInt32(8);


        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return result;
    }

    public DBPlace showPlace2(int id)
    {
        DBPlace result = new DBPlace();

        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM place where starting_image_id = " + id;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            result.Id = reader.GetInt32(0);
            result.Name = reader.GetString(1);
            result.Path = reader.GetString(2);
            result.Detail = reader.GetString(3);
            result.Status = reader.GetInt32(4);
            result.LocationId = reader.GetInt32(5);
            result.StartingImageId = reader.GetInt32(6);
            result.CategoryId = reader.GetInt32(7);
            result.ContactId = reader.GetInt32(8);


        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return result;
    }

    public DBImage showImage(int image_id)
    {
        DBImage result = new DBImage();

        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM image where id = " + image_id;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            result.Id = reader.GetInt32(0);
            result.Name = reader.GetString(1);
            result.Url = reader.GetString(2);
            result.PlaceId = reader.GetInt32(3);


        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return result;
    }

    public List<DBImage> showImages(int place_id)
    {
        List<DBImage> result = new List<DBImage>();

        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM image,place where place.id = image.place_id and place.id = " + place_id;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            DBImage image = new DBImage();
            image.Id = reader.GetInt32(0);
            image.Name = reader.GetString(1);
            image.Url = reader.GetString(2);
            image.PlaceId = reader.GetInt32(3);

            result.Add(image);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return result;
    }

    public List<int> showPlacesId(int place_id, int mode)
    {
        List<int> result = new List<int>();

        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT id FROM place where id >= " + place_id + " order by id asc limit 3";
        string sqlQuery2 = "SELECT id FROM place where id <= " + place_id + " order by id desc limit 3";

        if (mode == 0)
        {
            dbcmd.CommandText = sqlQuery;
        }
        else
        {
            dbcmd.CommandText = sqlQuery2;
        }
      
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(reader.GetInt32(0));
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return result;
    }

    public List<DBTransition> showTransitions(int image_id)
    {
        List<DBTransition> result = new List<DBTransition>();

        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT transition.id, x_coordinate, y_coordinate, next_image_id, image_id FROM image,transition where image.id = transition.image_id and image_id = " + image_id;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            DBTransition transition = new DBTransition();
            transition.Id = reader.GetInt32(0);
            transition.XCoordinate = reader.GetString(1);
            transition.YCoordinate = reader.GetString(2);
            transition.NextImage = reader.GetInt32(3);
            transition.ImageId = reader.GetInt32(4);

            result.Add(transition);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return result;
    }

    public int firstLast(int flag)
    {
        int result=0;

        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT id FROM place order by id asc limit 1";
        string sqlQuery2 = "SELECT id FROM place order by id desc limit 1";

        if (flag == 0)
        {
            dbcmd.CommandText = sqlQuery;
        }

        else
        {
            dbcmd.CommandText = sqlQuery2;
        }

        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            result = reader.GetInt32(0);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return result;
    }

    public void Add(string sqlQuery)
    {
        //conn = "URI=file:" + Application.dataPath + "/Resources/Elta.db";
        conn = "URI=file:" + Application.persistentDataPath + "/Resources/Elta.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        print("Veritabanı güncellendi");
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

}
