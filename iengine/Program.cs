﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iengine
{
    public class Program
    {
        static void Main(string[] args)
        {

            /********* TEST : TTEntails **************/

            // assumed given data
            List<string> pLogic = new List<string> { "p2=> p3", "p3 => p1", "c => e", "b&e => f", "f&g => h", "p1=>d", "p1&p3 => c", "a", "b", "p2" };
            List<string> asked = new List<string> { "f" };

            // the KB expression is a conjunction of all expressions
            Expression kb = new Expression("", "&");
            kb.BuildExpression(pLogic, false);

            // goal expression created using the reusable function
            Expression goal = new Expression();
            goal.BuildExpression(asked, false);

            TTEntail ttInf = new TTEntail(kb, goal);
            string yesNo = "NO";
            if (ttInf.TT_Entail())
            {
                yesNo = "YES: ";
                Console.WriteLine(yesNo + ttInf.ModelNum);
            }
            else
            {
                Console.WriteLine(yesNo);
            }
                

            /********** End TT Entail Test **************/


            /********* TEST : BCEntails **************/
            kb.Children.Clear();
            kb.BuildExpression(pLogic, true);
            BC bc = new BC(kb, goal);
            yesNo = "NO";
            if (bc.BCEntail())
            {
                yesNo = "YES: ";
                Console.Write(yesNo);
                for (int i = bc.Path.Count; i > 0; i--)
                {
                    Console.Write(bc.Path[i - 1]);
                    if (i != 1)
                        Console.Write(", ");
                }
            }
            else
            {
                Console.Write(yesNo);
            }

            Console.WriteLine();
            Console.ReadLine();

            /********** End TT BCEntails Test **************/
        }
    }
}
