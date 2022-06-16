using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;


/// <summary>
/// The Items Class contain a serial of Item object
/// The properties for Item is loaded from json file using JsonManager Class
/// </summary>
public class Items
{
    #region Fields

    private Dictionary<int, Item> ItemsDict = new Dictionary<int, Item>();
    private string File_Name = "Items.json";

    #endregion

    #region Properties

    public Dictionary<int, Item> Dict
    {
        get { return ItemsDict; }
    }

    #endregion

    #region Constructor

    public Items()
    {
        ItemsDict = GetDictFromList();
    }

    #endregion

    #region Method
    /// <summary>
    /// The GeDictFromJson Deserialize each obeject read from List<Item> by JsonManager Class
    /// and stored it as id,Item pair into a Dictionary
    /// </summary>
    /// <returns> Dictionary of id,Item pair </returns>
    private Dictionary<int, Item> GetDictFromList()
    {
        List<Item> ItemsList = JsonManager.GetListFromJson<Item>(File_Name);
        Dictionary<int, Item> ItemsDict = new Dictionary<int, Item>();
        foreach (Item item in ItemsList)
        {
            ItemsDict.Add(item.Id, item);
        }
        return ItemsDict;
    }

    #endregion
}


/// <summary>
/// The Items Class is used to construct the game item objects
/// </summary>
[Serializable]
public class Item
{

    #region Properties

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("price")]
    public int Price { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("effect")]
    public int[] Effect { get; set; }

    //public Dictionary<int, Item> Dict = GetDict();

    //public Texture icon { get; set; }

    //public var Effect { get; set; }

    #endregion

    #region Constructors

    public Item()
    {
    }
    #endregion
}


