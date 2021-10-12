using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject _tapToStartScreen;
    [SerializeField] private GameObject _levelScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _continueScreen;

    [SerializeField] private Text _levelText;

    private int _levelNumber;

    private int _uiOyunBasladi;

    public bool _isContinue;
    public int _isContinueint;

    /*private void Awake()
    {
        PlayerPrefs.SetInt("Devam",0);
    }*/

    void Start()
    {
        _isContinueint = PlayerPrefs.GetInt("Devam");
        if (_isContinueint==1)
        {
            _isContinue = true;
        }
        else if (_isContinueint==0)
        {
            _isContinue = false;
        }
        else
        {

        }
        //PlayerPrefs.SetInt("LevelNumber", 1);
        if (_isContinue==false)
        {
            _tapToStartScreen.SetActive(true);
            _continueScreen.SetActive(false);
        }
        else
        {
            _tapToStartScreen.SetActive(false);
            _continueScreen.SetActive(true);
        }

        _levelScreen.SetActive(false);
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);

        _uiOyunBasladi = PlayerPrefs.GetInt("UIOyunBasladi");
        if (_uiOyunBasladi == 0)
        {
            PlayerPrefs.SetInt("LevelNumber", 1);
            _uiOyunBasladi = 1;
            PlayerPrefs.SetInt("UIOyunBasladi", _uiOyunBasladi);
        }
        else
        {
            _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        }
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
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
    public void ContinueScreenOpen()
    {
        _tapToStartScreen.SetActive(false);
        _continueScreen.SetActive(true);
    }

    public void ContinueScreenClose()
    {
        _continueScreen.SetActive(false);
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
    public void homeButtonControl()
    {
        _isContinue = false;
        LevelScreenClose();
        TapToStartScreenOpen();

    }

    public void LoseScreenOpen()
    {
        _levelScreen.SetActive(false);
        _loseScreen.SetActive(true);
        AppMetrica.Instance.ReportEvent("level_finish" + _levelNumber);
        AppMetrica.Instance.SendEventsBuffer();

    }

    public void LoseScreenClose()
    {
        _loseScreen.SetActive(false);
        _isContinue = true;
        _continueScreen.SetActive(true);
    }

    public void WinScreenOpen()
    {
        _levelScreen.SetActive(false);
        _winScreen.SetActive(true);
        AppMetrica.Instance.ReportEvent("level_finish" + _levelNumber);
        AppMetrica.Instance.SendEventsBuffer();
    }

    public void WinScreenClose()
    {
        _winScreen.SetActive(false);
        _isContinue = true;
        _continueScreen.SetActive(true);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Devam",0);
    }
}
