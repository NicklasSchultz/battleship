﻿using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class BattleshipBuilder
    {
        private BattleshipGame _game = new BattleshipGame();
        private ModelHolder modelHolder;
        private Player player1;
        private Player player2;
        public BattleshipBuilder(ModelHolder modelHolder,Player player1,Player player2)
        {
            this.modelHolder = modelHolder;
            this.player1=player1;
            this.player2 = player2;
        }
        public BattleshipGame buildGame()
        {
            return _game;
        }

        public class BattleshipGame
        {

        }
    }
}