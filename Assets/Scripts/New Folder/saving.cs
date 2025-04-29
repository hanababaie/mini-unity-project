
using System.Net.Mime;
using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public static class saving
{
    private static string filename = "saved.txt";
    private static string directoryname = "saved";


    public static void savestate(saveobject saved){
        if(!directoryexisting()){
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directoryname);// if the dir doesnt exist we create it
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(getsaavedpath()); // create it    // if we have the file we override it otherwise we create it
            bf.Serialize(file, saved); // we put the saved object it
            file.Close();
        }
    
    
    public static saveobject loading()
    {
        saveobject saved = new saveobject();
        // check if we have a saved file
        if (existingsavedgame()) 
        {
            try // for expections
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(getsaavedpath(), FileMode.Open);
                saved = (saveobject)bf.Deserialize(file);
                file.Close();
            }
            catch (SerializationException)
            {
               Debug.Log("Something went wrong while trying to load the saved game");

            }
        }
        
        return saved;
    }
    private static bool existingsavedgame(){
        return File.Exists(getsaavedpath()); // check if exists
    }
    private static bool directoryexisting(){

        return Directory.Exists(Application.persistentDataPath + "/" + directoryname); // check if directory exists
        
 
    }
    private static string getsaavedpath(){
        return Application.persistentDataPath + "/" + directoryname + "/" + filename;
    }

    
}
