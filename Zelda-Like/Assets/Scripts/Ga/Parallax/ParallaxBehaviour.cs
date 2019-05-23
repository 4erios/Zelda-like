using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour {

	[System.NonSerialized]
	public Transform self;

	public Vector2 speed = Vector2.one * 0.1f;

	[System.NonSerialized]
	public Vector3 startPos;

	ParallaxManager parallax;

	void Start () {
		parallax = ParallaxManager.instance;
		self = transform;
		startPos = self.position;
	}
	
	void Update () {
		self.position = startPos + Vector3.left * parallax.progress.x * speed.x + Vector3.down * parallax.progress.y * speed.y;
	}
}
