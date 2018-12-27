using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_Engine.Systems.Inventory.Default
{
    /// <summary>
    /// An <see cref="IInventory"/> with no limitation in size/weight/etc.
    /// </summary>
    public class Inventory : AInventory
    {
        protected Dictionary<int, uint> items = new Dictionary<int, uint>();

        protected override uint TryAddItem(in int id, in uint amount)
        {
            items.TryGetValue(id, out uint currentAmount);
            items.Add(id, currentAmount + amount);

            return amount;
        }

        public override uint GetItemAmount(in int id)
        {
            items.TryGetValue(id, out uint returnValue);

            return returnValue;
        }

        public override int[] GetItemTypes()
        {
            var keys = items.Keys;
            int[] returnValue = new int[ keys.Count ];
            keys.CopyTo(returnValue, 0);

            return returnValue;
        }

        protected override uint TryRemoveItem(in int id, in uint amount)
        {
            items.TryGetValue(id, out uint currentAmount);
            uint newAmount = currentAmount - amount;
            if( newAmount <= 0 )
            {
                items.Remove(id);
                return currentAmount;
            }

            return amount;
        }
    }
}

