using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
	public Animator playerAnimator;
	int hitType = 0;

	private bool _yolSonuKontrol;


    private void Start()
    {
		_yolSonuKontrol = false;

	}
    private void Update()
	{
		if (Input.GetMouseButton(0) && _yolSonuKontrol == true)
		{
			HitAnim();
		}
	}

	public void HitAnim()
	{
		if(hitType == 0)
		{
			hitType = Random.Range(1, 4);
			Debug.Log(hitType);
			if (hitType== 1) playerAnimator.SetTrigger("bir");
			else if (hitType == 2) playerAnimator.SetTrigger("iki");
			else playerAnimator.SetTrigger("uc");
			StartCoroutine(DelayHitType());
		}
		
	}

    

    public void JumpAnim()
	{
		playerAnimator.SetTrigger("zipla");
	}

	IEnumerator DelayHitType()
	{
		yield return new WaitForSeconds(.4f);
		hitType = 0;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "YolSonu")
        {
			Debug.Log("YolSonu");
			PlayerMovement._oyunAktif = false;
			JumpAnim();
			_yolSonuKontrol = true;
		}
    }
}
