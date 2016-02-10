using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
	
	[SerializeField]
	private float thrusterForce = 1000f;

	private PlayerMotor motor;

	void Start ()
	{
		motor = GetComponent<PlayerMotor>();
	}
	
	//Calculate the thruster force based on player input.
	public void Jetpack ()
	{
		Vector3 _thrusterForce = Vector3.zero;
		//Apply thruster force
		if (Input.GetButton ("Jump")) 
		{
			_thrusterForce = Vector3.up * thrusterForce;
		}

		motor.Jetpack (_thrusterForce);
	}
}
