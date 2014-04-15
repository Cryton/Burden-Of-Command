using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterMind : MonoBehaviour {
    
    public GameObject spawn;
    //A List of prefab of Troops
    public List<GameObject> TroopsToSpawn = new List<GameObject>();
    //A list of camps you can walk to
    public List<GameObject> Camps = new List<GameObject>();

    List<GameObject> peeps = new List<GameObject>(100);
    float timer;
    public float spawntimer;
    int tracker = 0;
    //GameObject temp;
    
     
	// Use this for initialization
	void Start () {
       
        //camps = new List<ArrayList>(Waypoints.Count);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        
        if (timer >= spawntimer)
        {
           CreateSoldier();
          
        }

       
	
	}

    
    //Create and Add the soldier to a camp
    void CreateSoldier()
    {
        if (peeps.Count < peeps.Capacity)
        {
            GameObject temp;
            int ran_sp = Random.Range(0, TroopsToSpawn.Count);
            int ran_camp = Random.Range(0, Camps.Count);
            temp = (Instantiate(TroopsToSpawn[ran_sp], spawn.transform.position, spawn.transform.rotation)) as GameObject;
            temp.gameObject.tag = "Enemy";
            temp.SendMessage("Move", Camps[ran_camp].transform.position);
            timer = 0;
        }
           

    }
    //Ask for soldiers
    void Ask()
    {
        GameObject[] player;
        player = GameObject.FindGameObjectsWithTag("PlayerUnit");
        Vector3 adv = new Vector3();
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
        //dist = the first Waypoint
        dist = Vector3.Distance(Camps[0].transform.position, adv);
        int follow = 0, pos_w = 0;
        foreach (GameObject w in Camps)
        {
            if (dist >= (Vector3.Distance(w.transform.position, adv)))
            {
                dist = (Vector3.Distance(w.transform.position, adv));
                pos_w = follow;
            }
            follow++;
        }
        if (dist < 40f)
        {
            MoveCamps(pos_w, Camps[pos_w].transform.position);
        }
        else
        {
            MoveCamps(tracker, Camps[tracker].transform.position);

        }


    }

    //Moves current enemys to a camp
    void MoveCamps(int campnumber, Vector3 point)
    {
        GameObject[] GetEnemy;
        GetEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        //player = GameObject.FindGameObjectsWithTag((campnumber - 1).ToString());
        foreach (GameObject g in GetEnemy)
        {
            if (g != null)
            {
                g.SendMessage("Move", point);
            }
        }
        /*if (Waypoints[campnumber + 1] != null)
        {
            foreach (GameObject s in peeps)
            {
                if (s.name == (campnumber + 1).ToString())
                {
                    s.name = campnumber.ToString();
                }
            }
        }

        else if (Waypoints[campnumber - 1] != null)
        {
            foreach (GameObject s in peeps)
            {
                if (s.name == (campnumber - 1).ToString())
                {
                    s.name = campnumber.ToString();
                }
            }
        }*/

    }



}


public class SP_Enemy
    {

        public int camp_at
        {
            get;

            set;
        }

        public int tag_as
        {
            get ;

            set;
        }

        public int camp
        {
            get;

            set;
        }
    }

