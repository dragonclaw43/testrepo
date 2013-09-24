using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	
	public int m_PlayerType;
		int ptLEFTCHARACTER	=1;
		int ptRIGHTCHARACTER =2;
	
	float m_playerSpeed = (float).4;
	
	
	
	int m_collisionType = 0;
		int colNONE	  =0;
		int colTOP    =1;
		int colBOTTOM =2;
	
	void Start () {
		m_collisionType = colNONE;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(m_PlayerType == ptLEFTCHARACTER){
        	if (Input.GetKey(KeyCode.W)){
				if(m_collisionType != colTOP){
					
					float playerTop = (this.transform.position.z + (this.renderer.bounds.size.z/2));
					if(playerTop < 9.75){
            			this.transform.Translate(new Vector3(0,0,m_playerSpeed));
					}
				}
			}
			if (Input.GetKey(KeyCode.S)){
				if(m_collisionType != colBOTTOM){
					
					float playerBottom = (this.transform.position.z - (this.renderer.bounds.size.z/2));
					if(playerBottom > -9.75){
						this.transform.Translate(new Vector3(0,0,-m_playerSpeed));
					}
				}
			}
		}
		else if(m_PlayerType == ptRIGHTCHARACTER){
			if (Input.GetKey(KeyCode.UpArrow)){
				if(m_collisionType != colTOP){
					
					float playerTop = (this.transform.position.z + (this.renderer.bounds.size.z/2));
					if(playerTop < 9.75){
            			this.transform.Translate(new Vector3(0,0,m_playerSpeed));
					}
				}
			}
			if (Input.GetKey(KeyCode.DownArrow)){
				if(m_collisionType != colBOTTOM){
					
					float playerBottom = (this.transform.position.z - (this.renderer.bounds.size.z/2));
					if(playerBottom > -9.75){
            			this.transform.Translate(new Vector3(0,0,-m_playerSpeed));
					}
				}
			}
		}
	}
  
	public void moveUp(){
		// 9.75
		// -9.75
		
		float playerTop = (this.transform.position.z + (this.renderer.bounds.size.z/2));
		
		if(playerTop < 9.75){
			this.transform.Translate(new Vector3(0,0,m_playerSpeed));
		}
	}
	
	public void moveDown(){
		
		float playerBottom = (this.transform.position.z - (this.renderer.bounds.size.z/2));
		
		if(playerBottom > -9.75){
			this.transform.Translate(new Vector3(0,0,-m_playerSpeed));
		}	
	}
			
	
	
	void OnCollisionEnter (Collision col){
 		if(col.gameObject.name == "wallTop"){
			m_collisionType = colTOP;
 		}
		else if(col.gameObject.name == "wallBottom"){
 			m_collisionType = colBOTTOM;
 		}
		else{
			m_collisionType = colNONE;
		}
	}
	
	void OnCollisionExit (Collision col){
		m_collisionType = colNONE;
	}
}
