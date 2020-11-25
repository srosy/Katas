using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KataPractice
{
    class CalculatorKata
    {
        //public static void Main(string[] args)
        //{

        //    var answer = Evaluate("2 / 2 + 3 * 4 - 6");
        //    Console.WriteLine(answer);

        //    Console.ReadLine();
        //}

        public class OperatorNode
        {
            readonly double _left;
            readonly double _right;
            char _operation { get; }
            public int Index { get; set; }

            public double Value
            {
                get
                {
                    if (_operation == '/')
                        return _left / _right;
                    else if (_operation == '*')
                        return _left * _right;
                    else if (_operation == '-')
                        return _left - _right;
                    else
                        return _left + _right;
                }
            }
            public OperatorNode(double l, double r, char o, int i)
            {
                _left = l;
                _right = r;
                _operation = o;
                Index = i;
            }
        }


        public static double Evaluate(string expression)
        {
            var answer = 0d;
            var split = Regex.Split(expression.Replace(" ", ""), @"([*()\^\/]|(?<!E)[\+\-])").ToList(); //expression.Replace(" ", "").Split(new char[] {'-', '+', '*', '/'}).ToList();
            var nodes = new List<OperatorNode>();

            // division
            var index = 0;
            split.ToList().ForEach(c =>
            {
                if (c == "/")
                    nodes.Add(new OperatorNode(double.Parse(split[index - 1]), double.Parse(split[index + 1]), '/', index));
                index++;
            });
            if (nodes.Any())
            {
                nodes.ForEach(n =>
                {
                    split[n.Index] = n.Value.ToString();
                    split.RemoveAt(n.Index - 1);
                    split.RemoveAt(n.Index);
                });
                nodes.Clear();
            }

            //multiplication
            index = 0;
            split.ToList().ForEach(c =>
            {
                if (c == "*")
                    nodes.Add(new OperatorNode(double.Parse(split[index - 1]), double.Parse(split[index + 1]), '*', index));
                index++;
            });
            if (nodes.Any())
            {
                nodes.ForEach(n =>
                {
                    split[n.Index] = n.Value.ToString();
                    split.RemoveAt(n.Index - 1);
                    split.RemoveAt(n.Index);
                });
                nodes.Clear();
            }

            // subtraction
            index = 0;
            split.ToList().ForEach(c =>
            {
                if (c == "-")
                    nodes.Add(new OperatorNode(double.Parse(split[index - 1]), double.Parse(split[index + 1]), '-', index));
                index++;
            });
            if (nodes.Any())
            {
                nodes.ForEach(n =>
                {
                    split[n.Index] = n.Value.ToString();
                    split.RemoveAt(n.Index - 1);
                    split.RemoveAt(n.Index);
                });
                nodes.Clear();
            }

            // addition
            index = 0;
            split.ToList().ForEach(c =>
            {
                if (c == "+")
                    nodes.Add(new OperatorNode(double.Parse(split[index - 1]), double.Parse(split[index + 1]), '+', index));
                index++;
            });
            if (nodes.Any())
            {
                nodes.ForEach(n =>
                {
                    split[n.Index] = n.Value.ToString();
                    split.RemoveAt(n.Index - 1);
                    split.RemoveAt(n.Index);
                });
                nodes.Clear();
            }

            answer = split.Sum(n => double.Parse(n));
            return answer;
        }
    }
}
