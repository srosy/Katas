
using System.Text;

using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPractice
{
    class Program
    {
        public static void Main(string[] args)
        {
            var n1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var n2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            var answer = AddTwoNumbers(n1, n2);
            Console.WriteLine(answer.val);

            Console.ReadLine();
        }


        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int val=0, ListNode next=null) {
         *         this.val = val;
         *         this.next = next;
         *     }
         * }
         */
        public class ListNode
        {
            public int val { get; set; }
            public ListNode next { get; set; }
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            List<BigInteger> first = new List<long>();
            RecurseAdd(l1, first);
            first.Reverse();

            List<long> second = new List<long>();
            RecurseAdd(l2, second);
            second.Reverse();

            var chars = (long.Parse(string.Join("", first)) + long.Parse(string.Join("", second))).ToString().ToCharArray().Reverse().ToList();
            
            ListNode final = new ListNode();
            var index = 0;
            ListNode current = final;
            while (index < chars.Count)
            {
                current.val = int.Parse(chars[index].ToString());

                if (current.next == null && (index + 1 < chars.Count))
                    current.next = new ListNode();

                current = current.next;
                index++;
            }

            return final;
        }

        public static void RecurseAdd (ListNode l, List<long> list)
        {
            list.Add(l.val);
            if (l.next != null)
                RecurseAdd(l.next, list);
        }
    }
}



