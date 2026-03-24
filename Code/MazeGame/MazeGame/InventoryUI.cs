using Godot;
using System;

/// <summary>
/// 物品栏UI管理器
/// 负责显示和管理物品栏中的物品，包括更新UI显示和处理物品使用
/// </summary>
public partial class InventoryUI : GridContainer
{
	/// <summary>
	/// 物品按钮1 - 显示第一个物品栏中的物品
	/// </summary>
	public Button itemButton1;
	/// <summary>
	/// 物品按钮2 - 显示第二个物品栏中的物品
	/// </summary>
	public Button itemButton2;
	/// <summary>
	/// 物品按钮3 - 显示第三个物品栏中的物品
	/// </summary>
	public Button itemButton3;
	
	/// <summary>
	/// 物品栏实例，管理所有物品
	/// </summary>
	public Inventory inventory;

	/// <summary>
	/// 空物品栏的显示图标
	/// </summary>
	public Texture2D emptyIcon;
	
	/// <summary>
	/// 初始化UI，获取所有按钮节点和空物品图标
	/// </summary>
	public override void _Ready()
	{
		// 从场景树中获取三个物品按钮
		itemButton1 = GetNode<Button>("Item1Btn");
		itemButton2 = GetNode<Button>("Item2Btn");
		itemButton3 = GetNode<Button>("Item3Btn");
		
		// 加载空物品栏的显示图标
		emptyIcon = GD.Load<Texture2D>("res://MazeGame/asset/noneItem.png");
		
		// 创建物品栏实例
		inventory = new Inventory();
		inventory.Changed += RefreshUI;
		RefreshUI();
	}

	/// <summary>
	/// 根据物品栏中的物品数量和类型更新按钮的图标和数量文本
	/// </summary>
	public void RefreshUI()
	{
		UpdateButton(itemButton1, inventory.Items1);
		UpdateButton(itemButton2, inventory.Items2);
		UpdateButton(itemButton3, inventory.Items3);
	}

	/// <summary>
	/// 处理物品按钮按下事件，使用指定栏位的物品
	/// </summary>
	/// <param name="index">物品栏的索引 (1, 2, 或 3)</param>
	public void OnItemButtonPressed(int index)
	{
		var items = inventory.GetSlotItems(index);
		if (items == null || items.Count == 0)
		{
			return;
		}

		if(items[0] is IItemFunction itemFunction)
		{
			itemFunction.Use();
			inventory.ConsumeItem(index);
		}
	}

	/// <summary>
	/// 清空物品栏中的所有物品
	/// </summary>
	public void ClearInventory()
	{
		inventory.Clear();
	}

	public override void _ExitTree()
	{
		if (inventory != null)
		{
			inventory.Changed -= RefreshUI;
		}
	}

	private void UpdateButton(Button button, System.Collections.Generic.List<ItemData> items)
	{
		if(items.Count > 0)
		{
			button.Icon = items[0].Icon;
			button.Text = items.Count.ToString();
			return;
		}

		button.Icon = emptyIcon;
		button.Text = "";
	}
}
