using System;
using System.Collections.Generic;
using System.Text;

namespace GuardianPortal.Domain
{
    public class BungieApiResponse<T>
    {
        public T Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public object MessageData { get; set; }
    }

    //public class ProfileResponse
    //{

    //    public object Profile { get; set; }
    //    public object Characters { get; set; }
    //}

    public class CharacterResponse 
    {
        public CharacterResponseData Characters { get; set; }
    }
    public class CharacterResponseData
    {
        //consider mapping this stuff back as an iterable array for the front end.
        // may be easier to work with that way
        public IDictionary<string, Domain.Character.Character> Data { get; set; }
        public int Privacy { get; set; }
    }


}
