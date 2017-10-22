using UnityEngine;
using System.Collections;

public class Tank_AI : MonoBehaviour
{
	GameObject player;
	public float moveSpeed = 10;
	public float rotateSpeed = 30;
	public float turretSpeed = 50;
	public Transform firePoint;
	public GameObject bullet;
	public GameObject Turret;
	int Angle = 0;

	private Quaternion _lookRotation;
	private Vector3 _direction;

	void Start ()
	{	
		InvokeRepeating("Shoot", 2.0f, 0.5f);
	}

	void Update ()
	{		
		if (player == null) 
		{
			player = GameObject.FindWithTag("Player");
		}
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime,Space.Self);
		Angle = Random.Range (90, 180);
		_direction = (player.transform.position - Turret.transform.position).normalized;
		_lookRotation = Quaternion.LookRotation(_direction);
		Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, _lookRotation, Time.deltaTime * rotateSpeed);

		if (Physics.Raycast(this.gameObject.transform.position, transform.forward, 20)) 
		{
			float angle = Mathf.LerpAngle(0f, transform.eulerAngles.y - 90f, rotateSpeed * Time.time); 
			transform.eulerAngles = new Vector3(0, angle, 0); 
		}
	}

	/*public void RandomMove()
	{
		var lookPos = transform.position - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation(lookPos);
		rotation *= Quaternion.Euler(0, Angle, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
	}*/

	void Shoot()
	{		
		Instantiate (bullet, firePoint.position, firePoint.rotation);
	}
}

