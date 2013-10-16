using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
	public bool menuBall = false;
	
	public float multiplier = .1f;
	
	Vector3 initialVelocity;
	public float minSpeed = 10;
	public float maxSpeed = 20;
	
	public float curSpeed = 0;
	public AudioClip blockCollisionSound;
	public AudioClip wallCollisionSound;
	public AudioClip PlayerCollisionSound;
	
	public Texture 	retryButtonTexture;
	public Texture quitButtonTexture;
	
	public GameObject paddle1;
	public GameObject paddle2;
	public GameObject otherBall;
	
	public Font myFont;
	
	public int stickToPaddle = 0;
	public bool stuck = false;
	
	int m_powerUpType = 0;
	float m_timer = 0;
	
	int powerUpPlayer = 0;
	
	
	int playerWon = 0;
	// Use this for initialization
	void Start () {
		if(menuBall == false){
			stuck = true;
		}
		else{
			stuck = false;
			stickToPaddle = 0;
			initialVelocity = new Vector3(0,0,minSpeed);
			rigidbody.AddRelativeForce(initialVelocity);
		}
		
		
	}
	
	void Update(){
		m_timer -= Time.deltaTime;
		
		if(m_timer < 0){
			
			switch(m_powerUpType){
				case 3://puMAGNET
					powerUpPlayer = 0;
					Debug.Log("Magnet Powerup Over");
					break;
				
				case 4://puSPEEDUP
					minSpeed = minSpeed/2;
					maxSpeed = maxSpeed/2;
					curSpeed = Vector3.Magnitude( rigidbody.velocity);
					rigidbody.velocity /= curSpeed / minSpeed;
					Debug.Log("Speed Up Powerup Over");
					break;
				
				case 5://puSPEEDDOWN
					minSpeed = minSpeed*2;
					maxSpeed = maxSpeed*2;
					curSpeed = Vector3.Magnitude( rigidbody.velocity);
					rigidbody.velocity /= curSpeed / minSpeed;
					Debug.Log("Speed Down Powerup Over");
					break;
				
				case 6://puSTICK
					stickToPaddle = 0;
					Debug.Log("Stick Powerup Over");
					//stuck = false;
					break;
			}
			m_powerUpType = 0;
		}
		else if(m_powerUpType == 6){
			stickToPaddle = powerUpPlayer;
		}
		
		
		
		
		if(this.transform.position.x < -16.25){
			playerWon = 2;
			Destroy(otherBall);
		}
		if(this.transform.position.x > 16.25){
			// player 2 lose
			playerWon = 1;	
			Destroy(otherBall);
		}
	}
	
	void OnGUI () {
		if(playerWon != 0){
			GUI.skin.font = myFont;
			
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
			if(playerWon == 1){
				GUI.Label(new Rect(100,0,500,100),"Player 1 Wins");	
			}
			else{
				GUI.Label(new Rect(100,0,500,100),"Player 2 Wins");
			}
			if(GUI.Button(new Rect(Screen.width/2-(90/2),Screen.height/2,178,56), retryButtonTexture,GUIStyle.none)){
				playerWon= 0;
				//todo: Randomize listing for next level or select level screen
				Application.LoadLevel(Application.loadedLevelName);
			}
			if(GUI.Button(new Rect(Screen.width/2-(90/2),(Screen.height/2)+56,178,56), quitButtonTexture,GUIStyle.none)){
				playerWon= 0;
				Application.LoadLevel("breakoutMenu");
			}
		}
	}
	
	
	
	public void unstick(int player){
		if (player == 1){
			stuck = false;
			stickToPaddle = 0;
			
			float paddleVelocity = GameObject.Find("Player1").GetComponent<PlayerMovement>().m_velocity;
			
			float velocity = (paddle1.GetComponent<PlayerMovement>().currentZ - 
								paddle1.GetComponent<PlayerMovement>().previousZ)/Time.deltaTime;
			
			Debug.Log("On Paddle Velocity + " + paddleVelocity);
			
			initialVelocity = new Vector3(minSpeed,0,velocity + (paddleVelocity*10));
			rigidbody.AddRelativeForce(initialVelocity);
		}
		
        if (player == 2){
			stuck = false;
			stickToPaddle = 0;
			
			float paddleVelocity = GameObject.Find("Player2").GetComponent<PlayerMovement>().m_velocity;
			
			float velocity = 	(paddle2.GetComponent<PlayerMovement>().currentZ - 
									paddle2.GetComponent<PlayerMovement>().previousZ)/Time.deltaTime;
			
			Debug.Log("On Paddle Velocity + " + paddleVelocity);
			
			initialVelocity = new Vector3(-minSpeed,0,velocity + (paddleVelocity*10));
			rigidbody.AddRelativeForce(initialVelocity);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.D) && stickToPaddle == 1){
			stuck = false;
			stickToPaddle = 0;
			
			float paddleVelocity = GameObject.Find("Player1").GetComponent<PlayerMovement>().m_velocity;
			
			float velocity = (paddle1.GetComponent<PlayerMovement>().currentZ - 
								paddle1.GetComponent<PlayerMovement>().previousZ)/Time.deltaTime;
			
			Debug.Log("On Paddle Velocity + " + paddleVelocity);
			
			initialVelocity = new Vector3(minSpeed,0,velocity + (paddleVelocity*10));
			rigidbody.AddRelativeForce(initialVelocity);
		}
		
        if (Input.GetKey(KeyCode.LeftArrow) && stickToPaddle == 2){
			stuck = false;
			stickToPaddle = 0;
			
			float paddleVelocity = GameObject.Find("Player2").GetComponent<PlayerMovement>().m_velocity;
			
			float velocity = 	(paddle2.GetComponent<PlayerMovement>().currentZ - 
									paddle2.GetComponent<PlayerMovement>().previousZ)/Time.deltaTime;
			
			Debug.Log("On Paddle Velocity + " + paddleVelocity);
			
			initialVelocity = new Vector3(-minSpeed,0,velocity + (paddleVelocity*10));
			rigidbody.AddRelativeForce(initialVelocity);
		}
		
		
		if(stuck){
			if(stickToPaddle == 1){
				transform.position = new Vector3(	paddle1.transform.position.x + paddle1.renderer.bounds.size.x - (paddle1.renderer.bounds.size.x*.1f),
													paddle1.transform.position.y ,
													paddle1.transform.position.z);
			}
			else{
				transform.position = new Vector3(	paddle2.transform.position.x - paddle2.renderer.bounds.size.x + (paddle2.renderer.bounds.size.x*.1f),
													paddle2.transform.position.y ,
													paddle2.transform.position.z);
			}
		}
		else{
			curSpeed = Vector3.Magnitude( rigidbody.velocity);
			
			if(curSpeed > maxSpeed){
				rigidbody.velocity /= curSpeed / maxSpeed;
			}
			if(curSpeed < minSpeed && curSpeed > 0){
				rigidbody.velocity /= curSpeed / minSpeed;
			}
				
			// magnet mode
			if(powerUpPlayer == 1){
				if(paddle1.transform.position.z < transform.position.z){
					rigidbody.velocity =	new Vector3(rigidbody.velocity.x,rigidbody.velocity.y,rigidbody.velocity.z-.1f);
				}
				else if(paddle1.transform.position.z > transform.position.z){
					rigidbody.velocity =	new Vector3(rigidbody.velocity.x,rigidbody.velocity.y,rigidbody.velocity.z+.1f);
				}
			}
			else if(powerUpPlayer == 2){
				if(paddle2.transform.position.z < transform.position.z){
					rigidbody.velocity =	new Vector3(rigidbody.velocity.x,rigidbody.velocity.y,rigidbody.velocity.z-.1f);
				}
				else if(paddle2.transform.position.z > transform.position.z){
					rigidbody.velocity =	new Vector3(rigidbody.velocity.x,rigidbody.velocity.y,rigidbody.velocity.z+.1f);
				}
			}
		}
		
		//this.transform.Translate(new Vector3(movementX,0,movementZ));
	}
	
	void OnCollisionEnter(Collision theCollision){
		
		if(theCollision.collider.gameObject.name == "Player1" || theCollision.collider.gameObject.name == "Player2"){
			//audio.clip = PlayerCollisiodnSound;
			audio.PlayOneShot(PlayerCollisionSound);	
			if(stickToPaddle == 0){
				float differenceZ = theCollision.contacts[0].point.z - theCollision.collider.gameObject.transform.position.z;
				
				float velocity = 	(theCollision.collider.gameObject.GetComponent<PlayerMovement>().currentZ - 
									theCollision.collider.gameObject.GetComponent<PlayerMovement>().previousZ)/Time.deltaTime;
				
				rigidbody.AddRelativeForce(new Vector3(3,0,velocity*2*differenceZ));
			}
			else{
				stuck = true;
			}
		}
		else if(theCollision.collider.gameObject.name == "block"){
			//audio.clip = blockCollisionSound;
			audio.PlayOneShot(blockCollisionSound);
		}
		else{
			//audio.clip = wallCollisionSound;
			audio.PlayOneShot(wallCollisionSound);
		}
		rigidbody.velocity += rigidbody.velocity * multiplier;
	}

	public void OnPowerUpCollide (int powerUpType, int player){
		m_powerUpType = powerUpType;
		
		m_timer = 15;
		
		switch(powerUpType){
		case 3://puMAGNET
			powerUpPlayer = player;
			break;
			
		case 4://puSPEEDUP
			minSpeed = minSpeed*2;
			maxSpeed = maxSpeed*2;
			break;
			
		case 5://puSPEEDDOWN
			minSpeed = minSpeed/2;
			maxSpeed = maxSpeed/2;
			break;
			
		case 6://puSTICK
			stickToPaddle = player;
			powerUpPlayer = player;
			stuck = true;
			break;
		}
	}
	
	public void onPaddleVelocityGet(float velocity){
		
		rigidbody.velocity =	new Vector3(rigidbody.velocity.x,rigidbody.velocity.y,rigidbody.velocity.z + (velocity*2));
	}
}
