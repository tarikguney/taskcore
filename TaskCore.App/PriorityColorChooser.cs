using System;

namespace TaskCore.App
{
    public class PriorityColorChooser : IPriorityColorChooser
    {
        public ConsoleColor GetColor(int priority)
            => priority switch
            {
                1 => ConsoleColor.Red,
                2 => ConsoleColor.Yellow,
                3 => ConsoleColor.Cyan,
                4 => ConsoleColor.White,
                _ => ConsoleColor.White,
            };
    }
}