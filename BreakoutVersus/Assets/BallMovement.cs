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
	
	public GameObject otherBall;
	
	public Font myFont;
	
	int playerWon = 0;
	// Use this for initialization
	void Start () {
		initialVelocity = new Vector3(minSpeed,0,minSpeed);
		rigidbody.AddRelativeForce(initialVelocity);
		
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
				Application.LoadLevel("breakoutMidWall");
			}
			if(GUI.Button(new Rect(Screen.width/2-(90/2),(Screen.height/2)+56,178,56), quitButtonTexture,GUIStyle.none)){
				playerWon= 0;
				Application.LoadLevel("breakoutMenu");
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		curSpeed = Vector3.Magnitude( rigidbody.velocity);
		
		if(curSpeed > maxSpeed){
			rigidbody.velocity /= curSpeed / maxSpeed;
		}
		if(curSpeed < minSpeed && curSpeed > 0){
			rigidbody.velocity /= curSpeed / minSpeed;
		}
		//this.transform.Translate(new Vector3(movementX,0,movementZ));
	}
	
	void OnCollisionEnter(Collision theCollision){
		
		if(theCollision.collider.gameObject.name == "Player1" || theCollision.collider.gameObject.name == "Player2"){
			//audio.clip = PlayerCollisionSound;
			audio.PlayOneShot(PlayerCollisionSound);	
			float differenceZ = theCollision.contacts[0].point.z - theCollision.collider.gameObject.transform.position.z;
			rigidbody.AddRelativeForce(new Vector3(0,0,differenceZ));
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
