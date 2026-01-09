using Godot;
using System;

public partial class Game : Node
{
	[Export] private PackedScene _pipesScene;
	[Export] private Timer _spawnPipeTimer;
	[Export] private Marker2D _upper;
	[Export] private Marker2D _lower;
	[Export] private Node _pipesHolder;

	public override void _Ready()
	{
		GetTree().Paused = false;
		_spawnPipeTimer.Timeout += SpawnPipes;

		SpawnPipes();
	}

	private void SpawnPipes()
	{
		float posY = (float)GD.RandRange(_upper.Position.Y, _lower.Position.Y);

		Pipes _pipes = _pipesScene.Instantiate<Pipes>();
		_pipes.Position = new Vector2(_upper.Position.X, posY);
		_pipesHolder.AddChild(_pipes);
	}
}
