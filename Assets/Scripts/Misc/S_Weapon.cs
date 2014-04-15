using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Weapon : MonoBehaviour {
	public GameObject bullet,targeter;
	public List<GameObject> muzzles;
	public float reloadRate,weaponRange;
	float timer;
	public AudioSource audioCont;
	public bool attack,tank,air;
	public Vector2 pitchR;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer+= Time.deltaTime;
		if(Input.GetKey(0) && timer > reloadRate)
		{
			Shoot();
			timer = 0;
		}
		if(attack && timer > reloadRate)
		{
			Shoot();
			timer = 0;
			attack = false;
		}
	}
	public void Shoot()
	{
		if(!tank)
		{
			foreach(GameObject g in muzzles)
			{
				GameObject aBullet = Instantiate(bullet,g.transform.position,g.transform.rotation) as GameObject;
			}
			audioCont.pitch = Random.Range(pitchR.x,pitchR.y);
			audioCont.Play();
		}
		else
		{
			foreach(GameObject g in muzzles)
			{
				GameObject aBullet = Instantiate(bullet,g.transform.position,g.transform.rotation) as GameObject;
				Physics.IgnoreCollision(aBullet.collider,collider);
			}
			audioCont.pitch = Random.Range(pitchR.x,pitchR.y);
			audioCont.Play();
		}
	}
	public bool CheckSight(GameObject target)
	{
		Debug.DrawRay(targeter.transform.position,targeter.transform.forward*weaponRange);
		Ray r = new Ray(targeter.transform.position,targeter.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(r,out hit,weaponRange))
		{
			if(hit.transform.gameObject == target)
			{
				return true;
			}
		}
		return false;
	}
}
