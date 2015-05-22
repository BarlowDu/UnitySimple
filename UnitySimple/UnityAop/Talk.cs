using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAop
{
    public interface ITalk
    {
        string Speak(string msg);
    }
    public class Talk:ITalk
    {
        public string Speak(string msg)
        {
            Console.WriteLine(msg);
            return msg;
        }
    }
}
