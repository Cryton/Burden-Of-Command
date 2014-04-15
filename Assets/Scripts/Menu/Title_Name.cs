using UnityEngine;
using System.Collections;

public class Title_Name : MonoBehaviour {
    public TextMesh Burden;
    public TextMesh of;
    public TextMesh Commmand;
    public float speed;
    public float time;
    int track = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (time < speed)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            track++;
            AddString(track);
        }
	
	}

    void AddString(int num)
    {
        switch (num)
        {
            case 1:
                Burden.text = "B";
                break;
            case 2:
                Burden.text = "Bu";
                break;
            case 3:
                Burden.text = "Bur";
                break;
            case 4:
                Burden.text = "Burd";
                break;
            case 5:
                Burden.text = "Burde";
                break;
            case 6:
                Burden.text = "Burden";
                break;
            case 7:
                of.text = "O";
                break;
            case 8:
                of.text = "Of";
                break;
            case 9:
                Commmand.text = "C";
                break;
            case 10:
                Commmand.text = "Co";
                break;
            case 11:
                Commmand.text = "Com";
                break;
            case 12:
                Commmand.text = "Comm";
                break;
            case 13:
                Commmand.text = "Comma";
                break;
            case 14:
                Commmand.text = "Comman";
                break;
            case 15:
                Commmand.text = "Command";
                break;







        }

    }
}
