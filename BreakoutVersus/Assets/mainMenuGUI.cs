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
			if(GUI.Button(new Rect(100,(Screen.height*.75f),100,30), startButton,GUIStyle.none)){
				MenuIdx = 1;
			}
			
		}
		else if(MenuIdx == 1){			
			if(GUI.Button(new Rect(100,(Screen.height*.75f),100,30),quitbutton,GUIStyle.none)){
			  Application.LoadLevel("breakoutMenu");
			}
			if(GUI.Button(new Rect(200,(Screen.height*.70f),115,115),MWLevelCapture,GUIStyle.none)){
			  Application.LoadLevel("breakoutMidWall");
			}
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(280,(Screen.height*.70f),115,115),CLevelCapture,GUIStyle.none)){
			  Application.LoadLevel("breakoutCross");
			}
		}
	}
}