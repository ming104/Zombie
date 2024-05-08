using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameCard : MonoBehaviour
{
    public Text nameText;

    void Start()
    {
        nameText.text = GameDataManager.Instance.LoadGameData().playerName;
    }

    // Update is called once per frame
    void Update()
    {
        nameText.transform.rotation = Camera.main.transform.rotation;
    }
}
