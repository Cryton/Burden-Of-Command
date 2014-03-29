using UnityEngine;
using System.Collections;

public class LasorBullet : MonoBehaviour {
	public float life,damage,speed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward*speed);
		life++;
		if(life > 300)
		{
			Destroy(gameObject);
		}
	}
//	void OnCollisionEnter(Collision coll)
//	{
//
//			if(coll.transform.tag == "Enemy" || coll.transform.tag == "PlayerUnit")
//			{
//				S_BasicUnit unit = coll.transform.GetComponent<S_BasicUnit>();
//				if(unit)
//				{
//					unit.health -= damage;
//					Destroy(gameObject);
//				}
//			}
//
//
//	}
}
