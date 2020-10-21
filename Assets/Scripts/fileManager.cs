using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class fileManager : MonoBehaviour
{
    private static fileManager instance;//fileManager class'ının bir kopyası
    private string path;//uygulamaya giden yol
    fileGUI fileGUI;
    Database db;
    DBPlace place;
    List<DBImage> images;
    DBImage dbImage;
    public string a;
    public List<int> id = new List<int>();

    public static fileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("fileManager").AddComponent<fileManager>() as fileManager;
            }

            return instance;
        }
    }

    //uygulamadan çıkılırken çağrılır
    public void OnApplicationQuit()
    {
        destroyInstance();
    }

    //fileManager Instance'ını yok etmeye yarar
    public void destroyInstance()
    {
        print("Instance yok edildi");
        instance = null;
    }

    public void initialize()
    {
        fileGUI = new fileGUI();
        db = new Database();
        print("Dosya yöneticisi çalıştırıldı");
        //path = Application.dataPath + "/Resources";
        path = Application.persistentDataPath;
        Debug.Log("Path: " + path);
        createDirectory(path + "/Resources");
        path = Application.persistentDataPath + "/Resources";
    }

    private bool checkDirectory(string directory)
    {
        //Directory.Exists() fonksiyonu klasörün varlığını kontrol eder
        if (Directory.Exists(path + "/" + directory))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void createDirectory(string directory)
    {
        if (!checkDirectory(directory))
        {
            print("Klasör oluşturuluyor: " + directory);
            //Yeni dizin oluşturma fonksiyonu
            Directory.CreateDirectory(path + "/" + directory);
        }
        else
        {
            print("Hata: Zaten mevcut olan " + directory + " klasörünü tekrar oluşturmaya çalışıyorsunuz");
        }
    }

    private void deleteDirectory(string directory)
    {
        if (checkDirectory(directory))
        {
            print("Klasör siliniyor: " + directory);
            //Dizin silme fonksiyonu; ilk parametre yol, ikinci parametre bool değer(alt dizinler de silinecekse true)
            Directory.Delete(path + "/" + directory, true);
        }
        else
        {
            print("Hata: Var olmayan " + directory + " klasörünü silmeye çalışıyorsunuz");
        }
    }

    private void moveDirectory(string originalDestination, string newDestination)
    {
        if (checkDirectory(originalDestination) && !checkDirectory(newDestination))
        {
            print("Klasör taşınıyor: " + originalDestination);
            //Dizin taşıma fonksiyonu. İki değişken alıyor; ilk değişken eski konum, ikinci değişken yeni konum
            Directory.Move(path + "/" + originalDestination, path + "/" + newDestination);
        }
        else
        {
            print("Hata: Ya varolmayan bir klasörü taşımaya çalışıyorsunuz ya da hedef noktada aynı klasör zaten mevcut");
        }
    }

    public string[] findSubDirectories(string directory)
    {
        if (checkDirectory(directory))
        {
            print(directory + " klasörünün alt klasörlerine bakılıyor");
            //Alt dizinleri bulan fonksiyon. Parametre olarak dizin alır. İstenirse ikinci parametre olarak arama kriteri yazılabilir.
            return Directory.GetDirectories(path + "/" + directory);
        }
        else
        {
            print(directory + " klasörünün alt klasörü yok");
            return new string[0];
        }
    }

    public bool checkFile(string filePath)
    {
        if (File.Exists(path + "/" + filePath))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void createFile(string directory, string fileName, string fileType, string fileData)
    {
        if (checkDirectory(directory))
        {
            if (!checkFile(directory + "/" + fileName + "." + fileType))
            {
                //Dosyayı oluştur
                File.WriteAllText(path + "/" + directory + "/" + fileName + "." + fileType, fileData);
                print(fileName + "." + fileType + " dosyası oluşturuldu");
            }
            else
            {
                print(fileName + " dosyası " + path + "/" + directory + " konumunda zaten var");
            }
        }
        else
        {
            print(directory + " konumu var olmadığından dosya oluşturulamıyor");
        }
    }

    public string readFile(string directory, string fileName, string fileType)
    {
        if (checkDirectory(directory))
        {
            if (checkFile(directory + "/" + fileName + "." + fileType))
            {
                //Dosyayı oku
                return File.ReadAllText(path + "/" + directory + "/" + fileName + "." + fileType);
            }
            else
            {
                print(path + "/" + directory + " konumunda" + fileName + " adlı dosya bulunamadı");
                return null;
            }
        }
        else
        {
            print(directory + " konumu var olmadığından dosya okunamıyor");
            return null;
        }
    }

    public void deleteFile(string filePath)
    {
        if (checkFile(filePath))
        {
            File.Delete(path + "/" + filePath);
            print("Dosya silindi");
        }
        else
        {
            print("Dosya bulunamadığı için işlem başarısız");
        }
    }

    public void updateFile(string directory, string fileName, string fileType, string fileData, string mode)
    {
        print("Güncelleniyor: " + directory + "/" + fileName + "." + fileType);

        if (checkDirectory(directory))
        {
            if (checkFile(directory + "/" + fileName + "." + fileType))
            {
                if (mode == "replace")
                {
                    File.WriteAllText(path + "/" + directory + "/" + fileName + "." + fileType, fileData);
                    print("Dosya güncellendi");
                }
                else if (mode == "append")
                {
                    File.AppendAllText(path + "/" + directory + "/" + fileName + "." + fileType, fileData);
                    print("Dosya güncellendi");
                }
                else
                {
                    print(path + "/" + directory + " konumunda " + fileName + " diye bir dosya yok");
                }
            }
            else
            {
                print(directory + " konumu var olmadığından dosya güncellenemiyor");
            }
        }
    }

    //dosya açma penceresinde seçilmiş bir dosyayı okur
    public void processFile(string filePath)
    {
        print("Dosya İşleniyor: " + filePath);
        string fileContents = File.ReadAllText(filePath);
        print("Dosyanın içeriği: " + fileContents);
    }

    public void createDatabase()
    {
        createFile("", "Elta", "s3db", "");
        db.Add("create database Elta");
        db.Add("create table place(id integer primary key AUTOINCREMENT,name nvarchar(200) not null,path nvarchar(300) not null,detail text,status integer not null,location_id integer,starting_image_id integer not null,category_id integer not null,contact_id integer)");
        db.Add("insert into place(name,path,detail,status,location_id,starting_image_id,category_id,contact_id) values('aa','aa','aa',1,100,100,100,100)");
    }
}