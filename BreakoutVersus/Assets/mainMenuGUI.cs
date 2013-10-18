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
			if(GUI.Button(new Rect(10,(Screen.height*.75f),(Screen.width*.2f),(Screen.height*.1f)), startButton,GUIStyle.none)){
				MenuIdx = 1;
			}
			
		}
		else if(MenuIdx == 1){	
			float x = 10;
			if(GUI.Button(new Rect(x,(Screen.height*.75f),(Screen.width*.2f),(Screen.height*.1f)),quitbutton,GUIStyle.none)){
				Debug.Log("quit");
			  Application.LoadLevel("breakoutMenu");
			}
			x += 10 + (Screen.width*.2f);
			if(GUI.Button(new Rect(x,(Screen.height*.70f),(Screen.width*.1f),(Screen.height*.2f)),MWLevelCapture,GUIStyle.none)){
				Debug.Log("mid wall");
			  Application.LoadLevel("breakoutMidWall");
			}
			x += 10 + (Screen.width*.1f);
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(x,(Screen.height*.70f),(Screen.width*.1f),(Screen.height*.2f)),CLevelCapture,GUIStyle.none)){
				Debug.Log("cross");
			  Application.LoadLevel("breakoutCross");
			}
		}
		GUI.DrawTexture(new Rect(Screen.width-(Screen.width*.3f),	0,										(Screen.width*.3f),	Screen.height/3	),player1Controls);
		GUI.DrawTexture(new Rect(Screen.width-(Screen.width*.3f),	Screen.height/3,						(Screen.width*.3f),	Screen.height/3	),player2Controls);
		GUI.DrawTexture(new Rect(Screen.width-(Screen.width*.3f),	(Screen.height/3)+(Screen.height/3),	(Screen.width*.3f),	Screen.height/3	),touchControls);
	}
}