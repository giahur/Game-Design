﻿using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;


	void Start() {

		_enemy = Instantiate(enemyPrefab) as GameObject;
		_enemy.transform.position = new Vector3(0, 0, 0);
		float angle = Random.Range(0, 360);
		_enemy.transform.Rotate(0, angle, 0);
	}
	
	void Update() {
	
	}
}
