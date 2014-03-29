using UnityEngine;
using System.Collections;

public class S_Weapon : MonoBehaviour {
	public GameObject bullet,muzzle;
	public float reloadRate,weaponRange;
	float timer;
	public AudioSource audioCont;
	public bool attack,tank,air;

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
			GameObject aBullet = Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation) as GameObject;
			audioCont.Play();
		}
		else
		{
			GameObject aBullet = Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation) as GameObject;
			Physics.IgnoreCollision(aBullet.collider,collider);
			audioCont.Play();
		}
	}
	public bool CheckSight(GameObject target)
	{
		Debug.DrawRay(muzzle.transform.position,muzzle.transform.forward*weaponRange);
		Ray r = new Ray(muzzle.transform.position,muzzle.transform.forward);
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
