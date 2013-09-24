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
			if(GUI.Button(new Rect(100,(Screen.height*.75f),100,30), levelSelectButton,GUIStyle.none)){
			}
		}
	}
}
