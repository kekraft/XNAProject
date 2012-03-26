using System;

namespace XANALand
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameHost game = new GameHost())
            {
                game.Run();
            }
        }
    }
#endif
}

