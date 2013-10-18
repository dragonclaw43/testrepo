using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {
	
	public GameObject m_goPlayer1;
	public GameObject m_goPlayer2;
	
	PlayerMovement m_playerMovement;
	public Texture buttonTexture;
	public Texture buttonUnstickTexture;
	public Texture optionsButton;
	public Texture retryButtonTexture;
	public Texture quitButtonTexture;
	int buttonSize;
	
	bool menupressed = false;
	int playerControlType;
	
	void Start () {
		if(Screen.dpi != 0){
			buttonSize = (int) (Screen.dpi/2);
		}
		else{
			buttonSize = 50;
		}
		
		GameObject camera = GameObject.Find("Main Camera");
		playerControlType = camera.GetComponent<GlobalVariables>().getPlayerControlType();
	}
	
	void Update () {
	}
	
	
	void OnGUI () {
		if(GUI.RepeatButton(new Rect(Screen.width/2-(buttonSize/2),0,buttonSize,buttonSize/2), optionsButton,GUIStyle.none)){
			menupressed = !menupressed;
		}
		if(menupressed){
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
			if(GUI.Button(new Rect((Screen.width/2)-(Screen.width/8),	(Screen.height/2)-(Screen.height/8),	(Screen.width/4),	(Screen.height/4)), retryButtonTexture,GUIStyle.none)){
				//todo: Randomize listing for next level or select level screen
				Application.LoadLevel(Application.loadedLevelName);
			}
			if(GUI.Button(new Rect((Screen.width/2)-(Screen.width/8),	(Screen.height/2)+(Screen.height/8),	(Screen.width/4),	(Screen.height/4)), quitButtonTexture,GUIStyle.none)){
				Application.LoadLevel("breakoutMenu");
			}
		}
		
		if(playerControlType == 3){
			// Player 1 Left
			if(GUI.RepeatButton(new Rect(0,0,buttonSize,buttonSize), buttonTexture,GUIStyle.none)){
				PlayerMovement other = (PlayerMovement) m_goPlayer1.GetComponent(typeof(PlayerMovement));
				other.moveUp();
			}
			// Player 1 Right
			if(GUI.RepeatButton(new Rect(0,Screen.height-buttonSize,buttonSize,buttonSize), buttonTexture,GUIStyle.none)){
				PlayerMovement other = (PlayerMovement) m_goPlayer1.GetComponent(typeof(PlayerMovement));
				other.moveDown();
			}
			// Player 2 Right
			if(GUI.RepeatButton(new Rect(Screen.width-buttonSize,0,buttonSize,buttonSize), buttonTexture,GUIStyle.none)){
				PlayerMovement other = (PlayerMovement) m_goPlayer2.GetComponent(typeof(PlayerMovement));
				other.moveUp();
			}
			// Player 2 Left
			if(GUI.RepeatButton(new Rect(Screen.width-buttonSize,Screen.height-buttonSize,buttonSize,buttonSize), buttonTexture,GUIStyle.none)){
				PlayerMovement other = (PlayerMovement) m_goPlayer2.GetComponent(typeof(PlayerMovement));
				other.moveDown();
			}
		}
		if(playerControlType != 1){
		// Player 1 unstick
			if(GUI.RepeatButton(new Rect(buttonSize,Screen.height-buttonSize,buttonSize,buttonSize), buttonUnstickTexture,GUIStyle.none)){
				PlayerMovement other = (PlayerMovement) m_goPlayer1.GetComponent(typeof(PlayerMovement));
				other.unstick();
			}
			// player 2 unstick
			if(GUI.RepeatButton(new Rect(Screen.width-(buttonSize*2),0,buttonSize,buttonSize), buttonUnstickTexture,GUIStyle.none)){
				PlayerMovement other = (PlayerMovement) m_goPlayer2.GetComponent(typeof(PlayerMovement));
				other.unstick();
			}
		}
	}
}
