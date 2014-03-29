using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Selector : MonoBehaviour {
	public Vector3 start, finish,mouseStart,boxVect;
	public List<GameObject> selectedUnits;
	bool dragBox;
	public GameObject b1,b2;
	//This assumes 0,0 to be in bottom left**
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetMouseButtonDown(0))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			int layerMask = 1 << 8;
			if(Physics.Raycast(r,out hit,10000,layerMask))
			{
				start = hit.point;
				mouseStart = Input.mousePosition;
				dragBox = true;
				//b1.transform.position = start;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			int layerMask = 1 << 8;
			if(Physics.Raycast(r,out hit,10000,layerMask))
			{
				finish = hit.point;
				//b2.transform.position = finish;
				if(hit.transform.gameObject.tag == "PlayerUnit")
				{
					SelectionBox(hit.transform.gameObject);
				}
				else
				{
					SelectionBox(null);
				}
				//SelectionBox();
				dragBox = false;
			}
		}
		if(Input.GetMouseButton(1))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(r,out hit,10000))
			{
				foreach(GameObject g in selectedUnits)
				{
					S_BasicUnit unit = g.GetComponent<S_BasicUnit>();
					if(!unit)
					{
						unit = g.transform.parent.GetComponent<S_BasicUnit>();
					}
					if(selectedUnits.Count > 1)
					{
						unit.Move(Center(g.transform.position,hit.point));
					}
					else
					{
						Vector3 target = hit.point;
						unit.Move (target);
					}
				}
			}
		}
		
	}
	void SelectionBox(GameObject g)
	{
		Deselect();
		if(g)
		{
			selectedUnits.Add(g);
		}
		int boxType; //1=bottomleft-topright  2=topleft-bottomright 3 =bottomright-topleft 4= topright-bottomleft
		if(start.x > finish.x)
		{
			if(start.z > finish.z)
			{
				boxType = 4;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > finish.x && unit.transform.position.x < start.x) && (unit.transform.position.z > finish.z && unit.transform.position.z < start.z))
					{
						selectedUnits.Add(unit);
					}
				}
			}
			else
			{
				boxType = 3;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > finish.x && unit.transform.position.x < start.x) && (unit.transform.position.z > start.z && unit.transform.position.z < finish.z))
					{
						selectedUnits.Add(unit);
					}
				}
			}
		}
		else
		{
			if(start.z > finish.z)
			{
				boxType = 2;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > start.x && unit.transform.position.x < finish.x) && (unit.transform.position.z > finish.z && unit.transform.position.z < start.z))
					{
						selectedUnits.Add(unit);
					}
				}
			}
			else
			{
				boxType = 1;
				GameObject[] pool = GameObject.FindGameObjectsWithTag("PlayerUnit");
				foreach(GameObject unit in pool)
				{
					if((unit.transform.position.x > start.x && unit.transform.position.x < finish.x) && (unit.transform.position.z > start.z && unit.transform.position.z < finish.z))
					{
						selectedUnits.Add(unit);
					}
				}
				
			}
			
		}
		foreach(GameObject uni in selectedUnits)
		{
			S_BasicUnit unit = uni.GetComponent<S_BasicUnit>();
			if(!unit)
			{
				unit = uni.transform.parent.GetComponent<S_BasicUnit>();
			}
			unit.isSelected = true;

		}
		
		
	}
	public void Deselect()
	{
		foreach(GameObject uni in selectedUnits)
		{
			S_BasicUnit unit = uni.GetComponent<S_BasicUnit>();
			if(!unit)
			{
				unit = uni.transform.parent.GetComponent<S_BasicUnit>();
			}
			unit.isSelected = false;
		}
		selectedUnits.Clear();
	}
	public Vector3 Center(Vector3 pos, Vector3 target)
	{
		Vector3 zeCenter = new Vector3();
		foreach(GameObject unit in selectedUnits)
		{
			zeCenter += unit.transform.position;
		}
		zeCenter.x /= selectedUnits.Count;
		zeCenter.z /= selectedUnits.Count;

		Vector3 final = pos - zeCenter;
		final.y = 0;
		print (final+target);
		return final + target;
	}
	void OnGUI()
	{
		//GUI.Box(new Rect(boxVect.x,boxVect.y,40,40),"Hello");
		//print(Input.mousePosition);
		if(dragBox)
		{
			Vector3 mouse = Input.mousePosition;
			if(mouse.x > mouseStart.x)
			{
				if(mouse.y > mouseStart.y)
				{
					GUI.Box(new Rect(mouseStart.x,(Screen.height - mouse.y),mouse.x-mouseStart.x,mouse.y-mouseStart.y),"");
				}
				else
				{
					GUI.Box(new Rect(mouseStart.x,(Screen.height - mouseStart.y),mouse.x-mouseStart.x,mouseStart.y-mouse.y),"");
				}
			}
			else
			{
				if(mouse.y > mouseStart.y)
				{
					GUI.Box(new Rect(mouse.x,(Screen.height - mouse.y),mouseStart.x-mouse.x,mouse.y-mouseStart.y),"");
				}
				else
				{
					GUI.Box(new Rect(mouse.x,(Screen.height - mouseStart.y),mouseStart.x-mouse.x,mouseStart.y-mouse.y),"");
				}
			}
			
		}
	}
}
