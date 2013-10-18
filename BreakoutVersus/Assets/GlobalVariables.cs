using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {
	
	public static int m_playerControlType; 
		//1 keyboard
		//2 touch
		//3 button
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setPlayerControlType(int controlType){
		m_playerControlType = controlType;
	}
	
	public int getPlayerControlType(){
		return m_playerControlType;	
	}
}
