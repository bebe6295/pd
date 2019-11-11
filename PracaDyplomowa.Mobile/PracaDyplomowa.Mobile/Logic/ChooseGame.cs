using System;
using System.Collections.Generic;
using System.Linq;

namespace PracaDyplomowa.Mobile.Logic
{
    public class ChooseGame<T> where T : class, ISource
    {
        private IEnumerable<T> _items;

        public ICollection<T> BoardItems { get; set; }
        public T CurrentItem { get; set; }

        public ChooseGame(IEnumerable<T> items)
        {
            _items = items;
            GenerateBoard();
        }

        public void GenerateBoard()
        {
            BoardItems = _items.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            CurrentItem = BoardItems.OrderBy(x => Guid.NewGuid()).First();
        }

        public bool MakeChoice(T chosenItem)
        {
            if (CurrentItem != chosenItem)
            {
                return false;
            }

            GenerateBoard();

            return true;
        }
    }
}
