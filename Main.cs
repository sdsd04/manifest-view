using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node2D
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
        
        var seatcolumn = "A";
        var seatinglist = config["A320 cabin"];

        var meinmarker = GetNode<Marker2D>("Marker2D");
        Seatingloop(tempButton, seatcolumn, seatinglist, meinmarker);

    }

    private void Seatingloop(PackedScene tempButton, string seatcolumn, List<Seat> seatinglist, Marker2D meinmarker)
    {
        for (int i = 0; i < seatinglist.Count; i++)
        {
            var currentseat = seatinglist[i];

            GD.Print(currentseat);

            if (currentseat.Column == seatcolumn)
            {
                var btnInstance = tempButton.Instantiate<btn_host>();
                btnInstance.Position = new Vector2(meinmarker.Position.X, meinmarker.Position.Y + i * 9);

                int num = btnInstance.GetChildCount();
                GD.Print("Create Seat " + i + seatcolumn);
                //beware! The order in which we instantiate and set the name seems to be important
                AddChild(btnInstance);
                btnInstance.AirplaneName = i + seatcolumn;
                //subscribe all the button events to the same event handler
                btnInstance.Pressed += _on_dynamic_btn_pressed;
            }
        }
    }

    private Dictionary<string, List<Seat>> GenerateSeatingConfig()
    {
        var config = new Dictionary<string, List<Seat>>();
        var a320Seats = new List<Seat>();
        for (int i = 0; i < 20; i++)
        {
            a320Seats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "A",
                IsFloor = false
            });
            a320Seats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "B",
                IsFloor = false
            });
            a320Seats.Add(new Seat()
            {
                Available = false,
                Row = i,
                Column = "-",
                IsFloor = true
            });
            a320Seats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "C",
                IsFloor = false
            });
            a320Seats.Add(new Seat()
            {
                Available = true,
                Row = i,
                Column = "D",
                IsFloor = false
            });

        }


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
        GD.Print("pressed " + name);
    }

}
