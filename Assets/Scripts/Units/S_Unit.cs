using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Unit : MonoBehaviour {
	public bool isSelected,destroyed,enemy;
	public Vector3 target,movePoint;
	public GameObject circle,boom,smoke;
	public List<GameObject> targetList;
	public float health,deathTimer;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	public virtual void Update () 
	{
		if(destroyed)
		{
			deathTimer += Time.deltaTime;
			isSelected = false;
			tag = "Junk";
			
			if(deathTimer > 10)
			{
				Destroy(gameObject);
			}
		}
		else
		{
			if(health < 1)
			{
				destroyed = true;
				boom.SetActive(true);
				smoke.SetActive(true);
			}
			if(isSelected)
			{
				circle.renderer.enabled = true;
			}
			else
			{
				circle.renderer.enabled = false;
			}
			if(targetList.Count != 0)
			{
				Attack();
			}

		}
	}
	public virtual void Move(Vector3 targ)
	{
		AIPath pathing = transform.GetComponent<AIPath>();
		pathing.target = targ;
	}
	public virtual void Attack()
	{
		if(targetList.Count != 0)
		{
			if(targetList[0].tag == "Junk")
			{
				targetList.RemoveAt(0);
			}
			S_Weapon gun = transform.GetComponent<S_Weapon>();
			if(gun.CheckSight(targetList[0]))
			{
				gun.attack = true;
			}
			else
			{
				gun.attack = false;
			}
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if(!enemy)
		{
			if(other.tag == "Enemy")
			{
				targetList.Add(other.gameObject);
			}
		}
		else
		{
			if(other.tag == "PlayerUnit")
			{
				targetList.Add(other.gameObject);
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(!enemy)
		{
			if(other.tag == "Enemy")
			{
				targetList.Remove(other.gameObject);
			}
		}
		else
		{
			if(other.tag == "PlayerUnit")
			{
				targetList.Remove(other.gameObject);
			}
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		if(coll.transform.tag == "Lasor")
		{
			LasorBullet las = coll.transform.GetComponent<LasorBullet>();
			health-= las.damage;
			Destroy(coll.gameObject);
		}
	}

}
