namespace Common.OperationStrategies
{
    public class NoOperationStrategy : OperationStrategy
    {
        public override void Execute(ref int accumulator, ref int pointer, int argument)
        {
            pointer++;
        }
    }
}