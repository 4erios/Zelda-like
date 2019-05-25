using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour {

	public static ParallaxManager instance;

	[System.NonSerialized]
	public Transform player;

	[System.NonSerialized]
	public Vector2 progress;

	[System.NonSerialized]
	public Vector3 playerStartPos;

	// Use this for initialization
	void Awake () {
		player = transform;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		progress.x = (player.position - playerStartPos).x; 
		progress.y = (player.position - playerStartPos).y; 
	}
}
