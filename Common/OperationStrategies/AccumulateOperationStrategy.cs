namespace Common.OperationStrategies
{
    public class AccumulateOperationStrategy : OperationStrategy
    {
        public override void Execute(ref int accumulator, ref int pointer, int argument)
        {
            accumulator += argument;
            pointer++;
        }
    }
}