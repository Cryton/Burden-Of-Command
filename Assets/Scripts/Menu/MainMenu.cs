using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour 
{

	float buttonW, buttonH, buttonX, buttonY, offset;
	public Camera mainCamera;
	public string gameScene;
	public string otherScene;
	public GameObject creditsObject;
	GameObject plane;
	Queue<Action> actions = new Queue<Action>();
	bool deQueue;
	public string[] selStrings;
	bool mainMenu, options;
	int grid = 0;
	float sV,sH;
	string stringToEdit = "Hello World";
	GameObject credits;
	// Use this for initialization
	void Start () {
		offset = Screen.height/20;
		buttonW = Screen.width/6;
		buttonH = Screen.height/6;
		buttonX = Screen.width - Screen.width/4;
		buttonY = Screen.height/4;
		plane = this.gameObject;
		deQueue = false;
		selStrings = new string[] {"Grid 1", "Grid 2", "Grid 3", "Grid 4"};
		mainMenu = true;
		options = false;
	}

	void optionsFlip()
	{
		mainCamera.transform.Translate(0,0,Time.deltaTime);
		plane.transform.Rotate(Time.deltaTime*20,Time.deltaTime*20,0);
		if(mainCamera.transform.position.z > -2)
		{
			mainMenu = false;
			options = true;
			deQueue = true;
		}
	}

	void menuFlip()
	{
		mainCamera.transform.Translate(0,0,-Time.deltaTime);
		plane.transform.Rotate(-Time.deltaTime*20,-Time.deltaTime*20,0);
		if(mainCamera.transform.position.z < -7.829573)
		{
			mainMenu = true;
			options = false;
			deQueue = true;
		}
	}

	void playGame()
	{
		Application.LoadLevel(gameScene);
		deQueue = true;
	}

	void playCredits()
	{
		//credits = (GameObject)Instantiate(creditsObject);
		Application.LoadLevel(otherScene);
		deQueue = true;
	}

	// Update is called once per frame
	void Update () 
	{
		foreach (Action m in actions)
		{
			Action act = m;
			act.Invoke();
		}
		if(deQueue)
		{
			actions.Dequeue();
			deQueue = false;
		}
		/*for(int i = actions.Count; i > 0; i--)
		{
			Action act = actions[i];
			act.Invoke ();
		}*/
	}
	void OnGUI()
	{
		if(mainMenu)
		{
		if(GUI.Button(new Rect(buttonX,offset,buttonW,buttonH), "Play"))
		{
			actions.Enqueue( ()=> this.playGame() );
		}
		if(GUI.Button(new Rect(buttonX,buttonY + offset,buttonW,buttonH), "Options"))
		{
			actions.Enqueue( ()=> this.optionsFlip() );
		}
		if(GUI.Button(new Rect(buttonX,buttonY*2 + offset,buttonW,buttonH), "Credits"))
		{
			actions.Enqueue( () => this.playCredits() );
		}
		if(GUI.Button(new Rect(buttonX,buttonY*3 + offset,buttonW,buttonH), "Cancel Credits!"))
		{
				Destroy(credits);
		}
		}
		else if(options)
		{
			if(GUI.Button(new Rect(buttonX,offset,buttonW,buttonH), "Back to Menu"))
			{
				actions.Enqueue( ()=> this.menuFlip() );
			}
			sV = GUI.VerticalSlider(new Rect(buttonX,buttonY + offset,buttonW,buttonH), sV,20f,0f);
			sH = GUI.HorizontalSlider(new Rect(buttonX,buttonY*2 + offset,buttonW,buttonH), sH,20f,0f);
		 	grid = GUI.SelectionGrid(new Rect(buttonX,buttonY*3 + offset,buttonW,buttonH), grid, selStrings, 2);
			stringToEdit = GUI.TextField(new Rect(buttonX/2,buttonY*3 + offset,buttonW,buttonH),stringToEdit);
		}
	}
}
