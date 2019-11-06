using System.Collections;
using System.Collections.Generic;

namespace PracaDyplomowa.Mobile.Services
{
    public interface IGameItemsProvider<T>
    {
        IEnumerable<T> GetGameItems();
    }
}
