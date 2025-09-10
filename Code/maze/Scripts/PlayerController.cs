using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
    [Export] public float MoveSpeed = 120f;   // 像素/秒

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if (Input.IsActionPressed("move_up"))
            velocity.Y -= 1;
        if (Input.IsActionPressed("move_down"))
            velocity.Y += 1;
        if (Input.IsActionPressed("move_left"))
            velocity.X -= 1;
        if (Input.IsActionPressed("move_right"))
            velocity.X += 1;

        velocity = velocity.Normalized() * MoveSpeed;

        Velocity = velocity;
        MoveAndSlide();
    }
}
