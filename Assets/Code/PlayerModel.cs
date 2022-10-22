using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private static PlayerModel _Instance = new PlayerModel();

    public static PlayerModel Instance { get => _Instance; set => _Instance = value; }

    //KungfuEnableList
    public Dictionary<string, bool> KungfuEnableList;

    PlayerModel()
    {
        //KungfuEnableList
        KungfuEnableList = new Dictionary<string, bool>();
        KungfuEnableList.Add("Kick", true);
        KungfuEnableList.Add("DiveKick", false);
    }
}
