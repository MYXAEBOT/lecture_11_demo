using System;
using System.Collections.Generic;

namespace CMS.DataAccess
{
    /// <summary>
    /// Shares identifier allocation and copy isolation between in-memory repositories.
    /// </summary>
    internal sealed class InMemoryStore<TEntity> where TEntity : class
    {
        private readonly Dictionary<int, TEntity> _items = new Dictionary<int, TEntity>();
        private readonly Func<TEntity, int> _getId;
        private readonly Func<TEntity, int, TEntity> _copyWithId;
        private int _nextId = 1;

        public InMemoryStore(Func<TEntity, int> getId, Func<TEntity, int, TEntity> copyWithId)
        {
            if (getId == null) throw new ArgumentNullException("getId");
            if (copyWithId == null) throw new ArgumentNullException("copyWithId");

            _getId = getId;
            _copyWithId = copyWithId;
        }

        public TEntity GetById(int id)
        {
            TEntity item;
            return _items.TryGetValue(id, out item) ? _copyWithId(item, id) : null;
        }

        public IList<TEntity> GetAll()
        {
            var items = new List<TEntity>();
            foreach (var pair in _items)
            {
                items.Add(_copyWithId(pair.Value, pair.Key));
            }
            return items;
        }

        public int Save(TEntity item)
        {
            if (item == null) throw new ArgumentNullException("item");

            var existingId = _getId(item);
            var id = existingId > 0 ? existingId : _nextId;
            _items[id] = _copyWithId(item, id);
            if (id >= _nextId) _nextId = id + 1;
            return id;
        }
    }
}
