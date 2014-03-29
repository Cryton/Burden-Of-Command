using UnityEngine;
using System.Collections;

public class S_Cam : MonoBehaviour {
	public GameObject cam;
	float zoom;
	public float minZoom,maxZoom,zoomSpeed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.LookAt(cam.transform);
		//transform.rotation = new Quaternion(0,cam.transform.rotation.y,transform.rotation.z,transform.rotation.w);
		
		if(!Input.GetKey(KeyCode.LeftControl))
		{
			if(Input.GetKey(KeyCode.W))
			{
				Vector3 dir = transform.position-cam.transform.position;
				dir.y = 0;
				transform.Translate(dir*.25f,Space.World);
			}
			if(Input.GetKey(KeyCode.A))
			{
				Vector3 dir = transform.position-cam.transform.position;
				dir = new Vector3(-dir.z,0,dir.x);
				transform.Translate(dir*.25f,Space.World);
			}
			if(Input.GetKey(KeyCode.S))
			{
				Vector3 dir = transform.position-cam.transform.position;
				dir.y = 0;
				transform.Translate(-dir*.25f,Space.World);
			}
			if(Input.GetKey(KeyCode.D))
			{
				Vector3 dir = transform.position-cam.transform.position;
				dir = new Vector3(dir.z,0,-dir.x);
				transform.Translate(dir*.25f,Space.World);
			}
			
		}
		zoom = Input.GetAxis("Mouse ScrollWheel");
		float zoomDist = Vector3.Distance(transform.position,cam.transform.position);
		//print(zoomDist);
		if(maxZoom> zoomDist && zoomDist > minZoom)
		{
			cam.transform.Translate(Vector3.forward*zoom*zoomSpeed);
		}
		else if(zoomDist > maxZoom && zoom > 0)
		{
			cam.transform.Translate(Vector3.forward*zoom*zoomSpeed);
		}
		else if(zoomDist< minZoom && zoom < 0)
		{
			cam.transform.Translate(Vector3.forward*zoom*zoomSpeed);
		}
		
	}
}
