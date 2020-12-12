using System;
using System.Collections.Generic;

namespace Day_12_Solver
{
    public static class Day12Solver
    {
        public static int Part1Solution(string[] lines)
        {
            List<KeyValuePair<Action, int>> actions = new List<KeyValuePair<Action, int>>();
            actions.ParseInput(lines);

            Action currentOrientation = Action.East;
            int verticalPos = 0;
            int horizontalPos = 0;

            foreach (var action in actions)
            {
                // System.Console.WriteLine($"Current action: {action.Key}{action.Value}");
                switch (action.Key)
                {
                    case Action.North:
                        verticalPos += action.Value;
                        break;
                    case Action.South:
                        verticalPos -= action.Value;
                        break;
                    case Action.East:
                        horizontalPos += action.Value;
                        break;
                    case Action.West:
                        horizontalPos -= action.Value;
                        break;
                    case Action.Left:
                        RotateLeft(ref currentOrientation, action.Value);
                        break;
                    case Action.Right:
                        RotateRight(ref currentOrientation, action.Value);
                        break;
                    case Action.Forward:
                        currentOrientation.GoForward(action.Value, ref horizontalPos, ref verticalPos);
                        break;
                }
                // System.Console.WriteLine($"V:{verticalPos} H:{horizontalPos} O: {currentOrientation}");
            }

            return Math.Abs(verticalPos) + Math.Abs(horizontalPos);
        }

        public static int Part2Solution(string[] lines)
        {
            List<KeyValuePair<Action, int>> actions = new List<KeyValuePair<Action, int>>();
            actions.ParseInput(lines);

            int verticalPos = 0;
            int horizontalPos = 0;
            int waypointHorizontalPos = 10;
            int waypointVerticalPos = 1;

            foreach (var action in actions)
            {
                // System.Console.WriteLine($"Current action: {action.Key}{action.Value}");
                switch (action.Key)
                {
                    case Action.North:
                        waypointVerticalPos += action.Value;
                        break;
                    case Action.South:
                        waypointVerticalPos -= action.Value;
                        break;
                    case Action.East:
                        waypointHorizontalPos += action.Value;
                        break;
                    case Action.West:
                        waypointHorizontalPos -= action.Value;
                        break;
                    case Action.Left:
                        RotateWaypointLeft(ref waypointHorizontalPos, ref waypointVerticalPos, action.Value);
                        break;
                    case Action.Right:
                        RotateWaypointRight(ref waypointHorizontalPos, ref waypointVerticalPos, action.Value);
                        break;
                    case Action.Forward:
                        GoForwardWithWaypoint(action.Value, ref horizontalPos, ref verticalPos, waypointHorizontalPos, waypointVerticalPos);
                        break;
                }
                // System.Console.WriteLine($"H:{horizontalPos} V:{verticalPos} WH: {waypointHorizontalPos} WV: {waypointVerticalPos} ");
            }

            return Math.Abs(verticalPos) + Math.Abs(horizontalPos);
        }

        private static void ParseInput(this List<KeyValuePair<Action, int>> actions, string[] lines)
        {
            foreach (var line in lines)
            {
                var actionChar = line[0];
                var amount = int.Parse(line.Substring(1));
                switch (actionChar)
                {
                    case 'N':
                        actions.Add(new KeyValuePair<Action, int>(Action.North, amount));
                        break;
                    case 'S':
                        actions.Add(new KeyValuePair<Action, int>(Action.South, amount));
                        break;
                    case 'E':
                        actions.Add(new KeyValuePair<Action, int>(Action.East, amount));
                        break;
                    case 'W':
                        actions.Add(new KeyValuePair<Action, int>(Action.West, amount));
                        break;
                    case 'L':
                        actions.Add(new KeyValuePair<Action, int>(Action.Left, amount));
                        break;
                    case 'R':
                        actions.Add(new KeyValuePair<Action, int>(Action.Right, amount));
                        break;
                    case 'F':
                        actions.Add(new KeyValuePair<Action, int>(Action.Forward, amount));
                        break;
                }
            }
        }

        private static void RotateLeft(ref Action currentOrientation, int degrees)
        {
            do
            {
                switch (currentOrientation)
                {
                    case Action.North:
                        currentOrientation = Action.West;
                        break;
                    case Action.South:
                        currentOrientation = Action.East;
                        break;
                    case Action.East:
                        currentOrientation = Action.North;
                        break;
                    case Action.West:
                        currentOrientation = Action.South;
                        break;
                }
                degrees -= 90;
            } while (degrees > 0);
        }

        private static void RotateRight(ref Action currentOrientation, int degrees)
        {
            do
            {
                switch (currentOrientation)
                {
                    case Action.North:
                        currentOrientation = Action.East;
                        break;
                    case Action.South:
                        currentOrientation = Action.West;
                        break;
                    case Action.East:
                        currentOrientation = Action.South;
                        break;
                    case Action.West:
                        currentOrientation = Action.North;
                        break;
                }
                degrees -= 90;
            } while (degrees > 0);
        }

        private static void RotateWaypointLeft(ref int waypointHorizontalPos, ref int waypointVerticalPos, int degrees)
        {
            do
            {
                degrees -= 90;
                int oldWaypointHorizontalPos = waypointHorizontalPos;
                waypointHorizontalPos = -waypointVerticalPos;
                waypointVerticalPos = oldWaypointHorizontalPos;
            } while (degrees > 0);
        }

        private static void RotateWaypointRight(ref int waypointHorizontalPos, ref int waypointVerticalPos, int degrees)
        {
            do
            {
                degrees -= 90;
                int oldWaypointHorizontalPos = waypointHorizontalPos;
                waypointHorizontalPos = waypointVerticalPos;
                waypointVerticalPos = -oldWaypointHorizontalPos;
            } while (degrees > 0);
        }

        private static void GoForward(this Action currentOrientation, int value, ref int horizontalPos, ref int verticalPos)
        {
            switch (currentOrientation)
            {
                case Action.North:
                    verticalPos += value;
                    break;
                case Action.South:
                    verticalPos -= value;
                    break;
                case Action.East:
                    horizontalPos += value;
                    break;
                case Action.West:
                    horizontalPos -= value;
                    break;
            }
        }

        private static void GoForwardWithWaypoint(int value, ref int horizontalPos, ref int verticalPos, int waypointHorizontalPos, int waypointVerticalPos)
        {
            horizontalPos += waypointHorizontalPos * value;
            verticalPos += waypointVerticalPos * value;
        }


        private static void PrintActions(this List<KeyValuePair<Action, int>> actions)
        {
            foreach (var action in actions)
            {
                System.Console.WriteLine($"{action.Key}{action.Value}");
            }
        }

    }

    public enum Action
    {
        North,
        South,
        East,
        West,
        Left,
        Right,
        Forward
    }
}
