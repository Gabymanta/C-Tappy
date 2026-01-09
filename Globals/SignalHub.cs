using Godot;
using System;

public partial class SignalHub : Node
{
	public static SignalHub Instance {get; private set;}

	[Signal] public delegate void OnPlaneDiedEventHandler();
	[Signal] public delegate void OnScoredEventHandler();

    public override void _Ready()
    {
        Instance = this;
    }

	public static void EmitOnPlaneDied()
	{
		Instance.EmitSignal(SignalName.OnPlaneDied);
	}

	public static void EmitOnScored()
	{
		Instance.EmitSignal(SignalName.OnScored);
	}

}
