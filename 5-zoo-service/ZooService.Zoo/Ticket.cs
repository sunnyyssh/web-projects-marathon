namespace ZooService.Model.Zoo;

public class Ticket
{
    public long Id { get; set; }

    public bool Saled { get; set; }

    public bool Attended { get; set; }

    public decimal Cost { get; set; }

    public long ZooId { get; set; }

    public ZooInfo? Zoo { get; set; }

    public DateTime AttendTime { get; set; }
}
