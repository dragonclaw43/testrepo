using UnityEngine;
using System.Collections;

public class mainMenuGUI : MonoBehaviour {
	
	int MenuIdx = 0;
	
	public Texture startButton;
	public Texture player1Controls;
	public Texture player2Controls;
	public Texture touchControls;
	public Texture levelSelectButton;
	public Texture MWLevelCapture;
	public Texture CLevelCapture;
	public Texture quitbutton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		if(MenuIdx == 0){
			if(GUI.Button(new Rect(100,(Screen.height*.75f),200,60), startButton,GUIStyle.none)){
				MenuIdx = 1;
			}
			
		}
		else if(MenuIdx == 1){			
			if(GUI.Button(new Rect(100,(Screen.height*.75f),200,60),quitbutton,GUIStyle.none)){
			  Application.LoadLevel("breakoutMenu");
			}
			if(GUI.Button(new Rect(250,(Screen.height*.70f),150,150),MWLevelCapture,GUIStyle.none)){
			  Application.LoadLevel("breakoutMidWall");
			}
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(350,(Screen.height*.70f),150,150),CLevelCapture,GUIStyle.none)){
			  Application.LoadLevel("breakoutCross");
			}
		}
		GUI.Box(new Rect(Screen.width-350,50,300,200),player1Controls);
		GUI.Box(new Rect(Screen.width-350,275,300,200),player2Controls);
		GUI.Box(new Rect(Screen.width-350,500,300,200),touchControls);
	}
}