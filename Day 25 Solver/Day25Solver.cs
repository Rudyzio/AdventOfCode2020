namespace Day_25_Solver
{
    public static class Day25Solver
    {
        public static long Part1Solution(string[] lines)
        {
            long publicKeyDoor = long.Parse(lines[0]);
            long publicKeyCard = long.Parse(lines[1]);

            var loopSizeDoor = GetLoopSize(publicKeyDoor);
            var loopSizeCard = GetLoopSize(publicKeyCard);

            var encryptionKeyDoor = GetTransformedSubjectNumber(loopSizeDoor, publicKeyCard);
            var encryptionKeyCard = GetTransformedSubjectNumber(loopSizeCard, publicKeyDoor);

            return encryptionKeyCard;
        }

        public static int Part2Solution(string[] lines)
        {
            return 0;
        }

        private static int GetLoopSize(long publicKey)
        {
            int toReturn = 1;
            long currentTransform = 1;
            while (true)
            {
                currentTransform = (currentTransform * 7) % 20201227;
                if (currentTransform == publicKey)
                {
                    break;
                }
                toReturn++;
            }
            return toReturn;
        }

        private static long GetTransformedSubjectNumber(int loopSize, long subjectNumber)
        {
            long toReturn = 1;
            for (int i = 0; i < loopSize; i++)
            {
                toReturn = (toReturn * subjectNumber) % 20201227;
            }
            return toReturn;
        }
    }
}
