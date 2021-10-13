using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The point of this class is to maintain IDs for our ScriptableObject items.
 * Turns out, ScriptableObjects natively do not have any stable sort of stable
 * ID. This is an issue for when we want to save which items our character's
 * inventory contains.
 * 
 * This index maintains a list of every ScriptableObject item that exists. It's
 * kept up to date because this class's editor ItemIndexEditor provides the
 * only way for us to create more items. A hook in ItemIndexEditor adds the
 * item to this list of every item.
 * 
 * The order of items in this.items should not change. Thus, we use the item's
 * position in that list as the item's ID. We init dictionaries GetId and
 * GetItem whenever this ScriptableObject's OnAfterDeserialize hook is called,
 * and when a new item is created.
 */
[CreateAssetMenu(fileName = "ItemIndex", menuName = "ScriptableObjects/ItemIndex")]
public class ItemIndex : ScriptableObject, ISerializationCallbackReceiver
{
    public List<Item> items;
    public Dictionary<Item, int> GetId = new Dictionary<Item, int>();
    public Dictionary<int, Item> GetItem = new Dictionary<int, Item>();

    public void OnAfterDeserialize()
    {
        Reindex();
    }

    public void Reindex()
    {
        Debug.Log("ItemIndex reindexed.");
        this.GetId = new Dictionary<Item, int>();
        this.GetItem = new Dictionary<int, Item>();
        for (int i = 0; i < this.items.Count; i++)
        {
            this.GetId.Add(this.items[i], i);
            this.GetItem.Add(i, this.items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}

