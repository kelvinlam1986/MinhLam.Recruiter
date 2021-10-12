using System;

namespace MinhLam.Framework
{
    public class RandomHelper
    {
        public static string RandomWord(int seed)
        {
            Random random = new Random(seed);
            int randomNumber = random.Next();
            return Convert.ToString(randomNumber, 16);
        }
    }
}
