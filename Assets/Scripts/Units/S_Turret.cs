using UnityEngine;
using System.Collections;

public class S_Turret : S_Unit {
	public Transform turret;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		base.Update ();
	}
	public override void Attack ()
	{
		turret.LookAt(targetList[0].transform.position);
		turret.Rotate(new Vector3(-90,0,0));
		base.Attack ();
	}
	public override void Move (Vector3 targ)
	{
		print("I'm a turret...");
	}
}
