using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;

	void FixedUpdate() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePos,Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z); // to prevent skewing into/out of screen
		rigidbody2D.angularVelocity = 0; 

		//float input = Input.GetAxis("Vertical");
		rigidbody2D.AddForce(gameObject.transform.up * speed);// * input);
	}
}
