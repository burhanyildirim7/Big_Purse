using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float _eksiXSinirlandirma = -4f;
    [SerializeField] private float _artiXSinirlandirma = 4f;
    //[SerializeField] private float maxSwerveAmount = 1f;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        if (GameController._oyunAktif == true && PlayerMovement._playerHareket == true && PlayerMovement._playerMerdivende == false)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            //swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);

            if (transform.position.x < _eksiXSinirlandirma)
            {
                transform.position = new Vector3(_eksiXSinirlandirma, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > _artiXSinirlandirma)
            {
                transform.position = new Vector3(_artiXSinirlandirma, transform.position.y, transform.position.z);
            }
        }

        if (PlayerMovement._playerMerdivende == true)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);

        }
        
       
    }
}
