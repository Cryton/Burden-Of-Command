using UnityEngine;
using System.Collections;

public class S : MonoBehaviour {
	public Transform target,turret1,turret2;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
//		float ang = Vector3.Angle(target.position-turret1.transform.position,-turret1.transform.right);
//		float ang2 = Vector3.Angle(target.position-turret1.transform.position,turret1.transform.right);
//		float ang3 = Vector3.Angle(target.position-turret1.transform.position,turret1.transform.forward);
//		float vertAng = Vector3.Angle(target.position-transform.position,transform.up);
//		print(ang3);
//		if(ang3 > 2)
//		{
//			if(ang < ang2)
//			{
//				turret1.transform.Rotate(-transform.forward);
//			}
//			else
//			{
//				turret1.transform.Rotate(transform.forward);
//			}
//			
//		}
//		if(vertAng > 2)
//		{
//			
//		}

		turret1.LookAt(target.transform.position);
		turret1.transform.Rotate(new Vector3(-90,0,0));

	}
}
