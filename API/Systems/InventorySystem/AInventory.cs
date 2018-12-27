using System;
using UnityEngine.Events;

namespace RPG_Engine.Systems.Inventory
{
    /// <summary>
    /// Basic abstract implementation of a <see cref="IInventory"/> which provides event-handling
    /// </summary>
    [Serializable]
    public abstract class AInventory : IInventory
    {
        public UnityEvent<int> onTypeAdded; //a new type of item has been added to the inventory
        public UnityEvent<int> onTypeRemoved; //a type has been removed from the inventory
        public UnityEvent onChanged; //whenever something in the inventory changes

        public uint AddItem(in int id, in uint amount)
        {
            bool containedBefore = ContainsItemType(id);

            uint returnValue = AddItem(id, amount);

            if( returnValue > 0 )
            {
                if( !containedBefore )
                {
                    onTypeAdded?.Invoke(id);
                }

                onChanged?.Invoke();
            }

            return returnValue;
        }

        protected abstract uint TryAddItem(in int id, in uint amount);

        public uint RemoveItem(in int id, in uint amount)
        {
            uint returnValue = TryRemoveItem(id, amount);

            if (returnValue > 0)
            {
                if (!ContainsItemType(id))
                {
                    onTypeRemoved?.Invoke(id);
                }

                onChanged?.Invoke();
            }

            return returnValue;
        }

        protected abstract uint TryRemoveItem(in int id, in uint amount);

        /// <summary>
        /// Check whether or not this inventory contains a certain item type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ContainsItemType(in int id)
        {
            return GetItemAmount(id) > 0;
        }

        public abstract uint GetItemAmount(in int id);
        public abstract int[] GetItemTypes();
    }

}

