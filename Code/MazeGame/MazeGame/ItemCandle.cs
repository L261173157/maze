using Godot;
using System;

public partial class ItemCandle : PlayerTriggerArea
{
	//在地图上的蜡烛物品

	//背包UI节点
	public InventoryUI inventoryUI;
	protected override bool RequiresInteractKey => true;
	protected override string PromptText => "按确认键拾取蜡烛";

	public override void _Ready()
	{
		base._Ready();
		inventoryUI = GetParent().GetNode<InventoryUI>("CanvasLayer/Control/InventoryUI");
	}

	protected override void OnPlayerEntered(CharacterBody2d player)
	{
		GD.Print("Player entered candle area");
	}

	protected override void OnPlayerExited(CharacterBody2d player)
	{
		GD.Print("Player exited candle area");
	}

	protected override void OnPlayerTriggered(CharacterBody2d player)
	{
		CandleItem candleItem = new CandleItem();
		if (inventoryUI.inventory.AddItem(candleItem))
		{
			HideInteractionPrompt();
			QueueFree();
		}
	}
}
