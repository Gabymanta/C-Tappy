using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
	public enum SceneId{
		Menu,
		Game,
		Loading
	}

	public static GameManager Instance {get; private set;}

	private PackedScene _gameScene = GD.Load<PackedScene>("res://Scene/Game/Game.tscn");
	private PackedScene _menuScene = GD.Load<PackedScene>("res://Scene/Main/Main.tscn");
	private PackedScene _simpleChangeScene = GD.Load<PackedScene>("res://Scene/Changes/SimpleChange.tscn");
	private PackedScene _complexChangeScene = GD.Load<PackedScene>("res://Scene/Changes/ComplexChange.tscn");

	private PackedScene _nextScene;
	private ComplexChange _complexChange;
	private Dictionary<SceneId, PackedScene> _scenes;
	

	public PackedScene NextScene
	{
		get{return _nextScene;}
		set{_nextScene = value;}
	}

    public override void _Ready()
    {
        Instance = this;
		_scenes = new()
		{
			{ SceneId.Menu, _menuScene },
			{ SceneId.Game, _gameScene },
			{ SceneId.Loading, _simpleChangeScene },
		};

		_complexChange = _complexChangeScene.Instantiate<ComplexChange>();
		AddChild(_complexChange);
    }

	public static void LoadNextScene()
	{
		if(Instance.NextScene != null)
		{
			Instance.GetTree().ChangeSceneToPacked(Instance.NextScene);
		}
	}
	
	public static void LoadScene(SceneId sceneId)
	{
		Instance.StartChange(Instance._scenes[sceneId]);
	}

	private void StartChange(PackedScene toScene)
	{
		_nextScene = toScene;
		_complexChange.PlayAnimation();
	}
}
