namespace TextUtils.Library
{
    public static class TextTools
    {
        public static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static int CountWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) 
              return 0;

            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}
