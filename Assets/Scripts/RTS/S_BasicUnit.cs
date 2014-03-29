using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_BasicUnit : MonoBehaviour {
	public bool isSelected,destroyed,enemy,air,tank;
	Vector3 target,movePoint;
	bool moving;
	public GameObject circle,boom,smoke;
	public List<GameObject> targetList;
	public float range,health;
	float deathTimer;
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
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
			if(moving)
			{
				Moving(movePoint);
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
	public void Move(Vector3 point)
	{
		if(!air)
		{
			AIPath pathing = transform.GetComponent<AIPath>();
			pathing.target = point;
		}
		else
		{
			point.y += 55;
			transform.LookAt(point);
			moving = true;
			movePoint = point;
		}
	}
	public void Moving(Vector3 targetPoint)
	{
		if(Vector3.Distance(targetPoint,transform.position) > 5)
		{
			transform.Translate(Vector3.forward*5);
		}
		else
		{
			moving = false;
		}
	}
	public void Attack()
	{
		if(targetList[0].tag == "Junk")
		{
			targetList.RemoveAt(0);
		}
			S_Weapon gun = gameObject.GetComponent<S_Weapon>();
			S_Turret gun2 = gameObject.GetComponent<S_Turret>();
			gun2.target = targetList[0].transform;
			if(gun.CheckSight(targetList[0]))
			{
				gun.attack = true;
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
