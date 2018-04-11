using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public class RequestLogin
    {
        public string user_ip;
    }

    public class RequestGetAllNumbers
    {
        public string user_id;
    }

    public class ResponseGetAllNumbers
    {
        public string numbers;
    }


    public class ResponseLogin
    {

    }

    public class RequestGacha
    {
        public string limit;
        public string user_id;
        public string status;
    }

    public class ResponseGacha
    {
        public List<EmmisionCharacter> emmisionCharacterList = new List<EmmisionCharacter>();
    }

    public class EmmisionCharacter
    {
        public string rate;
        public string dictionary_number;
    }

    public class EmmisionCharacterList
    {
       public List<EmmisionCharacter> emmisionCharacterList;
    }


}
