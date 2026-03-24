using Godot;
using System;

public partial class AppleGoal : PlayerTriggerArea
{
	[Signal]
	public delegate void GoalReachedEventHandler();

	protected override void OnPlayerTriggered(CharacterBody2d player)
	{
		EmitSignal(nameof(GoalReached));
	}
}
