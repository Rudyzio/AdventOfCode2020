using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Common.OperationStrategies;

namespace Common
{
    public class BootCodeProgram
    {
        private Operation[] _initialOperations;
        private Operation[] _operations;

        private int _accumulator = 0;
        private int _pointer = 0;

        private int _changePointer = 0;

        public BootCodeProgram(Operation[] operations)
        {
            _initialOperations = operations;
            _operations = Array.ConvertAll(_initialOperations, op => (Operation)op.Clone());
        }

        public BootCodeProgram(string[] lines)
        {
            ParseInput(lines);
            _operations = Array.ConvertAll(_initialOperations, op => (Operation)op.Clone());
        }

        public void ChangeNextInstruction()
        {
            _operations = Array.ConvertAll(_initialOperations, op => (Operation)op.Clone());
            _accumulator = 0;
            _pointer = 0;
            while (true)
            {
                switch (_operations[_changePointer].OperationType)
                {
                    case OperationTypeEnum.NoOperation:
                        _operations[_changePointer].OperationType = OperationTypeEnum.Jump;
                        // System.Console.WriteLine($"Changed from NoOperations to Jump");
                        _changePointer++;
                        return;
                    case OperationTypeEnum.Jump:
                        _operations[_changePointer].OperationType = OperationTypeEnum.NoOperation;
                        // System.Console.WriteLine($"Changed from Jump to NoOperation");
                        _changePointer++;
                        return;
                    default:
                        _changePointer++;
                        break;
                }
            }
        }

        public bool IsPointerAttemptingAfterLastInstruction()
        {
            // System.Console.WriteLine($"Pointer value {_pointer} and length {_operations.Length}");
            return _pointer == _operations.Length;
        }

        private void ParseInput(string[] lines)
        {
            _initialOperations = new Operation[lines.Length];
            for (var i = 0; i < lines.Length; i++)
            {
                var splitted = lines[i].Split(" ");
                Operation operation;
                switch (splitted[0])
                {
                    case "acc":
                        operation = new Operation(OperationTypeEnum.Accumulate, int.Parse(splitted[1]));
                        break;
                    case "jmp":
                        operation = new Operation(OperationTypeEnum.Jump, int.Parse(splitted[1]));
                        break;
                    case "nop":
                        operation = new Operation(OperationTypeEnum.NoOperation, int.Parse(splitted[1]));
                        break;
                    default:
                        throw new Exception($"Operation not supported: {splitted[0]}");
                }
                _initialOperations[i] = operation;
            }
            _initialOperations = _initialOperations.ToArray();
        }

        public int Run()
        {
            var strategies = GetOperationStrategies();
            while (true)
            {
                if (_pointer + 1 > _operations.Length)
                {
                    return _accumulator;
                }
                var currentOperation = _operations[_pointer];
                // System.Console.WriteLine($"Executing {currentOperation.OperationType} {currentOperation.Argument} - pointer is in {_pointer}");
                if (currentOperation.Visited)
                {
                    return _accumulator;
                }
                currentOperation.Visited = true;

                strategies[currentOperation.OperationType].Execute(ref _accumulator, ref _pointer, currentOperation.Argument);
            }

        }

        private Dictionary<OperationTypeEnum, OperationStrategy> GetOperationStrategies()
        {
            return new Dictionary<OperationTypeEnum, OperationStrategy>() {
                { OperationTypeEnum.Accumulate, new AccumulateOperationStrategy() },
                { OperationTypeEnum.Jump, new JumpOperationStrategy() },
                { OperationTypeEnum.NoOperation, new NoOperationStrategy() }
            };
        }

        public void PrintOperations()
        {
            System.Console.WriteLine("================ Operations ================");
            for (var i = 0; i < _operations.Length; i++)
            {
                System.Console.WriteLine($"{_operations[i].OperationType} {_operations[i].Argument}");
            }
            System.Console.WriteLine("================ End Operations ================");
        }

    }
}