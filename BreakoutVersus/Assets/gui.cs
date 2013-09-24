using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {
	
	public GameObject m_goPlayer1;
	public GameObject m_goPlayer2;
	
	PlayerMovement m_playerMovement;
	public Texture buttonTexture;
	public Texture buttonUnstickTexture;
	
	void Start () {
	
	}
	
	void Update () {
	}
	
	
	void OnGUI () {
		if(GUI.RepeatButton(new Rect(0,0,40,40), buttonTexture,GUIStyle.none)){
			PlayerMovement other = (PlayerMovement) m_goPlayer1.GetComponent(typeof(PlayerMovement));
			other.moveUp();
		}
		if(GUI.RepeatButton(new Rect(0,Screen.height-40,40,40), buttonTexture,GUIStyle.none)){
			PlayerMovement other = (PlayerMovement) m_goPlayer1.GetComponent(typeof(PlayerMovement));
			other.moveDown();
		}
		
		if(GUI.RepeatButton(new Rect(Screen.width-40,0,40,40), buttonTexture,GUIStyle.none)){
			PlayerMovement other = (PlayerMovement) m_goPlayer2.GetComponent(typeof(PlayerMovement));
			other.moveUp();
		}
		if(GUI.RepeatButton(new Rect(Screen.width-40,Screen.height-40,40,40), buttonTexture,GUIStyle.none)){
			PlayerMovement other = (PlayerMovement) m_goPlayer2.GetComponent(typeof(PlayerMovement));
			other.moveDown();
		}
		
		if(GUI.RepeatButton(new Rect(40,Screen.height-40,40,40), buttonUnstickTexture,GUIStyle.none)){
			PlayerMovement other = (PlayerMovement) m_goPlayer2.GetComponent(typeof(PlayerMovement));
			other.moveDown();
		}
		if(GUI.RepeatButton(new Rect(Screen.width-80,0,40,40), buttonUnstickTexture,GUIStyle.none)){
			PlayerMovement other = (PlayerMovement) m_goPlayer2.GetComponent(typeof(PlayerMovement));
			other.moveDown();
		}
		
	}
}
