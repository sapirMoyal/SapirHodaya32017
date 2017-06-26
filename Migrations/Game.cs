﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ex2
{
    class Game
    {
        public string Name { get; set; }
        public string MazeName { get; set; }
        public SingleMaze You { get; set; }
        public SingleMaze Other { get; set; }
/// <summary>
/// class of game
/// </summary>
/// <param name="name">game name</param>
/// <param name="mazename"></param>
/// <param name="u">my maze</param>
/// <param name="other">yriv maze</param>
        public Game(string name, string mazename, SingleMaze u, SingleMaze other)
        {
            this.Name = name;
            this.MazeName = mazename;
            this.You = u;
            this.Other = other;
        }


    }
}
