namespace Common.OperationStrategies
{
    public abstract class OperationStrategy
    {
        public abstract void Execute(ref int accumulator, ref int pointer, int argument);
    }
}