using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HP : MonoBehaviour {

	public int hp = 100;


	void Start () 
	{		
		
	}

	void Update () 
	{
		if (hp < 1) 
		{
			if (this.gameObject.tag == "Enemy") 
			{
				Manager.enemyScore++;
				Manager.isPlayer = false;
				Manager.spawn = true;
				Destroy (this.gameObject);
			} 
			else if (this.gameObject.tag == "Player") 
			{
				Manager.playerScore++;
				Manager.isPlayer = true;
				Manager.spawn = true;
				Destroy (this.gameObject);
			}

		}
	}

	public void Damage(int damage)
	{
		hp -= damage;
	}


}
