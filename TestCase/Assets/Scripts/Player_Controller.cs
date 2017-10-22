using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	public float moveSpeed = 10;
	public float rotateSpeed = 30;
	public float turretSpeed = 50;
	public Transform firePoint;
	public GameObject bullet;
	public GameObject Turret;
	public GameObject hpBar;

	void Start () 
	{
		hpBar = GameObject.FindGameObjectWithTag ("HPBar");
	}

	void Update () 
	{
		hpBar.GetComponent<Text>().text = "HP: " + this.gameObject.GetComponent<HP> ().hp;
		if (Input.GetKey("up")) 
		{
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime,Space.Self);
		}

		if (Input.GetKey("down")) 
		{
			transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime,Space.Self);
		}

		if (Input.GetKey("left")) 
		{
			transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.World);
		}
		if (Input.GetKey("right")) 
		{
			transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
		}

		if (Input.GetButtonDown("Fire1")) 
		{
			Instantiate (bullet, firePoint.position, firePoint.rotation);
		}

		float TurretRotate = Time.deltaTime * turretSpeed * Input.GetAxis ("Mouse X");
		Turret.transform.Rotate (0, TurretRotate, 0);
	}
}
