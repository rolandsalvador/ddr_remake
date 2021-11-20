using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }

    public InputField characterNameInput;
    public Dropdown characterColorInput;

    public string characterName;
    public string characterColor;

    void Start()
    {
        characterNameInput.onValueChanged.AddListener(characterNameCallback);
        characterColorInput.onValueChanged.AddListener(delegate { characterColorCallback(characterColorInput); });
    }

    #region

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    void characterNameCallback(string charName)
    {
        characterName = (string)charName;
    }

    void characterColorCallback(Dropdown target)
    {
        characterColor = target.captionText.text;
    }
}
