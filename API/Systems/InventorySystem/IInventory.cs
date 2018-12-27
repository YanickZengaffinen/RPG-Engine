namespace RPG_Engine.Systems.Inventory
{
    /// <summary>
    /// Interface that represents an inventory
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Adds a certain amount of an item type to the inventory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns>The amount of items added</returns>
        uint AddItem(in int id, in uint amount);

        /// <summary>
        /// Removes a certain amount of an item type from the inventory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns>The amount that was actually removed</returns>
        uint RemoveItem(in int id, in uint amount);

        /// <summary>
        /// Get the amount of an item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        uint GetItemAmount(in int id);

        /// <summary>
        /// Get all the item types
        /// </summary>
        /// <returns></returns>
        int[] GetItemTypes();
    }
}
