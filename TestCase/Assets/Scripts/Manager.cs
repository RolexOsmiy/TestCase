using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public Text playerText;
	public static int playerScore = 0;
	public Text enemyText;
	public static int enemyScore = 0;
	public Transform[] spawnPoints;
	public static bool isPlayer;
	public GameObject enemy;
	public GameObject player;
	public static bool spawn = false;

	void Start () 
	{
		
	}

	void Update () 
	{
		enemyText.text = "Enemy has " + enemyScore + " Deaths";
		playerText.text = "Player has " + playerScore + " Deaths";
		if (spawn == true) 
		{
			Respawn ();
			spawn = false;
		}
	}

	public void Respawn()
	{
		if (isPlayer == true) 
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (player, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		} else 
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
	}
}
