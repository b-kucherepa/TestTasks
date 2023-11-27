namespace TestTasks.SortTests
{
    /// <summary>
    /// The external polyphase merge sort algorithm is an algorithm based on SortAndMerge method
    /// of the inner merge sort algorithm. An external sort is used when the number or size 
    /// of elements to be sorted is bigger than the memory buffer available. 
    /// Since there is no way to load all the elements in the memory simultaneously and 
    /// sort them with any kind of inner sort algorithm in whole directly, 
    /// this algorithm uses four external cache files to read and save 
    /// intermediate sort results of small, handleable segments (runs).
    /// The algorithm consists of three phases: 
    /// 1) first pass, which creates sorted runs of elements, each of the length of the buffer,
    /// and saves them in two cache files in turns;
    /// 2) middle phase, which reads, sorts, and merges runs into the sorted runs of double length, 
    /// writing them into the other pair of cache files also in turns. After that it repeats 
    /// the process, now cleaning the first pair of cache files and 
    /// saving the sorted runs of the quadruple length back into them.
    /// The process is repeated until there are two cache files with
    /// two sorted runs of the length of half of the initial file each;
    /// 3) final pass, which sorts and merges those two cache file consisting of
    /// two whole sorted runs into the final sorted resulting file.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N * log2(N)).
    /// Average asymptotic complexity is
    /// ϴ(N * log2(N)).
    /// Best-case asymptotic complexity is 
    /// Ω(N * log2(N)).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(1) for the buffer, O(S) for the cache, where S is the storage size used.
    /// </remarks>
    internal class ExternalSort
    {
        //4 cache files for partial sorting and merging:
        private string _cacheAPath = FileManager.CreateEmptyFile("CacheA.txt", "ExternalSort\\");
        private string _cacheBPath = FileManager.CreateEmptyFile("CacheB.txt", "ExternalSort\\");
        private string _cacheCPath = FileManager.CreateEmptyFile("CacheC.txt", "ExternalSort\\");
        private string _cacheDPath = FileManager.CreateEmptyFile("CacheD.txt", "ExternalSort\\");

        //the resulting file:
        private string _targetFilePath =
            FileManager.CreateEmptyFile("SortedFile.txt", "ExternalSort\\");

        private int[] _buffer;

        //the signal value in case read input from the file was empty:
        private int _signalValue = -1;


        public string SortFile(string filePath, int bufferLimit, SortingAlgorithm innerSort)
        {
            //initializes new buffer array:
            _buffer = new int[bufferLimit];

            //performs a 3-phased algorithm and returns the sorted file path:
            FirstPass(filePath, innerSort, out int maxFileLength);

            MiddlePhase(maxFileLength, out string lastCache1Path, out string lastCache2Path, out int halfOfFileLength);

            FinalPass(lastCache1Path, lastCache2Path, halfOfFileLength);

            return _targetFilePath;
        }


        private void FirstPass(string initialFilePath, SortingAlgorithm innerSort, out int maxFileLength)
        {
            string outputCachePath = _cacheAPath;
            int position = 0;

            //while hasn't reached the end of file
            //(so no empty input was detected in for of the signal value):
            while (_buffer[_buffer.Length - 1] != _signalValue)
            {
                //reads a buffer-sized elements sequence from the file:
                FileManager.ReadToArrayFromFile(initialFilePath, _buffer, position,
                    0, _buffer.Length, _signalValue);

                //uses inner sort to sort the buffer:
                innerSort.SortArray(_buffer);

                //writes the buffer into 
                FileManager.WriteFromArrayToFile(outputCachePath, _buffer, _signalValue);

                //shifts the position the file will be read from next time:
                position += _buffer.Length;

                //after writing a buffer-length sequence into one cache file,
                //it switches to the other one in the pair, to write next sequence there:

                if (outputCachePath == _cacheAPath)
                {
                    outputCachePath = _cacheBPath;
                }
                else
                {
                    outputCachePath = _cacheAPath;
                }
            }

            //the maximal file length is approximately equal to the final reading position:
            maxFileLength = position - _buffer.Length;
        }


        private void MiddlePhase(int fileLength, 
            out string lastCache1Path, out string lastCache2Path, out int lastRunLength)
        {
            /* After the first pass, cache files A and B have been filled with sorted runs of 
             * the buffer length. At the first pass of the second phase, these runs 
             * will be merged into runs of (buffer length *2) and stored in 
             * cache files C and D. This process will be repeated recursively, 
             * with runs of (buffer length *2) retrieved from cache files C and D, 
             * sorted, and merged into runs of (buffer length * 4), and 
             * written to cache files A and B...
             * The algorithm will terminate when runs are larger or equal than half of the file, 
             * which means that each cache file will contain a single sorted run 
             * of half of the file length. */

            string outputCachePath = _cacheCPath;
            string inputCache1Path = _cacheAPath;
            string inputCache2Path = _cacheBPath;

            int runLength = _buffer.Length;
            int halfOfFileLength = fileLength / 2;

            //while runs are shorter than half of the file length, ...
            while (runLength < halfOfFileLength)
            {
                //...sorts and merges runs into the next pair of cache files until 
                //every cache file contains a half of elements:
                for (int startIndex = 0; startIndex < halfOfFileLength; startIndex += runLength)
                {
                    //sorts and merges every pair of runs from both cache files
                    //similarly to the merge sort algorithm SortAndMerge method:
                    SortAndMerge(runLength, inputCache1Path, inputCache2Path,
                    startIndex, outputCachePath);

                    //after finishing writing one merged pair of runs into one cache file,
                    //it switches output to the other cache file in the pair:
                    if (outputCachePath == _cacheAPath)
                    {
                        outputCachePath = _cacheBPath;
                    }
                    else if (outputCachePath == _cacheBPath)
                    {
                        outputCachePath = _cacheAPath;
                    }
                    else if (outputCachePath == _cacheCPath)
                    {
                        outputCachePath = _cacheDPath;
                    }
                    else
                    {
                        outputCachePath = _cacheCPath;
                    }
                }

                //once the FOR loop is done, every run in cache files now have a doubled length:
                runLength *= 2;

                //now it switches an input cache pair with an output one, cleaning
                //the former one to be reused in the next iteration of the WHILE loop:
                if (inputCache1Path == _cacheAPath)
                {
                    //clears _buffer files
                    _cacheAPath = FileManager.CreateEmptyFile("CacheA.txt", "ExternalSort\\");
                    _cacheBPath = FileManager.CreateEmptyFile("CacheB.txt", "ExternalSort\\");
                    outputCachePath = _cacheAPath;
                    inputCache1Path = _cacheCPath;
                    inputCache2Path = _cacheDPath;
                }
                else
                {
                    //clears _buffer files
                    _cacheCPath = FileManager.CreateEmptyFile("CacheC.txt", "ExternalSort\\");
                    _cacheDPath = FileManager.CreateEmptyFile("CacheD.txt", "ExternalSort\\");
                    outputCachePath = _cacheCPath;
                    inputCache1Path = _cacheAPath;
                    inputCache2Path = _cacheBPath;
                }
            }

            // After the second phase is completed, the code returns the cached files paths and
            // run length to be used later in the final pass:
            lastCache1Path = inputCache1Path;
            lastCache2Path = inputCache2Path;
            lastRunLength = runLength;
        }
        private void FinalPass(string inputCache1Path, string inputCache2Path, int runLength)
        {
            //finishes the sorting, sorting, merging and writing last two runs
            //being split into two cache files into the final target file: 
            SortAndMerge(runLength, inputCache1Path, inputCache2Path, 0, _targetFilePath);
        }
        private void SortAndMerge(int runLength,
        string input1Path, string input2Path, int firstIndexToRead, string outputPath)
        {
            int bufferMidpoint = _buffer.Length / 2;

            //positions from which cache files will be read:
            int position1 = firstIndexToRead;
            int position2 = firstIndexToRead;

            int lastPosition = firstIndexToRead + runLength;

            //gets first parts of runs from each cache file in the pair:
            FileManager.ReadToArrayFromFile(input1Path, _buffer, position1,
                0, bufferMidpoint, _signalValue);
            FileManager.ReadToArrayFromFile(input2Path, _buffer, position2,
                bufferMidpoint, bufferMidpoint, _signalValue);

            //the left buffered subrun begins from the 0:
            int leftIndex = 0;
            //the right buffered subrun begins from the middle of the buffer:
            int rightIndex = bufferMidpoint;

            // this WHILE loop is pretty close to the SortAndMerge method from the merge sort:
            while (true)
            {
                /* if the first buffer half is depleted (because its elements were smaller than
                 * the rest in the other half), the loop shifts the cache file reading position,
                 * loads the new part of the first cache file run and 
                 * resets the left index to continue comparing two runs: */
                if ((leftIndex >= bufferMidpoint) && (position1 < lastPosition))
                {
                    position1 += bufferMidpoint;
                    FileManager.ReadToArrayFromFile(input1Path, _buffer, position1,
                        0, bufferMidpoint, _signalValue);
                    leftIndex = 0;
                }

                //the same for the second buffer half:
                if ((rightIndex >= _buffer.Length) && (position2 < lastPosition))
                {
                    position2 += bufferMidpoint;
                    FileManager.ReadToArrayFromFile(input2Path, _buffer, position2, bufferMidpoint, bufferMidpoint, _signalValue);
                    rightIndex = bufferMidpoint;
                }

                //if runs from both cache files were depleted, the loop is finished:
                if (position1 >= lastPosition && position2 >= lastPosition)
                {
                    break;
                }


                //if the run from the first cache file were depleted,
                //the loop just keeps writing the rest to the file since it's already sorted:
                if (position1 >= lastPosition)
                {
                    FileManager.WriteIntToFile(outputPath, _buffer[rightIndex], _signalValue);
                    rightIndex++;
                    continue;
                }

                //the same for the second cache run:
                if (position2 >= lastPosition)
                {
                    FileManager.WriteIntToFile(outputPath, _buffer[leftIndex], _signalValue);
                    leftIndex++;
                    continue;
                }

                /* otherwise, if the current left half element is lesser than 
                 * the current right half element (or the right half element is equal to 
                 * the signal value), the current left half value is added to
                 * the resulting merged array as the next smallest number, and 
                 * the left half index is incremented:*/
                if (_buffer[leftIndex] < _buffer[rightIndex] || _buffer[rightIndex] == _signalValue)
                {
                    FileManager.WriteIntToFile(outputPath, _buffer[leftIndex], _signalValue);
                    leftIndex++;
                    continue;
                }

                //the same for the right half element:
                if (_buffer[leftIndex] >= _buffer[rightIndex] || _buffer[leftIndex] == _signalValue)
                {
                    FileManager.WriteIntToFile(outputPath, _buffer[rightIndex], _signalValue);
                    rightIndex++;
                    continue;
                }
            }
        }
    }
}