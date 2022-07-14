using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace InMoov_GUI
{
    internal class Constant
    {
        private static readonly int[] limitJX = { 750, 2250 };
        private static readonly int[] limitDS = { 1000, 2000 };
        private static readonly int[] limitMG = { 800, 2200 };
        private static readonly int[] limitBB = { 900, 2100 };
        private static readonly int[] limitBBE = { 700, 1500 };
        private static readonly List<string> hand = new List<string> { "Thumb", "Index", "Middle", "Ring", "Pinky" };
        private static readonly List<string> arm = new List<string> { "Wrist", "Elbow", "Rotate", "Pivot", "Omoplate" };
        public static List<string> Ports { get; } = Enumerable.Range(1, 10).Select(i => "COM" + i).ToList();
        public static List<string> Bauds { get; } = new List<int> { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 }.ConvertAll<string>(x => x.ToString());
        public static List<string> ModulesAction { get; } = new List<string> { "Left Hand", "Right Hand", "Left Arm", "Right Arm", "Head", "Neck && Stomach" };
        public static List<string> ModulesPerception { get; } = new List<string> { "Vision", "Auditory", "Kinect", "Tactile" };
        public static List<string> Modules { get; } = ModulesAction.Concat(ModulesPerception).ToList();
        public static Dictionary<string, List<string>> Names { get; } = new Dictionary<string, List<string>>()
        {
            {"Left Hand", hand.Select(x => "Left " + x).ToList()},
            {"Right Hand", hand.AsEnumerable().Reverse().Select(x => "Right " + x).ToList()},
            {"Left Arm", arm.Select(x => "Left" + x).ToList()},
            {"Right Arm",  arm.Select(x => "Right" + x).ToList()}
        };
        public static Dictionary<string, List<int[]>> Limits { get; } = new Dictionary<string, List<int[]>>()
        {
            {"Left Hand", new List<int[]> {limitDS, limitJX, limitJX, limitJX, limitDS}},
            {"Right Hand", new List<int[]> {limitDS, limitJX, limitJX, limitJX, limitDS}},
            {"Left Arm", new List<int[]> {limitMG, limitBBE, limitBB, limitBB, limitBB}},
            {"Right Arm",  new List<int[]> {limitMG, limitBBE, limitBB, limitBB, limitBB}}
        };
        public static Dictionary<string, List<int>> Values { get; } = new Dictionary<string, List<int>>()
        {
            {"Left Hand", Enumerable.Repeat(0, 5).ToList()},
            {"Right Hand", Enumerable.Repeat(0, 5).ToList()},
            {"Left Arm", new List<int> {90, 30, 90, 90, 90}},
            {"Right Arm",  new List<int> {90, 30, 90, 90, 90}}
        };

    }
}