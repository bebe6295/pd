using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracaDyplomowa.Mobile.Logic
{
    public class ColorGame
    {
        public GameState State { get; private set; }
        public ICollection<ColorItem> BoardItems { get; set; }
        public ColorItem CurrentColorItem { get; set; }
        public IEnumerable<ColorItem> ColorItems { get; set; }

        public ColorGame(IEnumerable<ColorItem> colorItems)
        {
            ColorItems = colorItems;
            GenerateBoard();
        }

        public void GenerateBoard()
        {
            BoardItems = ColorItems.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            CurrentColorItem = BoardItems.OrderBy(x => Guid.NewGuid()).First();
        }

        public bool MakeChoice(ColorItem labelItem)
        {
            if (CurrentColorItem != labelItem)
            {
                return false;
            }

            GenerateBoard();

            return true;
        }

    }
}
