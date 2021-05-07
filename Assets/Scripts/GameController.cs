using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private UIController _uiController;

    private PlayerController _playerController;

    private AnimationControl _animationControl;

    [SerializeField] private LevelController _levelController;

    [SerializeField] private EnemyCameraMovement _enemyCameraMovement;

    [SerializeField] private DusmanControl _dusmanControl;

    public static bool _oyunAktif;

    private GameObject Enemy;

    [SerializeField] private GameObject _enemyCamera;
    

    void Start()
    {
        _oyunAktif = false;
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _animationControl = GameObject.FindWithTag("Player").GetComponent<AnimationControl>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
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
                _animationControl.DusmanGuncelle();
                _levelController.DusmanYenile();
                _enemyCameraMovement.EnemyKameraPozisyonDuzenle();
                _dusmanControl.EnemyYenile();
                EnemyCameraMovement._enemyKameraTakip = false;
                _enemyCamera.transform.position = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 20, Enemy.transform.position.z - 20);


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
