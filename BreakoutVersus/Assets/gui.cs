using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {
	
	public GameObject m_goPlayer1;
	public GameObject m_goPlayer2;
	
	PlayerMovement m_playerMovement;
	public Texture buttonTexture;
	public Texture buttonUnstickTexture;
	int buttonSize;
	void Start () {
		if(Screen.dpi != 0){
			buttonSize = (int) Screen.dpi;
		}
		else{
			buttonSize = 50;
		}
	}
	
	void Update () {
	}
	
	
	void OnGUI () {
		
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
