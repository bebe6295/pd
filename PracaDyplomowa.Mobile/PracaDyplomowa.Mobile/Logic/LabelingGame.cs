using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracaDyplomowa.Mobile.Logic
{
    public class LabelGame
    {
        public GameState State { get; private set; }
        public ICollection<LabelItem> BoardItems { get; set; }
        public LabelItem CurrentLabelItem { get; set; }
        public IEnumerable<LabelItem> LabeledItems { get; set; }

        public LabelGame(IEnumerable<LabelItem> labeledItems)
        {
            LabeledItems = labeledItems;
            GenerateBoard();
        }

        public void GenerateBoard()
        {
            BoardItems = LabeledItems.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            CurrentLabelItem = BoardItems.OrderBy(x => Guid.NewGuid()).First();
        }

        public bool MakeChoice(LabelItem labelItem)
        {
            if (CurrentLabelItem != labelItem)
            {
                return false;
            }

            GenerateBoard();

            return true;
        }

    }

    public enum GameState
    {
        Initialize,
        InProgress,
        GameOver
    }
}
