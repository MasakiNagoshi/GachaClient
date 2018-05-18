//////////////////////////////////////
//製作者　名越大樹
//////////////////////////////////////
using System.Collections.Generic;

namespace Protocol
{
    public class RequestCreateUser
    {
        public string user_name;
    }

    public class ResponseCreateUser
    {
        public string user_id;
        public string user_name;
    }

    public class RequestGetAllStones
    {
        public string user_id;
    }

    public class ResponseGetAllStones
    {
        public List<Stone> stones_list = new List<Stone>();
    }

    public class Stone
    {
        public string type;
        public int count;
    }

    public class RequestGetGachaTicket
    {
        public string user_id;
    }

    public class ResponseGetGachaTicket
    {
        public string noraml;
        public string specal;
    }

    public class RequestLogin
    {
        public string user_ip;
    }

    public class ResponseLogin
    {
        public string user_id;
        public bool islogin;
        public string login_present;
    }

    public class RequestGetDictionary
    {
        public string user_id;
    }

    public class ResponseGetDictionary
    {
        public string numbers;
    }


    public class RequestGacha
    {
        public string limit;
        public string user_id;
        public string status;
        public string used_noraml_ticket;
        public string used_specal_ticket;
    }

    public class ResponseGacha
    {
        public List<EmmisionCharacter> emmisionCharacterList = new List<EmmisionCharacter>();
    }

    public class EmmisionCharacter
    {
        public string rate;
        public string dictionary_number;
        public bool duplication;
    }

    public class EmmisionCharacterList
    {
        public List<EmmisionCharacter> emmisionCharacterList;
    }
}
