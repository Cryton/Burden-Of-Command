using UnityEngine;
using System.Collections;

public class S_FPSCont : MonoBehaviour {
	public GameObject barrelTip,lazor;
	public float gunTimer;
	public float gunSpeed;
	public AudioSource audioCont;
	public AudioClip soundFX;
	// Use this for initialization
	void Start () 
	{
	//	audioCont.clip = soundFX;
	}
	
	// Update is called once per frame
	void Update () 
	{
		gunTimer+= Time.deltaTime;
		if(gunTimer > gunSpeed && Input.GetMouseButton(0))
		{
			Shoot();
			gunTimer = 0;
		}
	}
	public void Shoot()
	{
		GameObject lasor = Instantiate(lazor,barrelTip.transform.position,transform.rotation) as GameObject;
		audioCont.Play();
	}
}
