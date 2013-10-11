using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	int puLONG 		=1;
	int puSHORT 	=2;
	int puMAGNET 	=3;
	int puSPEEDUP 	=4;
	int puSPEEDDOWN =5;
	int puSTICK 	=6;
	
	public float previousZ = 0;
	public float currentZ = 0;
	
	public int m_PlayerType;
		int ptLEFTCHARACTER	=1;
		int ptRIGHTCHARACTER =2;
	
	float m_playerSpeed = (float).4;
	
	
	
	int m_collisionType = 0;
		int colNONE	  =0;
		int colTOP    =1;
		int colBOTTOM =2;
	
	int m_powerUpType = 0;
	float m_timer = 0;
	
	
	void Start () {
		m_collisionType = colNONE;
		previousZ = gameObject.transform.position.z;
		currentZ = gameObject.transform.position.z;
	}
	void Update(){
		previousZ = currentZ;
		currentZ = gameObject.transform.position.z;
		
		
		m_timer -= Time.deltaTime;
		
		if(m_timer < 0){
			switch(m_powerUpType){
			case 1:	//puLONG
				transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z/2);
				break;
				
			case 2:	//puSHORT
				transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z*2);
				break;
			}
			m_powerUpType = 0;
		}
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

	public void OnPowerUpCollide (int powerUpType){
		m_powerUpType = powerUpType;
		
		m_timer = 15;
		
		switch(powerUpType){
		case 1://puLONG
			transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z*2);
			break;
			
		case 2://puSHORT
			transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z/2);
			break;
		}
	}


}
