using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	private Vector3 thrusterForce = Vector3.zero;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}
	

	//Get a force vector for the Jetpack
	public void Jetpack (Vector3 _thrusterForce)
	{
		thrusterForce = _thrusterForce;
	}

	//Run every physics iteration
	void FixedUpdate ()
	{
		PerformMovement ();
	}

	//Perform movement based on velocity variable
	void PerformMovement()
	{
		if (thrusterForce != Vector3.zero) 
		{
			rb.AddForce(thrusterForce * Time.deltaTime, ForceMode.Acceleration);
		}
	}
}
