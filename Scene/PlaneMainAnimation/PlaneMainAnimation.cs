using Godot;
using System;

public partial class PlaneMainAnimation : Node2D
{
	private const float SPEED_MAX = 100.0f;
	private const float SPEED_MIN = 50.0f;

	[Export] private AnimatedSprite2D _planeSprite;
	[Export] private Timer _dispawn;

	public override void _Ready()
	{
		_dispawn.Timeout += Die;
	}

    public override void _PhysicsProcess(double delta)
    {
        Vector2 positonPlane = this.Position;
		positonPlane.X += (float)GD.RandRange(SPEED_MIN,SPEED_MAX) * (float)delta ;
		this.Position = positonPlane;
    }

	
    private void Die()
    {
        this.QueueFree();
    }
}
