using UnityEngine;
using System.Collections;

public class mainMenuGUI : MonoBehaviour {
	
	int MenuIdx = 0;
	
	public Texture startButton;
	public Texture player1Controls;
	public Texture player2Controls;
	public Texture touchControls;
	public Texture levelSelectButton;
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
			if(GUI.Button(new Rect(100,(Screen.height*.75f),100,30), new GUIContent("Cancel"),GUIStyle.none)){
			  Application.LoadLevel("breakoutMenu");
			}
			if(GUI.Button(new Rect(100,(Screen.height*.80f),100,30), new GUIContent("MidWall Level") ,GUIStyle.none)){
			  Application.LoadLevel("breakoutMidWall");
			}
			// Repeat adnauseum for more buttons.  Maybe need textures for each?
			if(GUI.Button(new Rect(210,(Screen.height*.80f),100,30),new GUIContent("Cross Level") ,GUIStyle.none)){
			  Application.LoadLevel("breakoutCross");
			}
		}
	}
}
