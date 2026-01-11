using Godot;
using System;

public partial class Main : Control
{
	private const float MARGE = 50.0f;
	private const float POS_X = -50.0f;

	[Export] private Label _scoreLabel;
    [Export] private PackedScene _planeAnimation;
    [Export] private Node _holderPlanes;
    [Export] private Timer _spawnerPlane;


    public override void _UnhandledInput(InputEvent @event)
    {
		if (@event.IsActionPressed("play"))
		{
			GameManager.LoadScene(GameManager.SceneId.Loading);
		}
    }

    public override void _Ready()
    {
        _spawnerPlane.Timeout += InstantiatePlane;
        _scoreLabel.Text = ScoreManager.Instance.HighScore.ToString("D4");
        InstantiatePlane();
    }

    private void InstantiatePlane()
    {
        PlaneMainAnimation planeMain = _planeAnimation.Instantiate<PlaneMainAnimation>();
        planeMain.Position = RandomPosition();
        _holderPlanes.AddChild(planeMain);
    }

    private Vector2 RandomPosition()
    {
        Rect2 rect = GetViewportRect();
        float posY = (float)GD.RandRange(rect.Position.Y + MARGE, rect.End.Y - MARGE) ; 
        return new Vector2(POS_X, posY);
    }
}
