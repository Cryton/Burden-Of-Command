using UnityEngine;
using System.Collections;

public class Make_People : MonoBehaviour {
	float unitTimer = 0.0f;
	public float timer = 2.00f;
	bool canSpawn = true;
	int totalUnits=0;
	public int Building_Max_Spawn = 10;
	public GameObject Troops;
	public GameObject MeetPoint;
	public GameObject spawnPoint;
	Queue SpawnQueue = new Queue();
	Queue SpawnTimeQueue = new Queue();
	bool switch_queue = false;


	// Use this for initialization
	void Start () {

		//unitTimer = timer;

	
	}
	
	// Update is called once per frame
	void Update () 
	{

		MakeUnits ();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			QueueTroops( Troops , 2.0f );
		}

		if(Input.GetMouseButton (1))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(r,out hit,1000))
			{
				print("BLAAHHHHH");
				if (hit.transform.tag == "Terrain")
				MeetPoint.transform.position = hit.point;
			}

			Debug.DrawLine(r.origin, hit.point);
//			print ("pew FLag");
//			RaycastHit hit;
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			if (Physics.Raycast(ray, out hit,100))
//			{
//				print ("pew");
//				if (hit.transform.tag == "Terrain")
//					MeetPoint.transform.TransformPoint (hit.point);
//			}
//
//			print ("pew F");
		}

	
	}

	public void QueueTroops(GameObject units, float time)
	{
		if(totalUnits < Building_Max_Spawn)
		{
			SpawnTimeQueue.Enqueue (time);
			SpawnQueue.Enqueue (units);
			totalUnits++;
		}
		else
		Debug.Log("No more Units can be put in the Queue");
	}
	void MakeUnits()
	{
		
		if(totalUnits  > 0)
		{
			if(unitTimer > 0.0f)
			{
				unitTimer -=Time.deltaTime; 
			}
			
			else
			{
				if(switch_queue == false)
				{
					unitTimer = (float)SpawnTimeQueue.Dequeue();
					switch_queue = true;
				}
				else
				{
					
					GameObject troop = Instantiate((GameObject)SpawnQueue.Dequeue(),spawnPoint.transform.position,transform.rotation) as GameObject;
					S_BasicUnit troopAI = troop.GetComponent<S_BasicUnit>();
					troopAI.Move(MeetPoint.transform.position);
					switch_queue = false;
					totalUnits--;
				}
			}
			
			
		}

	}

}
