using Godot;
using System;

public partial class InteractionPromptLabel : Label
{
	public override void _Ready()
	{
		Visible = false;
	}

	public void ShowPrompt(string message)
	{
		Text = message;
		Visible = true;
	}

	public void HidePrompt()
	{
		Visible = false;
	}
}
