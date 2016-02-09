using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField] Behaviour[] DisabledComps;

	void Start ()
	{
		if (isLocalPlayer) 
		{
			Enable();
			for (int i = 0; 1 < DisabledComps.Length; i++)
			{
				DisabledComps [i].enabled = true;
			}
		}
	}

	void Enable()
	{
		GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
		GetComponent<CharacterController>().enabled = true;
	}
}