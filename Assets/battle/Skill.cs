using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[serializable]
public class Skill
{
    #region Properties

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("caster")]
    public string Caster { get; set; }

    [JsonProperty("effect")]
    public string Effect { get; set; }

    [JsonProperty("position")]
    public string Position { get; set; }

    #endregion
}