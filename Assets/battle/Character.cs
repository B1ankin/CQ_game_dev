using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

/// <summary>
/// The characterData class is like a dictionary that store all the data of the character.
/// </summary>
[Serializable]
public class CharacterData
{
    #region Properties

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("sanity")]
    public string Sanity { get; set; }

    [JsonProperty("attack_wendou")]
    public int Attack_wendou { get; set; }

    [JsonProperty("attack_wudou")]
    public string Attack_wudou { get; set; }

    [JsonProperty("accuracy")]
    public int Accuracy { get; set; }

    [JsonProperty("resis_physic")]
    public int Resis_physic { get; set; }

    [JsonProperty("resis_wendou")]
    public int Resis_wendou { get; set; }

    [JsonProperty("resis_fire")]
    public int Resis_fire { get; set; }

    [JsonProperty("resis_poison")]
    public int Resis_poison { get; set; }

    [JsonProperty("resis_bleed")]
    public int Resis_bleed { get; set; }

    [JsonProperty("resis_stun")]
    public int Resis_stun { get; set; }

    [JsonProperty("skills")]
    public List<Skill> skills { get; set; }

    [JsonProperty("items")]
    public List<Item> items { get; set; }

    // [JsonProperty("equipments")]
    // public List<Equipment> equipments;

    #endregion

    #region Constructor
    public CharacterData()
    {

    }

    #endregion

}

public class characterCollection
{
    #region Fields

    private Dictionary<int, CharacterData> characterCollectionDict = new Dictionary<int, CharacterData>();
    private string File_Name = "Characters.json";

    #endregion

    #region Properties

    public Dictionary<int, CharacterData> Dict
    {
        get
        {
            return characterCollectionDict;
        }
    }

    #endregion


    #region constructor

    public characterCollection()
    {
        characterCollectionDict = GetDictFromList();
    }

    #endregion

    #region Methods

    /// <summary>
    /// The GeDictFromJson Deserialize each obeject read from List<CharacterData> by JsonManager Class
    /// and stored it as id,Item pair into a Dictionary
    /// </summary>
    /// <returns> Dictionary of id,Item pair </returns>
    private Dictionary<int, CharacterData> GetDictFromList()
    {
        List<CharacterData> CharacterDatasList = JsonManager.GetListFromJson<CharacterData>(File_Name);
        Dictionary<int, CharacterData> characterDict = new Dictionary<int, CharacterData>();
        foreach (var character in CharacterDatasList)
        {
            characterDict.Add(character.Id, character);
            //Debug.Log(""+ character.Id + ":::" + character.Name);
        }
        return characterDict;
    }
    #endregion
}