using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {

	public float multiplier = .1f;
	
	Vector3 initialVelocity;
	public float initialXSpeed;
	public float initialZSpeed;
	public float minSpeed = 0;
	public float maxSpeed = 10;
	
	//int puLONG 		=1;
	//int puSHORT 		=2;
	//int puMAGNET 		=3;
	//int puSPEEDUP 	=4;
	//int puSPEEDDOWN 	=5;
	//int puSTICK 		=6;
	
	public float curSpeed = 0;
	
	public int m_powerUpType = 0;
	
	public Material mat_puLONGER;
	public Material mat_puSHORTER;
	public Material mat_puMAGNET;
	public Material mat_puFASTER;
	public Material mat_puSLOWER;
	public Material mat_puSTICK;
	
	// Use this for initialization
	void Start () {
		gameObject.name = "powerUp";
		gameObject.layer = 9;
		
		switch(m_powerUpType){
			case 1:
			renderer.material = mat_puLONGER;
			break;
			
			case 2:
			renderer.material = mat_puSHORTER;
			break;
			
			case 3:
			renderer.material = mat_puMAGNET;
			break;
			
			case 4:
			renderer.material = mat_puFASTER;
			break;
			
			case 5:
			renderer.material = mat_puSLOWER;
			break;
			
			case 6:
			renderer.material = mat_puSTICK;
			break;
		}
	}
	
	public void SetInitialVelocity(float initX, float initZ){
		initialVelocity = new Vector3(initX,0,initZ);
		initialVelocity.x = initX;
		initialVelocity.z = initZ;
		this.gameObject.rigidbody.AddRelativeForce(initialVelocity);
	}
	
	void Update(){
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(rigidbody.velocity.x != 0){
			curSpeed = Vector3.Magnitude( rigidbody.velocity);

			if(curSpeed > maxSpeed){
				rigidbody.velocity /= curSpeed / maxSpeed;
			}
			if(curSpeed < minSpeed && curSpeed > 0){
				rigidbody.velocity /= curSpeed / minSpeed;
			}
		}
		else{
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
				GameObject m_ball1 = GameObject.Find("Ball1");
				m_ball1.GetComponent<BallMovement>().OnPowerUpCollide(m_powerUpType,1);
				GameObject m_ball2 = GameObject.Find("Ball2");
				m_ball2.GetComponent<BallMovement>().OnPowerUpCollide(m_powerUpType,1);
			}
			Destroy(this.gameObject);
		}
		if(theCollision.collider.gameObject.name == "Player2"){
			if(m_powerUpType == 1 || m_powerUpType == 2){
				theCollision.collider.gameObject.GetComponent<PlayerMovement>().OnPowerUpCollide(m_powerUpType);
			}
			else{
				GameObject m_ball1 = GameObject.Find("Ball1");
				m_ball1.GetComponent<BallMovement>().OnPowerUpCollide(m_powerUpType,2);
				GameObject m_ball2 = GameObject.Find("Ball2");
				m_ball2.GetComponent<BallMovement>().OnPowerUpCollide(m_powerUpType,2);
			}
			Destroy(this.gameObject);
		}
		
	}
}
