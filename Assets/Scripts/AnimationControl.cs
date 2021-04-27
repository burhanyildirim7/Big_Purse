using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
	//public Animator playerAnimator;
	int hitType = 0;
	[SerializeField] private GameObject _purse;

	[SerializeField] private DusmanControl _dusmanControl;

	public static bool _dusmaniFirlat;

	private bool _yolSonuKontrol;

	private Vector3 _purseBoyutu;

	private float _purseBoyutX;


    private void Start()
    {
		_yolSonuKontrol = false;
		_dusmaniFirlat = false;

	}
    private void Update()
	{
		if (Input.GetMouseButtonDown(0) && _yolSonuKontrol == true)
		{
			HitAnim();
			
		}

		_purseBoyutX = _purse.gameObject.transform.localScale.x;
	}
	
	public void HitAnim()
	{
		if(hitType == 0 && _dusmaniFirlat == false)
		{

            if (_purseBoyutX <= 0.32f)
            {
				_dusmaniFirlat = true;
				_purse.gameObject.transform.localScale = new Vector3(0.32f, 0.32f, 0.32f);
				_dusmanControl.DusamaniFirlatma();

			}
			
			hitType = Random.Range(1, 4);
			Debug.Log(hitType);
			//if (hitType== 1) playerAnimator.SetTrigger("bir");
			//else if (hitType == 2) playerAnimator.SetTrigger("iki");
			//else playerAnimator.SetTrigger("uc");
			_purse.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
			_purse.gameObject.transform.localPosition -= new Vector3(0, 0.01f, 0);
			StartCoroutine(DelayHitType());
		}
		
	}
	

	/*
    public void JumpAnim()
	{
		playerAnimator.SetTrigger("zipla");
	}
	*/
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
			//JumpAnim();
			_yolSonuKontrol = true;
		}
    }
}
