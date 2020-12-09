using System;

namespace Common.Models
{
    public class Operation : ICloneable
    {
        public Operation(OperationTypeEnum type, int argument)
        {
            OperationType = type;
            Argument = argument;
            Visited = false;
        }

        public OperationTypeEnum OperationType { get; set; }

        public int Argument { get; set; }

        public bool Visited { get; set; }

        public object Clone()
        {
            return new Operation(OperationType, Argument);
        }
    }
}