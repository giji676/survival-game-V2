using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public ItemType itemType = ItemType.Item;
    public int maxStack = 1;
    public GameObject parent;
    public virtual void Equip()
    {

    }

    public virtual void Unequip()
    {

    }

    public void RemoveFromInventory()
    {
        //Inventory.instance.Remove(this);
    }
}

public enum ItemType
{
    Armor,
    Tool,
    Weapon,
    Item
}
