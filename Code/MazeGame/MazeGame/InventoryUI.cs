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
	}

	
	/// <summary>
	/// 每帧更新物品栏UI显示
	/// 根据物品栏中的物品数量和类型更新按钮的图标和数量文本
	/// </summary>
	public override void _Process(double delta)
	{
		// 更新物品按钮1的显示
		if(inventory.Items1.Count > 0)
		{
			// 显示第一个物品的图标和数量
			itemButton1.Icon = inventory.Items1[0].Icon;
			itemButton1.Text = inventory.Items1.Count.ToString();
		}
		else
		{
			// 物品栏为空，显示空物品图标
			itemButton1.Icon = emptyIcon;
			itemButton1.Text = "";
		}
		
		// 更新物品按钮2的显示
		if(inventory.Items2.Count > 0)
		{
			// 显示第一个物品的图标和数量
			itemButton2.Icon = inventory.Items2[0].Icon;
			itemButton2.Text = inventory.Items2.Count.ToString();
		}
		else
		{
			// 物品栏为空，显示空物品图标
			itemButton2.Icon = emptyIcon;
			itemButton2.Text = "";
		}
		
		// 更新物品按钮3的显示
		if(inventory.Items3.Count > 0)
		{
			// 显示第一个物品的图标和数量
			itemButton3.Icon = inventory.Items3[0].Icon;
			itemButton3.Text = inventory.Items3.Count.ToString();	
		}
		else
		{
			// 物品栏为空，显示空物品图标
			itemButton3.Icon = emptyIcon;
			itemButton3.Text = "";
		}
	}

	/// <summary>
	/// 处理物品按钮按下事件，使用指定栏位的物品
	/// </summary>
	/// <param name="index">物品栏的索引 (1, 2, 或 3)</param>
	public void OnItemButtonPressed(int index)
	{
		switch(index)
		{
			case 1:
				// 使用物品栏1中的物品
				if(inventory.Items1.Count > 0)
				{
					// 检查物品是否实现了IItemFunction接口
					if(inventory.Items1[0] is IItemFunction itemFunction)
					{
						// 执行物品的使用效果
						itemFunction.Use();
						// 从物品栏中移除该物品
						inventory.Items1.RemoveAt(0);
					}
				}
				break;
			case 2:
				// 使用物品栏2中的物品
				if(inventory.Items2.Count > 0)
				{
					// 检查物品是否实现了IItemFunction接口
					if(inventory.Items2[0] is IItemFunction itemFunction)
					{
						// 执行物品的使用效果
						itemFunction.Use();
						// 从物品栏中移除该物品
						inventory.Items2.RemoveAt(0);
					}
				}
				break;
			case 3:
				// 使用物品栏3中的物品
				if(inventory.Items3.Count > 0)
				{
					// 检查物品是否实现了IItemFunction接口
					if(inventory.Items3[0] is IItemFunction itemFunction)
					{
						// 执行物品的使用效果
						itemFunction.Use();
						// 从物品栏中移除该物品
						inventory.Items3.RemoveAt(0);
					}
				}
				break;
			default:
				break;
		}
	}

	/// <summary>
	/// 清空物品栏中的所有物品
	/// </summary>
	public void ClearInventory()
	{
		// 清空所有三个物品栏
		inventory.Items1.Clear();
		inventory.Items2.Clear();
		inventory.Items3.Clear();
	}
}
