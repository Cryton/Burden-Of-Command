using UnityEngine;
using System.Collections;

public class S_Construction : MonoBehaviour {
	public GameObject building;
	public bool canbuild;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		print (canbuild);
		if(Input.GetKeyDown(KeyCode.P))
		{
			canbuild = !canbuild;
		}
		if(Input.GetMouseButton(1)&&canbuild)
		{
			RaycastHit hit;
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(r,out hit, 1000f))
			{
				if(hit.transform.tag == "Terrain")
				{
					Instantiate(building,hit.point,transform.rotation);
				}
			}	
		}
	}
}
