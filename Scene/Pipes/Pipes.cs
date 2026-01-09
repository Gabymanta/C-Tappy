using Godot;
using System;

public partial class Pipes : Node2D
{
	[Export] private VisibleOnScreenNotifier2D _visibleScreen;
	[Export] private Timer _timer;
	[Export] private Area2D _upperPipe;
	[Export] private Area2D _lowerPipe;
	[Export] private Area2D _laser;
	[Export] private AudioStreamPlayer _sound;

	private const float SPEED = 120.0f;
	private bool _isActiveLaser = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_visibleScreen.ScreenExited += DestroyPipe;
		_timer.Timeout += DestroyPipe;
		_upperPipe.BodyEntered += OnBodyEnter;
		_lowerPipe.BodyEntered += OnBodyEnter;
		_laser.BodyExited += OnLaserBodyExited;
		SignalHub.Instance.OnPlaneDied += OnTappyDied;
	}
	
	public override void _ExitTree()
	{
		SignalHub.Instance.OnPlaneDied -= OnTappyDied;
	}

    public override void _PhysicsProcess(double delta)
    {
        this.Position -= new Vector2(SPEED * (float)delta, 0);
    }

	private void DestroyPipe()
	{
		this.QueueFree();
	}

	private void OnBodyEnter(Node2D body)
	{
		if(body is Plane)
		{
			(body as Plane).Die();
		}
	}

	private void DisconnectLaser()
	{
		//if(_laser.IsConnected(Area2D.SignalName.BodyExited, Callable.From<Pipes>(OnLaserBodyExited)))
		if (_isActiveLaser)
		{
			_laser.BodyExited -= OnLaserBodyExited;
			_isActiveLaser = false;
		}
	}

	 private void OnTappyDied()
    {
        DisconnectLaser();
    }

	private void OnLaserBodyExited(Node2D body)
	{
		if(body is Plane)
		{
			_sound.Play();
			SignalHub.EmitOnScored();
			DisconnectLaser();
		}
	}
}