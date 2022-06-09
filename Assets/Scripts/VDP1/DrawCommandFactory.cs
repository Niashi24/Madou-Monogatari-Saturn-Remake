using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

namespace LS.VDP1.Commands.Editor
{
    [CreateAssetMenu(menuName = "VDP1/DrawCommandFactory")]
    public class DrawCommandFactory : ScriptableObject
    {

        static readonly List<DrawCommandWorker> Workers = new()
        {
            new SystemClippingCommandWorker(),
            new UserClippingCommandWorker(),
            new ScaledSpriteCommandWorker()
        };

        [Button]
        public static List<DrawCommand> GetCommandsFromDebug(TextAsset asset)
        {
            List<DrawCommand> output = new();
            string[] info = asset.text.Split("\r\n");

            var indexes = GetBeginsAndEnds(info);

            foreach (var (begin, end) in indexes)
            {
                // Debug.Log($"Begin: {begin}, End: {end}");
                output.Add(GetCommand(info, begin, end));
            }

            return output;
        }

        public static List<(int, int)> GetBeginsAndEnds(string[] info)
        {
            List<(int, int)> output = new();

            int begin = 1;
            int end = 0;

            // int limit = 0;
            while (begin != -1)
            {
                // Debug.Log(end);
                end = FindNextBeginPoint(info, begin) - 1;
                if (end == -2) break; //(-1) - 1 = -2

                output.Add((begin, end));
                begin = end + 2;

                // limit++;
                // if (limit > 50) break;
            }

            return output;
        }

        public static int FindNextBeginPoint(string[] info, int start)
        {
            for (int i = start; i < info.Length; i++)
            {
                // Debug.Log(info[i]);
                if (info[i] == "") return i;
            }
            return -1;
        }

        public static DrawCommand GetCommand(string[] info, int begin, int end)
        {
            string title = info[begin];
            foreach (var worker in Workers)
            {
                if (worker.Applies(title))
                    return worker.ParseCommand(info, begin, end);
            }
            return null;
            // return new UnknownDrawCommand();
        }
    }
}