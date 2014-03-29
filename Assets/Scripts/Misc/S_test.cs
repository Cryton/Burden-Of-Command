using UnityEngine;
using System.Collections;

public class S_test : MonoBehaviour {
	public GameObject[] zeObjects;
	public GameObject center;
	Vector3 centerPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		centerPoint = new Vector3(0,0,0);
		foreach(GameObject ob in zeObjects)
		{
			centerPoint += ob.transform.position;
		}
		centerPoint.x /= zeObjects.Length;
		centerPoint.z /= zeObjects.Length;

		center.transform.position = centerPoint;
	}
}
