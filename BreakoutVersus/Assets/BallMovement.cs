using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
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
	bool stuck = false;
	
	int playerWon = 0;
	// Use this for initialization
	void Start () {
		stuck = true;
		//rigidbody.AddRelativeForce(initialVelocity);
		
	}
	
	void Update(){
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
		Debug.Log("ongui called");
		if(playerWon != 0){
			Debug.Log("Player Won");
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
				Debug.Log("Wants a new game");
				//todo: Randomize listing for next level or select level screen
				Application.LoadLevel(Application.loadedLevelName);
			}
			if(GUI.Button(new Rect(Screen.width/2-(90/2),(Screen.height/2)+56,178,56), quitButtonTexture,GUIStyle.none)){
				playerWon= 0;
				Application.LoadLevel("breakoutMenu");
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.D) && stickToPaddle == 1){
			Debug.Log("D Pressed");
			stuck = false;
			stickToPaddle = 0;
			
			float velocity = (paddle1.GetComponent<PlayerMovement>().currentZ - 
								paddle1.GetComponent<PlayerMovement>().previousZ)/Time.deltaTime;
			
			initialVelocity = new Vector3(minSpeed,0,velocity);
			rigidbody.AddRelativeForce(initialVelocity);
		}
		
        if (Input.GetKey(KeyCode.LeftArrow) && stickToPaddle == 2){
			Debug.Log("Left Arrow Pressed");
			stuck = false;
			stickToPaddle = 0;
			
			float velocity = 	(paddle2.GetComponent<PlayerMovement>().currentZ - 
									paddle2.GetComponent<PlayerMovement>().previousZ)/Time.deltaTime;
			
			initialVelocity = new Vector3(-minSpeed,0,velocity);
			rigidbody.AddRelativeForce(initialVelocity);
		}
		
		
		if(stuck){
			if(stickToPaddle == 1){
				transform.position = new Vector3(	paddle1.transform.position.x + paddle1.renderer.bounds.size.x ,
													paddle1.transform.position.y ,
													paddle1.transform.position.z);
			}
			else{
				transform.position = paddle2.transform.position;
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
}
