using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracaDyplomowa.Mobile.Logic
{
    public class LabelingGame
    {
        public GameState State { get; private set; }
        public ICollection<LabelItem> BoardItems { get; set; }
        public LabelItem CurrentLabelItem { get; set; }
        public IEnumerable<LabelItem> LabeledItems { get; set; }

        public LabelingGame(IEnumerable<LabelItem> labeledItems)
        {
            LabeledItems = labeledItems;
            GenerateBoard();
        }

        public void GenerateBoard()
        {
            BoardItems = LabeledItems.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            CurrentLabelItem = BoardItems.First();
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

    public class LabelItem : ISource
    {
        public string Label { get; set; }
        public string ImageUri { get; set; }
    }
}
