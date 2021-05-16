using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject _tapToStartScreen;
    [SerializeField] private GameObject _levelScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;

    [SerializeField] private TextMeshProUGUI _levelText;

    private int _levelNumber;


    void Start()
    {
        _tapToStartScreen.SetActive(true);
        _levelScreen.SetActive(false);
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);

       //PlayerPrefs.SetInt("LevelNumber", 0);


    }

    public void UILevelNumber()
    {
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _levelNumber++;
        PlayerPrefs.SetInt("LevelNumber", _levelNumber);
    }

   
    void Update()
    {
        _levelText.text = "Level " + _levelNumber;
    }

    public void TapToStartScreenOpen()
    {
        _tapToStartScreen.SetActive(true);
    }

    public void TapToStartScreenClose()
    {
        _tapToStartScreen.SetActive(false);
        _levelScreen.SetActive(true);
    }

    public void LevelScreenOpen()
    {
        _levelScreen.SetActive(true);
    }

    public void LevelScreenClose()
    {
        _levelScreen.SetActive(false);
    }

    public void LoseScreenOpen()
    {
        _levelScreen.SetActive(false);
        _loseScreen.SetActive(true);

    }

    public void LoseScreenClose()
    {
        _loseScreen.SetActive(false);
        _tapToStartScreen.SetActive(true);
    }

    public void WinScreenOpen()
    {
        _levelScreen.SetActive(false);
        _winScreen.SetActive(true);
    }

    public void WinScreenClose()
    {
        _winScreen.SetActive(false);
        _tapToStartScreen.SetActive(true);
    }
}
