using Godot;
using System;

public abstract partial class PlayerTriggerArea : Area2D
{
	protected CharacterBody2d CurrentPlayer { get; private set; }
	private InteractionPromptLabel interactionPrompt;

	protected virtual bool RequiresInteractKey => false;
	protected virtual string InteractAction => "ui_accept";
	protected virtual string PromptText => "按确认键交互";

	public override void _Ready()
	{
		BodyEntered += HandleBodyEntered;
		BodyExited += HandleBodyExited;
		interactionPrompt = GetParent().GetNodeOrNull<InteractionPromptLabel>("CanvasLayer/Control/InteractionPrompt");
	}

	public override void _Process(double delta)
	{
		if (!RequiresInteractKey || CurrentPlayer == null)
		{
			return;
		}

		if (Input.IsActionJustPressed(InteractAction))
		{
			OnPlayerTriggered(CurrentPlayer);
		}
	}

	private void HandleBodyEntered(Node2D body)
	{
		if (body is not CharacterBody2d player)
		{
			return;
		}

		CurrentPlayer = player;
		OnPlayerEntered(player);

		if (RequiresInteractKey)
		{
			ShowInteractionPrompt();
		}
		else
		{
			OnPlayerTriggered(player);
		}
	}

	private void HandleBodyExited(Node2D body)
	{
		if (body is not CharacterBody2d player || CurrentPlayer != player)
		{
			return;
		}

		OnPlayerExited(player);
		HideInteractionPrompt();
		CurrentPlayer = null;
	}

	protected virtual void OnPlayerEntered(CharacterBody2d player)
	{
	}

	protected virtual void OnPlayerExited(CharacterBody2d player)
	{
	}

	protected void HideInteractionPrompt()
	{
		interactionPrompt?.HidePrompt();
	}

	private void ShowInteractionPrompt()
	{
		interactionPrompt?.ShowPrompt(PromptText);
	}

	protected abstract void OnPlayerTriggered(CharacterBody2d player);
}
