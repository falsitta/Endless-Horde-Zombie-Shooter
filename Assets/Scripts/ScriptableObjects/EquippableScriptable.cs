using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableScriptable : ItemScript
{
    public bool Equipped {
        get => isEquipped;
        set
        {
            Equipped = value;
            OnEquipStatusChange?.Invoke();
        }

    }

    public delegate void EquipStatusChange();
    public event EquipStatusChange OnEquipStatusChange;
    
    bool isEquipped = false;

    public override void UseItem(PlayerController playerController)
    {
        Equipped = !Equipped;
    }

}
