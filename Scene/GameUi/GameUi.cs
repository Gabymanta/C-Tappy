using Godot;
using System;

public partial class GameUi : Control
{

	[Export] private VBoxContainer _vb;
	[Export] private AnimationPlayer _animPress;
	[Export] private Label _scoreLabel;
	[Export] private AudioStreamPlayer2D _sound;
	[Export] private Timer _timerGameOver;
 
	private bool _is_gameOver = false;
	private int _score = 0;

	public override void _UnhandledInput(InputEvent @event)
    {
		if (@event.IsActionPressed("exit"))
		{
			GameManager.LoadScene(GameManager.SceneId.Menu);
		}
		
		if (@event.IsActionPressed("play") && _is_gameOver)
		{
			GameManager.LoadScene(GameManager.SceneId.Menu);
		}
		
		if (@event.IsActionPressed("pause") )
		{
			GetTree().Paused = !GetTree().Paused;
		}
    }

    public override void _Ready()
    {
        _vb.Hide();
		_scoreLabel.Text = _score.ToString("D3");

		SignalHub.Instance.OnPlaneDied += GameOver;
		SignalHub.Instance.OnScored += OnScored;
		_timerGameOver.Timeout += SetIsGameOver;

    }

    public override void _ExitTree()
    {
        SignalHub.Instance.OnPlaneDied -= GameOver;
		SignalHub.Instance.OnScored -= OnScored;
    }

	private void SetIsGameOver()
	{
		_is_gameOver = true;
	}

	private void GameOver()
	{
		_timerGameOver.Start();
		_vb.Show();
		_animPress.Play("flash");
		_sound.Play();
	}

	private void OnScored()
	{
		_score ++;
		_scoreLabel.Text = _score.ToString("D3");
		ScoreManager.Instance.HighScore = _score;
	}


}
