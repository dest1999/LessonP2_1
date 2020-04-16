using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingGuessing
{
    class TestingGues
    {
        static int i = 0;

        delegate void Delegate();

        static void WriteIncrement()
        {
            Console.WriteLine($"delegate running times: {++i} (method WriteIncrement)");
        }

        static void AdditionalWriteIncrement()
        {
            Console.WriteLine($"delegate running times: {++i} (method AdditionalWriteIncrement)");
        }



        static void Main(string[] args)
        {
            Delegate del = AdditionalWriteIncrement;

            del += WriteIncrement;
            del += AdditionalWriteIncrement;
            del += WriteIncrement;
            del += AdditionalWriteIncrement;
            del();
            Console.ReadKey();
        }
    }
}
