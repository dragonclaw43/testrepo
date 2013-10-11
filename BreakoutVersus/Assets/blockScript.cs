using UnityEngine;
using System.Collections;

public class blockScript : MonoBehaviour {
	public int m_hitsLeft = 1;
	public Color texture;
	
	int puLONG 		=1;
	int puSHORT 	=2;
	int puMAGNET 	=3;
	int puSPEEDUP 	=4;
	int puSPEEDDOWN =5;
	int puSTICK 	=6;
	
	public Texture tex1;
	public Texture tex2;
	public Texture tex3;
	public Texture tex4;
	public Texture tex5;
	
	public int m_powerUpType;
	
	public GameObject wreck;
	
	// Use this for initialization
	void Start () {
		texture =this.gameObject.renderer.material.GetColor("_Color");
		
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.Rotate(new Vector3((float).3,(float).4,(float).5));
	}
	
	void OnCollisionEnter(Collision theCollision){
		if(theCollision.collider.gameObject.name != "powerUp"){
			if(m_hitsLeft > 0){
				m_hitsLeft--;
				switch(m_hitsLeft){
					case 1:
						if(tex5 != null){
							this.gameObject.renderer.material.SetTexture("_BumpMap",tex5);
						}
						break;
					case 2:
						if(tex4 != null){
							this.gameObject.renderer.material.SetTexture("_BumpMap",tex4);
						}
						break;
					case 3:
						if(tex3 != null){
							this.gameObject.renderer.material.SetTexture("_BumpMap",tex3);
						}
						break;
					case 4:
						if(tex2 != null){
							this.gameObject.renderer.material.SetTexture("_BumpMap",tex2);
						}
						break;
				}
			}
			if(m_hitsLeft == 0){
				
				Vector3 position = transform.position;
				Quaternion rotation = new Quaternion();
				this.gameObject.transform.Translate(new Vector3(0,0,20));
				Destroy(this.gameObject);
				
				if(m_powerUpType!= 0){
					GameObject wreckClone = (GameObject) Instantiate(wreck, position, rotation);
					wreckClone.GetComponent<powerUp>().initialXSpeed = theCollision.collider.gameObject.rigidbody.velocity.x;
					wreckClone.GetComponent<powerUp>().initialZSpeed = 	theCollision.collider.gameObject.rigidbody.velocity.z;
					wreckClone.GetComponent<powerUp>().m_powerUpType = m_powerUpType;
					
						//.SetInitialVelocity(theCollision.collider.gameObject.rigidbody.velocity.x/2,-theCollision.collider.gameObject.rigidbody.velocity.z/2);
					
				}
			}
		}
	}
}
