using System;

namespace TaskCore.App
{
    public interface IPriorityColorChooser
    {
        ConsoleColor GetColor(int priority);
    }
}