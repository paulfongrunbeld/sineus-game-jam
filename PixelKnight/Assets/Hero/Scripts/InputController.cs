using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private PlayerSetBehavior setter;

	private void Awake()
	{ 
		setter = GetComponent<PlayerSetBehavior>();
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			setter.SetBehaviorAttack();
		}
	}
}
