using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int Damage = 10;
	public float bulletSpeed = 30;

	void Start () 
	{
		StartCoroutine (BulletLife());
	}

	void Update () 
	{
		transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime,Space.Self);
	}

	void OnCollisionEnter(Collision col) 
	{
		if (col.gameObject.tag == "Enemy") 
		{
			col.gameObject.GetComponent<HP> ().Damage (Damage);
			Destroy (this.gameObject);
		}
		else if (col.gameObject.tag == "Player") 
		{
			col.gameObject.GetComponent<HP> ().Damage (Damage);
			Destroy (this.gameObject);
		}
		Destroy (this.gameObject);
	}

	IEnumerator BulletLife()
	{		
		yield return new WaitForSeconds(5);
		Destroy (this.gameObject);
	}
		
}
