using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class HealthAndStats : MonoBehaviour {

	public float currentHp, maxHp;
	public Image healthImage;
	// Use this for initialization
	void Start () {
		currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		healthImage.fillAmount =  currentHp / maxHp;
	}
	void OnTriggerEnter2D (Collider2D collider){
		if (collider.tag == "enemy") {
			currentHp -= collider.GetComponent<EnemyController> ().damageOnCollision;
		}
	}
}
