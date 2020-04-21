using System;

namespace RandomPasscode.Models
{
    public class Passcode
    {
        public string Code {get; set;}
        public Passcode()
        {
            string options = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rand = new Random();
            for(int i=0; i<14; i++)
            {
                Code += options[rand.Next(options.Length)];
            }
        }
        
    }
}