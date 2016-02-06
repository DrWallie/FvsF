using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
	public PlayerWeapon weapon;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask mask;

/*	void Start()
	{
		if(cam == null)
		{
			Debug.LogError("PlayerShoot : No camera referenced")
		}
	}*/

	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Rayc();
		}
	}

	void Rayc()
	{
		RaycastHit _hit;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
		{
			//We hit something
			Debug.Log("You've hit" + _hit.collider.name);
		}
	}
}