using Godot;
using System;

public partial class Item1Btn : Button
{
	private string shortcutAction = "";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shortcutAction = Name.ToString() switch
		{
			"Item1Btn" => "ui_inventory_1",
			"Item2Btn" => "ui_inventory_2",
			"Item3Btn" => "ui_inventory_3",
			_ => ""
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//接受按键
		if(!string.IsNullOrEmpty(shortcutAction) && Input.IsActionJustPressed(shortcutAction))
		{
			EmitSignal("pressed");
		}
	}
}
