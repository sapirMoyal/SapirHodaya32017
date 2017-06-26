

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Queue that add elem with not regrand to cost
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyQueue<T>
    {
        protected List<T> lst;

        public MyQueue()
        {
            lst = new List<T>();
        }
        /// <summary>
        /// add ekem to this.lst
        /// </summary>
        /// <param name="s">the added elem</param>
        public virtual void Add(T s)
        {
            if (lst.Count > 0)
            {
                int cnt = lst.Count;
                lst.Insert(cnt-1, s);
            }
            else {
                lst.Insert(0, s);
            }
            
        }
        /// <summary>
        /// add a list to queue
        /// </summary>
        /// <param name="l">the list added</param>
        public void AddList(List<T> l)
        {
            foreach (var x in l)
            {
                this.Add(x);
            }
        }
        /// <summary>
        /// return this.lst size
        /// </summary>
        /// <returns>int of size</returns>
        public int Count()
        {
            return this.lst.Count;
        }
        /// <summary>
        /// remove the last elem from qeueue
        /// </summary>
        /// <returns>the last elem</returns>
        public T Pop()
        {
            if (lst.Count > 0)
            {
                T first = lst[0];
                lst.Remove(first);
                return first;
            }
            return default(T);
        }
        /// <summary>
        /// check to see if lst contain x
        /// </summary>
        /// <param name="x">who is suspect to conatin</param>
        /// <returns>true if lst have x else false</returns>
        public bool Contains(T x)
        {
            return lst.Contains(x);
        }
        /// <summary>
        /// remove elem x from this.lst
        /// </summary>
        /// <param name="x">the elem to remove</param>
        public void remove(T x)
        {
            lst.Remove(x);
        }
    }
}
