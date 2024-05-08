using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;


[System.Serializable]
public class GameData // 데이터 저장을 위한 클래스
{
    public string playerName; // 플레이어 이름
    public int level;
    public int BestScore; // 최고 점수
    public int BestWave; // 최대 웨이브 
}

public class GameDataManager : Singleton<GameDataManager>
{
    private string FilePath = Application.dataPath + "/gameData.json";

    public GameData GD;
    private void Start()
    {
        FilePath = Application.dataPath + "/gameData.json";
        GD = LoadGameData();
    }

    /// <summary>
    /// 파일이 없을 때 사용되는 메서드
    /// </summary>
    /// <returns>새로운 게임 데이터를 반환해 초기화함 </returns>
    private GameData CreateDefaultGameData()
    {
        GameData newGameData = new GameData();
        newGameData.playerName = "Player1";
        newGameData.level = 0;
        newGameData.BestScore = 0;
        newGameData.BestWave = 0;
        return newGameData;
    }

    /// <summary>
    /// 데이터 저장
    /// </summary>
    /// <param name="gameData">GameData 클래스</param>
    private void SaveData(GameData gameData)
    {
        string jsonData = JsonConvert.SerializeObject(gameData,Formatting.Indented);
        File.WriteAllText(FilePath, jsonData);
    }

    /// <summary>
    /// 데이터 불러옴
    /// </summary>
    /// <returns>GameData 반환함</returns>
    public GameData LoadGameData()
    {
        if (File.Exists(FilePath))
        {
            string jsondata = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<GameData>(jsondata);
        }
        else // 파일이 없음
        {
            GameData gameData = CreateDefaultGameData();
            SaveData(gameData);
            return gameData;
        }
    }
    /// <summary>
    /// 게임 데이터 수정
    /// </summary>
    public void UpdateGameData(string name) {
        GameData loadGameData = LoadGameData();
        loadGameData.playerName = name;
        SaveData(loadGameData);
    }
    public void UpdateGameData(int LV) {
        GameData loadGameData = LoadGameData();
        loadGameData.level += LV;
        SaveData(loadGameData);
    }
    public void UpdateGameData(int curScore, int curWave) {
        GameData loadGameData = LoadGameData();
        if (curScore > loadGameData.BestScore)
        {
            loadGameData.BestScore = curScore;
        }
        if (curWave > loadGameData.BestWave)
        {
            loadGameData.BestWave = curWave;
        }
        SaveData(loadGameData);
        GD = LoadGameData();
    }
}
