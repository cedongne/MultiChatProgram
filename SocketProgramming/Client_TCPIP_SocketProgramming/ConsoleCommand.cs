using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_TCPIP_SocketProgramming
{
    public enum ConsoleCommandResultType { 
        CloseProgram,
        NoOperation,
        InvalidOperation
    }
    internal class ConsoleCommand
    {
        public static ConsoleCommandResultType HandleConsoleCommand(ConsoleKeyInfo consoleKeyInfo)
        {
            if (consoleKeyInfo.Key.Equals(ConsoleKey.Escape))
            {
                Console.WriteLine("채팅을 종료하시겠습니까? [Y/N]");

                var command = Console.ReadKey();
                switch (command.Key)
                {
                    case ConsoleKey.Y:
                        return ConsoleCommandResultType.CloseProgram;
                    case ConsoleKey.N:
                        return ConsoleCommandResultType.NoOperation;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        return ConsoleCommandResultType.InvalidOperation;
                }
            }

            return ConsoleCommandResultType.NoOperation;
        }
    }
}
