using Godot;
using System;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Button btn2= GetNode("Button/Button2")as Button;
		btn2.Text="Doch klicken";
		GD.Print ("ready");
		khj();
	}
public void khj()
{
	int ja=GD.Hash("nö");
	GD.Print(ja);
}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
