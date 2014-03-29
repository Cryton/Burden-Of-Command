using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterMind : MonoBehaviour {
    public GameObject soldier;
    public GameObject spawn;
    public List<GameObject> Waypoints = new List<GameObject>(); 
     List<ArrayList> camps ;
    List <GameObject> peeps = new List<GameObject>();
    public float timer;
    int tracker = 0;
    GameObject temp;
     
	// Use this for initialization
	void Start () {
        camps = new List<ArrayList>(Waypoints.Count);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            
           temp = (Instantiate(soldier, spawn.transform.position,spawn.transform.rotation)) as GameObject;
            
           timer = 0;
           if (Waypoints[tracker] = null)
           {
               tracker = 0;
           }
           MoveSoldier(tracker, temp);
           tracker++;
        }

       
	
	}
    //Add the soldier to a camp
    void MoveSoldier(int spot, GameObject gObject)
    {
        //tracker = spot;
    
        gObject.name = spot.ToString();
        peeps.Add(gObject);
        
            
        

    }
    //Ask for soldiers
    void Ask()
    {
        GameObject[] player;
        player = GameObject.FindGameObjectsWithTag("PlayerUnit");
        Vector3 adv= new Vector3();
        int total = 0;
        float dist = 0;
        foreach (GameObject p in player)
        {
            adv += p.transform.position;
            total++;
        }
        adv.x = adv.x / total;
        adv.y = adv.y / total;
        adv.z = adv.z / total;
        dist = Vector3.Distance(Waypoints[0].transform.position, adv);
        int follow=0, pos_w=0;
        foreach (GameObject w in Waypoints)
        {
            if (dist >= (Vector3.Distance( w.transform.position,adv)))
            {
                dist = (Vector3.Distance( w.transform.position, adv));
                pos_w = follow;
            }
            follow++;
        }

        MoveCamps(pos_w);


    }

    //Moves current enemys to a new camp
    void MoveCamps(int campnumber)
    {
        if (Waypoints[campnumber + 1] != null)
        {
            foreach (GameObject s in peeps)
            {
                if (s.tag == (campnumber + 1).ToString())
                {
                    s.tag = campnumber.ToString();
                }
            }
        }

        else if (Waypoints[campnumber - 1] != null)
        {
            foreach (GameObject s in peeps)
            {
                if (s.tag == (campnumber - 1).ToString())
                {
                    s.tag = campnumber.ToString();
                }
            }
        }

    }
    


}
