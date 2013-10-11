using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {

	public float multiplier = .1f;
	
	Vector3 initialVelocity;
	public float initialXSpeed;
	public float initialZSpeed;
	public float minSpeed = 0;
	public float maxSpeed = 10;
	
	public float curSpeed = 0;
	
	public int m_powerUpType = 0;

	// Use this for initialization
	void Start () {
		gameObject.name = "powerUp";
		gameObject.layer = 9;
		
	}
	
	public void SetInitialVelocity(float initX, float initZ){
		initialVelocity = new Vector3(initX,0,initZ);
		initialVelocity.x = initX;
		initialVelocity.z = initZ;
		this.gameObject.rigidbody.AddRelativeForce(initialVelocity);
		Debug.Log("Initial Velocity:   " + initX + ":" + initZ);
	}
	
	void Update(){
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(rigidbody.velocity.x != 0){
			curSpeed = Vector3.Magnitude( rigidbody.velocity);
			
			Debug.Log("vel " + rigidbody.velocity.x + ":" + rigidbody.velocity.z);
			if(curSpeed > maxSpeed){
				rigidbody.velocity /= curSpeed / maxSpeed;
			}
			if(curSpeed < minSpeed && curSpeed > 0){
				rigidbody.velocity /= curSpeed / minSpeed;
			}
		}
		else{
			Debug.Log("Not working");
			initialVelocity = new Vector3(initialXSpeed,0,initialZSpeed);
			rigidbody.AddForce(initialVelocity);
			
		}
	}
	
	void OnCollisionEnter(Collision theCollision){
		
		rigidbody.velocity += rigidbody.velocity * multiplier;

		
		if(theCollision.collider.gameObject.name == "Player1"){	
			if(m_powerUpType == 1 || m_powerUpType == 2){
				theCollision.collider.gameObject.GetComponent<PlayerMovement>().OnPowerUpCollide(m_powerUpType);
			}
			else{
				
			}
			Destroy(this.gameObject);
		}
		if(theCollision.collider.gameObject.name == "Player2"){
			if(m_powerUpType == 1 || m_powerUpType == 2){
				theCollision.collider.gameObject.GetComponent<PlayerMovement>().OnPowerUpCollide(m_powerUpType);
			}
			else{
				
			}
			Destroy(this.gameObject);
		}
		
	}
}
