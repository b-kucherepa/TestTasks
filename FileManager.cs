namespace TestTasks
{
    internal static class FileManager
    {
        //folder to save all the application files:
        public static readonly string TMP_FOLDER = Path.GetTempPath() + "TestTasks\\TestCache\\";


        public static void ReadToArrayFromFile(string filePath, int[] array, int firstElement,
            int arrayStartIndex, int lengthToRead, int signalValue = -1)
        {
            //the last line being read from the file (every line contains one element):
            int limit = arrayStartIndex + lengthToRead;

            //isolates the stream to dispose it automatically once it's not needed anymore:
            using (StreamReader fileStream = new(filePath))
            {
                //skips the unneeded lines:
                SetPositionAtElement(fileStream, firstElement);

                //reads lines in the provided borders: 
                for (int i = arrayStartIndex; i < limit; i++)
                {
                    //tries to read the current line
                    string? elementAsString = fileStream.ReadLine();

                    //if there are no more lines, then it writes the signal value into the array:
                    if (elementAsString is null)
                    {
                        array[i] = signalValue;
                        continue;
                    }

                    //else it tries to parse the line...
                    if (int.TryParse(elementAsString, out int element))
                    {
                        //...and saves it, if successful:
                        array[i] = element;
                    }
                    else
                    {
                        //...or aborts the reading because something is wrong with the file:
                        Console.WriteLine("ERROR: a non-integer value found");
                        return;
                    }
                }
            }
        }


        private static void SetPositionAtElement(StreamReader fileStream, int index)
        {
            //reads lines to skip them and to set the fileStream pointer to the desired position:
            for (int currentIndex = 0; currentIndex < index; currentIndex++)
            {
                fileStream.ReadLine();
            }
        }


        public static void WriteFromArrayToFile(string filePath, int[] array, int signalValue = -1)
        {
            //(note: the "true" argument enables append mode to write in to the end of the file:
            using (StreamWriter fileStream = new(filePath, true))
            {
                //iterates through the array and writes it to the file...
                for (int i = 0; i < array.Length; i++)
                {
                    //...ignoring signal values:
                    if (array[i] != signalValue)
                    {
                        string element = array[i].ToString();
                        fileStream.WriteLine(element);
                    }
                }
            }
        }

        public static void WriteIntToFile(string filePath, int intToWrite, int signalValue = -1)
        {
            //does the same as WriteFromArrayToFile method, but for a single value
            using (StreamWriter fileStream = new(filePath, true))
            {
                if (intToWrite != signalValue)
                {
                    fileStream.WriteLine(intToWrite);
                }
            }
        }


        internal static void GenerateRandomArrayInFile(string filePath, int count, int elementLimit)
        {
            using (StreamWriter fileStream = new(filePath))
            {
                //writes the desired count of random integers into the file:
                Random random = new();
                for (int i = 0; i < count; i++)
                {
                    fileStream.WriteLine(random.Next(0, elementLimit));
                }
            }
        }


        internal static string CreateEmptyFile(string fileName, string folder = "")
        {
            //creates a folder (optionally) inside the application temp directory
            //if it doesn't exist, and then creates the file:
            if (!Directory.Exists(TMP_FOLDER + folder))
            {
                Directory.CreateDirectory(TMP_FOLDER + folder);
            }
            File.Create(TMP_FOLDER + folder + fileName).Close();
            return (TMP_FOLDER + folder + fileName);
        }
    }
}
