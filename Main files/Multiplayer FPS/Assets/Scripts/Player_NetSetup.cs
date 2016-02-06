using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_NetSetup : NetworkBehaviour {

	[SerializeField] AudioListener audioListener;
	[SerializeField] Camera PlayerCam;

	// Use this for initialization
	void Start ()
	{
		if(isLocalPlayer)
		{
			Disable();
		}
	}

	void Disable()
	{
		PlayerCam.enabled = true;
		audioListener.enabled = true;
		GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
		GetComponent<CharacterController>().enabled = true;
	}
}