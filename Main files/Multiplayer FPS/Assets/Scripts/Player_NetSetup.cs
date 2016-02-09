using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_NetSetup : NetworkBehaviour {

	[SerializeField] AudioListener audioListener;
	[SerializeField] Camera PlayerCam;

	[SerializeField] string remoteLayerName = "RemotePlayer";

	void Start ()
	{
		if(!isLocalPlayer)
		{
			Enable();
			AssignRemoteLayer();
		}

		RegisterPlayer();
	}

	void RegisterPlayer()
	{
		string _ID = "Player  " + GetComponent<NetworkIdentity>().netId;
		transform.name = _ID;
	}

	void AssignRemoteLayer ()
	{
		gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
	}

	void Enable ()
	{
		PlayerCam.enabled = false;
		audioListener.enabled = false;
		GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
		GetComponent<CharacterController>().enabled = false;
	}
}