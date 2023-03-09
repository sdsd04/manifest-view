using Godot;
using System;
using System.Collections.Generic;

public partial class plane_selector : Node2D
{
	 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        GD.Print("Ready");
        

        var airplaneList = new List<string>() { "A321 Neo cabin", "A320 cabin" };
        var config = GenerateSeatingConfig();

        //load the button template from the scene
        var tempButton = ResourceLoader.Load<PackedScene>("res://btn_host.tscn");

        //create 3 buttons and set the names
        for (int i = 1; i < 4; i++)
        {
            GD.Print(i);
            var btnInstance = tempButton.Instantiate<btn_host>();
            btnInstance.Position = new Vector2(10, i * 20);
            int num = btnInstance.GetChildCount();
            GD.Print("Instanz has children: " + num);
            //beware! The order in which we instantiate and set the name seems to be important
            AddChild(btnInstance);
            btnInstance.AirplaneName = "btn" + i;
            //subscribe all the button events to the same event handler
            btnInstance.Pressed += _on_dynamic_btn_pressed;

        }
    }

    private  Dictionary<string, List<Seat>> GenerateSeatingConfig()
    {
        var config = new Dictionary<string, List<Seat>>();
        var a321NeoSeats = new List<Seat>();
        for (int i = 0; i < 20; i++)
        {
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "A",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "B",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = false,
                Row = i,
                Column = "-",
                IsFloor = true
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "C",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "D",
                IsFloor = false
            });

        }
        var a320Seats = new List<Seat>();
        for (int i = 0; i < 30; i++)
        {
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "A",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "B",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "C",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = false,
                Row = i,
                Column = "-",
                IsFloor = true
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "D",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "E",
                IsFloor = false
            });
            a321NeoSeats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "F",
                IsFloor = false
            });

        }
        config.Add("A321 Neo cabin", a321NeoSeats);
        config.Add("A320 cabin", a320Seats);
		return config;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

	//Here is the button event handler
	public void _on_dynamic_btn_pressed(string name)
	{
		GD.Print("pressed "+name);
	}
	 
}



