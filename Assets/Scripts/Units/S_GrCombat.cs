using UnityEngine;
using System.Collections;

public class S_GrCombat : S_Unit 
{
	Vector3 oldSpot;
	public bool treads;
	public Transform turret;
	public float turnSpeed;
	// Use this for initialization
	void Start () 
	{

	}
	public override void Update ()
	{
		if(!destroyed)
		{
			if(oldSpot == transform.position)
			{
				if(treads)
				{
					TrackAnimator tracks = transform.GetComponent<TrackAnimator>();
					tracks.speed = 0;
				}
				else
				{
					WheelAnimator wheels = transform.GetComponent<WheelAnimator>();
					wheels.speed = 0;
				}
			}
			else
			{
				if(treads)
				{
					TrackAnimator tracks = transform.GetComponent<TrackAnimator>();
					tracks.speed = 100;
				}
				else
				{
					WheelAnimator wheels = transform.GetComponent<WheelAnimator>();
					wheels.speed = 300;
				}
			}
			oldSpot = transform.position;
		}
		else
		{
			if(treads)
			{
				TrackAnimator tracks = transform.GetComponent<TrackAnimator>();
				tracks.speed = 0;
			}
			else
			{
				WheelAnimator wheels = transform.GetComponent<WheelAnimator>();
				wheels.speed = 0;
			}
		}
		base.Update ();
	}
	// Update is called once per frame
	public override void Attack ()
	{
//		SciFiTurret turr = transform.GetComponent<SciFiTurret>();
//		if(targetList.Count != 0)
//		{
//			turr.target = targetList[0].transform;
//		}
//		else
//		{
//			turr.target = null;
//		}
		turret.LookAt(targetList[0].transform.position);
		turret.transform.Rotate(new Vector3(-90,0,0));
		base.Attack ();
	}
	public override void Move (Vector3 targ)
	{
		base.Move (targ);
	}
}
