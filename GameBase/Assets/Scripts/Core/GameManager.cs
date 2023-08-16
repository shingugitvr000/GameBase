using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;
using static Define;

public class GameManager
{
    public GameData _gameData = new GameData();

    string _path;
    public void Init()
    {
        _path = Application.persistentDataPath + "/SaveData.json";

        Debug.Log("Save Path : " + _path);

        //if(LoadGame())
        //      return;

        PlayerPrefs.SetInt("ISFIRST", 1);
    }

    public int UserLevel
    {
        get { return _gameData.UserLevel;}
        set { _gameData.UserLevel = value;}
    }

    public string UserName
    {
        get { return _gameData.UserName;}
        set { _gameData.UserName = value; }
    }

    public event Action OnResourcesChanged;

    public int Gold
    {
        get { return _gameData.Gold;}
        set 
        { 
            _gameData.Gold = value;
            SaveGame();
            OnResourcesChanged?.Invoke();
        }
    }

    public int Dia
    {
        get { return _gameData.Dia; }
        set
        {
            _gameData.Dia = value;
            SaveGame();
            OnResourcesChanged?.Invoke();
        }
    }

    public void SaveGame()
    {
        //GameData Class 를 json 으로 변환하여 저장 
        string jsonStr = JsonConvert.SerializeObject(_gameData);
        File.WriteAllText(_path, jsonStr);
    }

}
