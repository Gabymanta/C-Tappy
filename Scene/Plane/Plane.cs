using Godot;
using System;

public partial class Plane : CharacterBody2D
{

	//[Export] private AnimatedSprite2D _planeAnimatedSprite;
	[Export] private AnimationPlayer _planeAnimationPlayer;
	[Export] private AudioStreamPlayer2D _sound;

	private const int POWER_JUMP = -350;

	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _PhysicsProcess(double delta)
    {
        Fly(delta);
		MoveAndSlide();

		if(IsOnFloor() || IsOnCeiling())
		{
			Die();
		}
    }

	private void Fly(double delta)
	{
		Vector2 newVelocity = Velocity;
		newVelocity.Y += _gravity * (float)delta;

		if (Input.IsActionJustPressed("jump"))
		{
			newVelocity.Y = POWER_JUMP;
			_planeAnimationPlayer.Play("thrust");			
		}

		Velocity = newVelocity;
	}

	public void Die()
	{
		SignalHub.EmitOnPlaneDied();
		GetTree().Paused = true;
	}

}
