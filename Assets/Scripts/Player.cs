using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public enum Behaviour
	{
		HUMAN,
		REMOTE
	};
	public Behaviour behaviour;
	public enum Scelta
	{
		ATTESA,
		ALTA,
		BASSA
	};
	public Scelta scelta = Scelta.ATTESA;
	
}
