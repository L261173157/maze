using Godot;
using System;

public partial class MainMenu : Node2D
{
    public override void _Ready()
    {
        GetNode<Button>("VBoxContainer/StartGameButton").Pressed+= OnStartGamePressed;
        GetNode<Button>("VBoxContainer/EditMapButton").Pressed += OnEditMapPressed;
        GetNode<Button>("VBoxContainer/EditAlgorithmButton").Pressed += OnEditAlgorithmPressed;
        GetNode<Button>("VBoxContainer/QuitButton").Pressed += OnQuitPressed;
    }
    
    private void OnStartGamePressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/MazeGame.tscn");
    }

    private void OnEditMapPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/MazeEditor.tscn");
    }

    private void OnEditAlgorithmPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/AlgorithmEditor.tscn");
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();
    }
}
