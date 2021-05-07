using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraMovement : MonoBehaviour
{
    
    GameObject Enemy;

    Vector3 aradakiFark;

    public static bool _enemyKameraTakip;


    void Start()
    {
        EnemyKameraPozisyonDuzenle();
        aradakiFark = transform.position - Enemy.transform.position;
        _enemyKameraTakip = false;

    }

    public void EnemyKameraPozisyonDuzenle()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        transform.position = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 20, Enemy.transform.position.z - 20);
    }


    void FixedUpdate()
    {
        
        
           // transform.position = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 20, Enemy.transform.position.z - 20);
        
            transform.position = Vector3.Lerp(transform.position, new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + aradakiFark.y, Enemy.transform.position.z + aradakiFark.z), Time.deltaTime * 10f);
        

    }
}
