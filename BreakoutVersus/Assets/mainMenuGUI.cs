using UnityEngine;
using System.Collections;

public class mainMenuGUI : MonoBehaviour {
	
	int MenuIdx = 0;
	
	int playerControlType = 0;
	
	public Texture startButton;
	public Texture player1Controls;
	public Texture player2Controls;
	public Texture touchControls;
	public Texture levelSelectButton;
	public Texture MWLevelCapture;
	public Texture CLevelCapture;
    public Texture ELevelCapture;
	public Texture BLevelCapture;
    public Texture TLevelCapture;
	public Texture quitbutton;
	
	public Texture optionbutton;
	public Texture touchbutton;
	public Texture buttonbutton;
	public Texture keyboardbutton;
	// Use this for initialization
	
	public GUIStyle customGuiStyle;
	void Start () {
		customGuiStyle.fontSize = (int) (Screen.height *.15);
		customGuiStyle.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		if(MenuIdx == 0){
			if(GUI.Button(new Rect(10,(Screen.height*.75f),(Screen.width*.2f),(Screen.height*.1f)), startButton,GUIStyle.none)){
				MenuIdx = 2;
			}
			if(GUI.Button(new Rect(10,((Screen.height*.75f)+(Screen.height*.1f))+ 5,(Screen.width*.2f),(Screen.height*.1f)), quitbutton,GUIStyle.none)){
				Application.Quit();
			}
			
		}
		else if(MenuIdx == 1){	
			float x = 10;
			if(GUI.Button(new Rect(x,(Screen.height*.75f),(Screen.width*.2f),(Screen.height*.1f)),quitbutton,GUIStyle.none)){
				Debug.Log("quit");
			  Application.LoadLevel("breakoutMenu");
			}
			x += (Screen.width*.2f);
			if(GUI.Button(new Rect(x,(Screen.height*.70f),(Screen.width*.1f),(Screen.height*.2f)),MWLevelCapture,GUIStyle.none)){
				Debug.Log("mid wall");
			  Application.LoadLevel("breakoutMidWall");
			}
			x +=(Screen.width*.1f);
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(x,(Screen.height*.70f),(Screen.width*.1f),(Screen.height*.2f)),CLevelCapture,GUIStyle.none)){
				Debug.Log("cross");
			  Application.LoadLevel("breakoutCross");
			}
			x += (Screen.width*.08f);
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(x,(Screen.height*.70f),(Screen.width*.1f),(Screen.height*.2f)),ELevelCapture,GUIStyle.none)){
				Debug.Log("cross");
			  Application.LoadLevel("breakoutEye");
			}
			x += 10 + (Screen.width*.1f);
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(x,(Screen.height*.70f),(Screen.width*.1f),(Screen.height*.2f)),BLevelCapture,GUIStyle.none)){
				Debug.Log("backboard");
			  Application.LoadLevel("breakoutBackboard");
			}
			x += (Screen.width*.1f);
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(x,(Screen.height*.70f),(Screen.width*.1f),(Screen.height*.2f)),TLevelCapture,GUIStyle.none)){
				Debug.Log("tunnel");
			  Application.LoadLevel("breakoutTunnel");
			}
		}
		else if(MenuIdx == 2){
			GUI.Box(new Rect(10,(Screen.height*.55f),(Screen.width*.5f),(Screen.height*.15f)),"Control Type",customGuiStyle);
			
			if(GUI.Button(new Rect(10,(Screen.height*.75f),(Screen.width*.2f),(Screen.height*.1f)), keyboardbutton,GUIStyle.none)){
				GameObject camera = GameObject.Find("Main Camera");
				camera.GetComponent<GlobalVariables>().setPlayerControlType(1);
				MenuIdx = 1;
			}
			if(GUI.Button(new Rect(10+(Screen.width*.2f),(Screen.height*.75f),(Screen.width*.2f),(Screen.height*.1f)), touchbutton,GUIStyle.none)){
				GameObject camera = GameObject.Find("Main Camera");
				camera.GetComponent<GlobalVariables>().setPlayerControlType(2);
				MenuIdx = 1;
			}
			if(GUI.Button(new Rect(10+(Screen.width*.2f)+10+(Screen.width*.2f),(Screen.height*.75f),(Screen.width*.2f),(Screen.height*.1f)), buttonbutton,GUIStyle.none)){
				GameObject camera = GameObject.Find("Main Camera");
				camera.GetComponent<GlobalVariables>().setPlayerControlType(3);
				MenuIdx = 1;
			}
		}
		GUI.DrawTexture(new Rect(Screen.width-(Screen.width*.3f),	0,										(Screen.width*.3f),	Screen.height/3	),player1Controls);
		GUI.DrawTexture(new Rect(Screen.width-(Screen.width*.3f),	Screen.height/3,						(Screen.width*.3f),	Screen.height/3	),player2Controls);
		GUI.DrawTexture(new Rect(Screen.width-(Screen.width*.3f),	(Screen.height/3)+(Screen.height/3),	(Screen.width*.3f),	Screen.height/3	),touchControls);
	}
}