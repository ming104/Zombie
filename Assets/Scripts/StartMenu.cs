using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject playerDataPanel;

    public InputField playerNameInputField;
    //public Text playerName;

    public Text playerLv;

    public Text bestWave;

    public Text bestScore;
    // Start is called before the first frame update
    void Start()
    {
        playerDataPanel.SetActive(false);
        var gameData = GameDataManager.Instance.LoadGameData();
        playerNameInputField.text = gameData.playerName;
        playerLv.text = $"Player lv : {gameData.level.ToString()}";
        bestWave.text = $"Best Wave : {gameData.BestWave.ToString()}";
        bestScore.text = $"Best Score : {gameData.BestScore.ToString()}";
    }

    public void PlayerDataOn()
    {
        playerDataPanel.SetActive(true);
    }

    public void PlayerDataOff()
    { 
        GameDataManager.Instance.UpdateGameData(playerNameInputField.text);
        GameDataManager.Instance.GD = GameDataManager.Instance.LoadGameData();
        playerDataPanel.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }
}
