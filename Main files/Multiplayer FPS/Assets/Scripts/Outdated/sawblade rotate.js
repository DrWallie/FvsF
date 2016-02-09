#pragma strict

var spinX : int = 0;
var spinY : int = 0;
var spinZ : int = 0;

function Update () 
{
	transform.Rotate(spinX, spinY, spinZ);
}