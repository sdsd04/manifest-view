public class Seat{
    public bool Available { get; set; }
    public int Row { get; set; }
    public string Column { get; set; }
    public bool IsFloor { get; set; }
    public override string ToString ()
    {
        return Column + Row;
    }
}