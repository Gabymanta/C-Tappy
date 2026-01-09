using Godot;
using System;

public partial class Main : Control
{
	
	[Export] private Label _scoreLabel;

    public override void _UnhandledInput(InputEvent @event)
    {
		if (@event.IsActionPressed("play"))
		{
			GameManager.LoadScene(GameManager.SceneId.Loading);
		}
    }

    public override void _Ready()
    {
        _scoreLabel.Text = ScoreManager.Instance.HighScore.ToString("D4");
    }

}
