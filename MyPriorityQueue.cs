using System.Collections.Generic;
using System.IO;
using System;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Queue the have a insert elem by relative of cost of its component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyPriorityQueue<T> : MyQueue<T> where T : ICostable
    {
        /// <summary>
        /// add elem to queue by cost 
        /// </summary>
        /// <param name="s">who we adding</param>
        public override void Add(T s)
        {
            if(this.lst.Count ==0)
            {
                lst.Insert(0, s);

                return;
            }
            bool b = false;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].GetCost() > s.GetCost())
                {
                    b = true;
                    lst.Insert(i, s);
                    break;
                }
            }
            if(!b)
            {
                lst.Insert(lst.Count - 1, s);
            }
        }

    }
}