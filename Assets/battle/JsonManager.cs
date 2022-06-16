using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;


public class JsonManager
{
    #region Fields
    public static string rootPath = Application.dataPath + @"/data";
    #endregion


    #region Method
    /// <summary>
    /// read data from json file
    /// </summary>
    /// <param name="SuffixPath"> the suffix path that comes after Assests folder </param>
    /// <returns> string read from json file </returns>
    public static string ReadFromFile(string SuffixPath)
    {
        string FullPath = JsonManager.rootPath + @"/" + SuffixPath;

        //Debug.Log(FullPath);
            
        StreamReader reader = null;
        string jsonFromFile = "";
        try
        {
            reader = File.OpenText(FullPath);
            jsonFromFile = reader.ReadToEnd();
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
        }
        return jsonFromFile;
    }

    public static List<T> GetListFromJson<T>(string FileName)
            where T : class
        {
            string jsonFromFile = ReadFromFile(FileName);
            return JsonConvert.DeserializeObject<List<T>>(jsonFromFile);
        }
    
    
    #endregion

}

