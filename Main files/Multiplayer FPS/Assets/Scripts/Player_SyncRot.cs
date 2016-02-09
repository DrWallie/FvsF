using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_SyncRot :  NetworkBehaviour
{

	[SyncVar] private Quaternion syncPlayerRotation;
	[SyncVar] private Quaternion syncCamRotation;

	[SerializeField] private Transform playerTransform;
	[SerializeField] private Transform camTransform;
	[SerializeField] private float lerpRate = 15;

	void FIxedUpdate()
	{
		//laat elke frame deze twee voids runnen.
		TransmitRotations();
		LerpRotation();
	}

	void LerpRotation()
	{
		//als het een geconnecte player is dan word zijn rotation van zijn en cam en zijn caracter zelf tussen de huidige en de laatste sync ge lerpt (lerpen houd in dat je het object smooth tussen twee coordinaten laat bewegen).
		if(!isLocalPlayer)
		{
			playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, syncPlayerRotation, Time.deltaTime * lerpRate);
			camTransform.rotation = Quaternion.Lerp(camTransform.rotation, syncCamRotation, Time.deltaTime * lerpRate);
		}
	}

	//dit stuurt  de rotation van je players zijn caracter naar de server
	[Command]
	void CmdProvideRotationsToServer (Quaternion playerRot, Quaternion camRot)
	{
		syncPlayerRotation = playerRot;
		syncCamRotation = camRot;
	}

	//dit transmit de huidige rotation van de player naar de command's void die dit naar de sever stuurt, dit word de nieuwe sync. 
	[Client]
	void TransmitRotations()
	{
		if(isLocalPlayer)
		{
			CmdProvideRotationsToServer(playerTransform.rotation, camTransform.rotation);
		}
	}
}