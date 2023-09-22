using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerBehavior : BaseBehavior
{
	[SerializeField] private PlayerSetBehavior setter;
	private void Awake()
	{
		setter = GetComponent<PlayerSetBehavior>();
	}
	public override void Enter()
	{
		if (setter.Behavior == PlayerSetBehavior.Behaviors.WalkSide || setter.Behavior == PlayerSetBehavior.Behaviors.IdleSide)
		{
			setter.Behavior = PlayerSetBehavior.Behaviors.AttackSide;
		}
		if (setter.Behavior == PlayerSetBehavior.Behaviors.WalkUp || setter.Behavior == PlayerSetBehavior.Behaviors.IdleUp)
		{
			setter.Behavior = PlayerSetBehavior.Behaviors.AttackUp;
		}
		if (setter.Behavior == PlayerSetBehavior.Behaviors.WalkDown || setter.Behavior == PlayerSetBehavior.Behaviors.IdleDown)
		{
			setter.Behavior = PlayerSetBehavior.Behaviors.AttackDown;
		}
	}

	
}
