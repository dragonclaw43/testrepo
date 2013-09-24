using UnityEngine;
using System.Collections;

public class blockScript : MonoBehaviour {
	public int m_hitsLeft = 1;
	public Color texture;
	// Use this for initialization
	void Start () {
		texture =this.gameObject.renderer.material.GetColor("_Color");
		//this.gameObject.renderer.material.SetTexture("_MainTex",texture);
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.Rotate(new Vector3((float).3,(float).4,(float).5));
	}
	
	void OnCollisionEnter(Collision theCollision){
		if(m_hitsLeft > 0){
			m_hitsLeft--;
			texture.r = texture.r+(1-texture.r/m_hitsLeft);
			texture.g = texture.g+(1-texture.g/m_hitsLeft);
			texture.b = texture.b+(1-texture.b/m_hitsLeft);
			this.gameObject.renderer.material.SetColor("_Color",texture);
		}
		if(m_hitsLeft == 0){
			Destroy(this.gameObject);
		}
	}
}
