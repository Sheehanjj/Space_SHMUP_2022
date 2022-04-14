﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	static public Hero S; // Singleton //
	
	[Header("Set in Inspector")]
	public float speed = 30;
	public float rollMult = -45;
	public float pitchMult = 30;
	
	[Header("Set Dynamically")]
	public float shieldLevel = 1;
	
	void Awake(){
		if (S==null){
			S = this;
		}
		else{
			Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	// Pull in information from the Input class
	float xAxis = Input.GetAxis("Horizontal"); // b
	float yAxis = Input.GetAxis("Vertical"); // b
	// Change transform.position based on the axes
	Vector3 pos = transform.position;
	pos.x += xAxis * speed * Time.deltaTime;
	pos.y += yAxis * speed * Time.deltaTime;
	transform.position = pos;
	// Rotate the ship to make it feel more dynamic // c
	transform.rotation = Quaternion.Euler(yAxis*pitchMult,xAxis*rollMult,0);
        
    }
}
