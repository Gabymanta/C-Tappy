using Godot;
using System;
using System.Threading.Tasks;

public partial class SimpleChange : Control
{
	public override async void _Ready()
	{
		await ToSignal(GetTree().CreateTimer(2.0), Timer.SignalName.Timeout);
		GameManager.LoadScene(GameManager.SceneId.Game);
	}
}
