using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Click : MonoBehaviour
{
    Storage Storage;


    public void FUNCTION_Click()
    {
        Storage.val_TotalCash += Storage.val_CashPerClick;
    }
}
