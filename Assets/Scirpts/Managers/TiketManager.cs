///////////////////////////////////////////
//制作者　名越大樹
//ガチャチケットを管理するクラス
///////////////////////////////////////////

public class TiketManager
{
    public static TicketBase ticket;

    public TiketManager()
    {
        NormalTicket noraml = new NormalTicket();
        SpecalTicket spcal = new SpecalTicket();
    }
}
