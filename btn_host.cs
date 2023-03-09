using Godot;
using System;

//it seems that in godot 4 in c# the parameter for the existing events are not yet supported
//so we wrap a standard button in a custom control and passing the event further
public partial class btn_host : Control
{
	//name of the custom button:
	public string AirplaneName { 
		//use this get/set syntax to interact with other objects
		get{ return _btn.Text; }
		//variable value is what passed automatically when you set AirplaneName variable from outside
		set{ _btn.Text=value; } 
	}

	//hidden private reference to an actual button
	 private Button _btn;
	
	//For passing the custom button name to the parent we need to trick it with custom signals
	[Signal]
	public delegate void PressedEventHandler(string name);

 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("test");
		int childNumbers = GetChildCount();
		GD.Print("child num" + childNumbers);
		_btn = GetChild<Button>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	//pass the button_pressed event from the child button to the custom signal adding the button name as a parameter
	public void _on_button_pressed()
	{
		EmitSignal(nameof(Pressed), AirplaneName);
	}
}
