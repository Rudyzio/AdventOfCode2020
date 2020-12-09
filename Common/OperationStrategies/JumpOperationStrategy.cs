namespace Common.OperationStrategies
{
    public class JumpOperationStrategy : OperationStrategy
    {
        public override void Execute(ref int accumulator, ref int pointer, int argument)
        {
            pointer += argument;
        }
    }
}