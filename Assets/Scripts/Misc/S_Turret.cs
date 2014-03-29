using UnityEngine;
using System.Collections;

public class S_Turret : MonoBehaviour {
	public Transform target,turret1,turret2;
	public bool isTank,isInf;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		S_BasicUnit tank = transform.GetComponent<S_BasicUnit>();
		if(isTank)
		{
			if(!tank.destroyed)
			{
				turret1.LookAt(target.transform.position);
				turret1.transform.Rotate(new Vector3(-90,0,0));
			}
		}
		else
		{
			if(!tank.destroyed)
			{
				turret1.LookAt(target.transform.position);
				//turret1.transform.Rotate(new Vector3(-90,0,0));
			}
		}
	}
}
