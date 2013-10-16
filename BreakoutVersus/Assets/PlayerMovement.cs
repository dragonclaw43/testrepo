using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float previousZ = 0;
	public float currentZ = 0;
	
	public int m_PlayerType;
		int ptLEFTCHARACTER	=1;
		int ptRIGHTCHARACTER =2;
	
	float m_playerSpeed = (float).4;
	
	bool ballCollision1 = false;
	bool ballCollision2 = false;
	
	int m_collisionType = 0;
		int colNONE	  =0;
		int colTOP    =1;
		int colBOTTOM =2;
	
	int m_powerUpType = 0;
	float m_timer = 0;
	
	public float m_velocity = 0.0f;		// between -1.0 and 1.0 used for ball
	
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
				transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z*1.5f);
				break;
			}
			m_powerUpType = 0;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		if(m_velocity < 0){
			m_velocity += 0.03f;
		}
		else if(m_velocity > 0){
			m_velocity -= 0.03f;
		}
		if(Input.touchCount > 0){
			Touch a = Input.GetTouch(0);
			if(a.position.x > 0 && m_PlayerType == ptRIGHTCHARACTER){
				transform.position = new Vector3(transform.position.x,transform.position.y,a.position.y);
			}
			else if(m_PlayerType == ptLEFTCHARACTER){
				transform.position = new Vector3(transform.position.x,transform.position.y,a.position.y);
			}
		}
		if(m_PlayerType == ptLEFTCHARACTER){
        	if (Input.GetKey(KeyCode.W)){
				if(m_collisionType != colTOP){
					
					float playerTop = (this.transform.position.z + (this.renderer.bounds.size.z/2));
					if(playerTop < 9.75){
            			this.transform.Translate(new Vector3(0,0,m_playerSpeed));
					}
					
					if(m_velocity < 0){
						m_velocity = 0;
					}
					if(m_velocity < 1){
						m_velocity += 0.05f;
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
				
				if(m_velocity > 0){
					m_velocity = 0;
				}
				if(m_velocity > -1){
					m_velocity -= 0.05f;
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
					
					if(m_velocity < 0){
						m_velocity = 0;
					}
					if(m_velocity < 1){
						m_velocity += 0.05f;
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
				
				if(m_velocity > 0){
					m_velocity = 0;
				}
				if(m_velocity > -1){
					m_velocity -= 0.05f;
				}
			}
		}
		
		
	}
  
	public void moveUp(){
		// 9.75
		// -9.75
		
		if(m_velocity < 0){
			m_velocity = 0;
		}
		if(m_velocity < 1){
			m_velocity += 0.05f;
		}
		
		float playerTop = (this.transform.position.z + (this.renderer.bounds.size.z/2));
		
		if(playerTop < 9.75){
			this.transform.Translate(new Vector3(0,0,m_playerSpeed));
		}
	}
	
	public void moveDown(){
		
		if(m_velocity > 0){
			m_velocity = 0;
		}
		if(m_velocity > -1){
			m_velocity -= 0.05f;
		}
		float playerBottom = (this.transform.position.z - (this.renderer.bounds.size.z/2));
		
		if(playerBottom > -9.75){
			this.transform.Translate(new Vector3(0,0,-m_playerSpeed));
		}	
	}
			
	public void unstick(){
		if(ballCollision1 == true){
			GameObject a = GameObject.Find("Ball1");
			a.GetComponent<BallMovement>().unstick(1);
			a.GetComponent<BallMovement>().onPaddleVelocityGet(m_velocity);
		}
		if(ballCollision2 == true){
			GameObject a = GameObject.Find("Ball2");
			a.GetComponent<BallMovement>().unstick(2);
			a.GetComponent<BallMovement>().onPaddleVelocityGet(m_velocity);
		}
	}
	
	void OnCollisionEnter (Collision col){
		ballCollision1 = false;
		ballCollision2 = false;
 		if(col.gameObject.name == "wallTop"){
			m_collisionType = colTOP;
 		}
		else if(col.gameObject.name == "wallBottom"){
 			m_collisionType = colBOTTOM;
 		}
		else if(col.gameObject.name == "Ball1"){
			ballCollision1 = true;
			GameObject.Find("Ball1").GetComponent<BallMovement>().onPaddleVelocityGet(m_velocity);
		}
		else if(col.gameObject.name == "Ball2"){
			ballCollision2 = true;
			GameObject.Find("Ball2").GetComponent<BallMovement>().onPaddleVelocityGet(m_velocity);
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
			transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z/1.5f);
			break;			
		}
	}


}
