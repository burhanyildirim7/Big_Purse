using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyAnimatorController : MonoBehaviour
{

    [SerializeField] private Animator _enemyAnimator;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void EnemyHit1()
    {
        _enemyAnimator.SetBool("Hit1", true);
        _enemyAnimator.SetBool("Hit2", false);
        _enemyAnimator.SetBool("Hit3", false);
    }

    public void EnemyHit2()
    {
        _enemyAnimator.SetBool("Hit2", true);
        _enemyAnimator.SetBool("Hit1", false);
        _enemyAnimator.SetBool("Hit3", false);
    }

    public void EnemyHit3()
    {
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
