using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyAnimatorController : MonoBehaviour
{

    [SerializeField] private Animator _enemyAnimator;

   
    public void EnemyHit1()
    {
        Debug.Log("Hit1");
        _enemyAnimator.SetBool("Hit1", true);
        _enemyAnimator.SetBool("Hit2", false);
        _enemyAnimator.SetBool("Hit3", false);
    }

    public void EnemyHit2()
    {
        Debug.Log("Hit2");
        _enemyAnimator.SetBool("Hit2", true);
        _enemyAnimator.SetBool("Hit1", false);
        _enemyAnimator.SetBool("Hit3", false);
    }

    public void EnemyHit3()
    {
        Debug.Log("Hit3");
        _enemyAnimator.SetBool("Hit3", true);
        _enemyAnimator.SetBool("Hit1", false);
        _enemyAnimator.SetBool("Hit2", false);
    }

    
    public void EnemyHitleriKapat()
    {
        _enemyAnimator.SetBool("Hit1", false);
        _enemyAnimator.SetBool("Hit2", false);
        _enemyAnimator.SetBool("Hit3", false);
    }
    
}
