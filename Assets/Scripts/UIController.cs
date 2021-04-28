using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject _tapToStartScreen;
    [SerializeField] private GameObject _levelScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;

    void Start()
    {
        _tapToStartScreen.SetActive(true);
        _levelScreen.SetActive(false);
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);
    }

   
    void Update()
    {
        
    }

    public void TapToStartScreenOpen()
    {
        _tapToStartScreen.SetActive(true);
    }

    public void TapToStartScreenClose()
    {
        _tapToStartScreen.SetActive(false);
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
        _loseScreen.SetActive(true);
    }

    public void LoseScreenClose()
    {
        _loseScreen.SetActive(false);
    }

    public void WinScreenOpen()
    {
        _winScreen.SetActive(true);
    }

    public void WinScreenClose()
    {
        _winScreen.SetActive(false);
    }
}
