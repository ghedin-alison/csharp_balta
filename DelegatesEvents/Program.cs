//Delegates/Annonimous

// static void RealizarPagamento(double valor)
// {
//     Console.WriteLine($"Efetuando o pagamento {valor}");
// }
//
// var pagar = new Pagamento.Pagar(RealizarPagamento);
// pagar(15);    
//
// public class Pagamento
// {
//     public delegate void Pagar(double valor);
// }

//Delegates/Annonimous

//Eventos


var room = new Room(3);
room.RoomSoldOutEvent += OnRoomSoldOut;

room.ReserveSeat();
room.ReserveSeat();
room.ReserveSeat();
room.ReserveSeat();
room.ReserveSeat();
room.ReserveSeat();

static void OnRoomSoldOut(object sender, EventArgs e)
{
    Console.WriteLine("Sala lotada!");
}
public sealed class Room
{
    public int Seats{ get; set; }

    public Room(int seats)
    {
        Seats = seats;
        _seatsInUse = 0;
    }

    private int _seatsInUse;

    public void ReserveSeat()
    {
        _seatsInUse += 1;
        if (_seatsInUse > Seats)
        {
            //Evento fechado!
            OnRoomSoldOut(EventArgs.Empty);
        }
        else
        {
            Console.WriteLine("Assento Reservado.");
        }
    }

    public event EventHandler? RoomSoldOutEvent;

    private void OnRoomSoldOut(EventArgs e)
    {
        EventHandler? handler = RoomSoldOutEvent;
        handler?.Invoke(this, EventArgs.Empty);
    }

}


//Eventos