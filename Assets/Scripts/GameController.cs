using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private UIController _uiController;

    [SerializeField] private PlayerController _playerController;

    public static bool _oyunAktif;
    

    void Start()
    {
        _oyunAktif = false;
    }

    
    void Update()
    {
        if (_oyunAktif == false && AnimationControl._yolSonuKontrol == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _uiController.TapToStartScreenClose();
                _uiController.LevelScreenOpen();
                _oyunAktif = true;
                PlayerMovement._playerHareket = true;
                _playerController.PlayerYurume();


            }
            else
            {

            }
        }
        else
        {

        }
    }
}
