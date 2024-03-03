using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public int Rarity;
    public int Level;
    public int Damage;

    public GameObject Weapon;
    public void MakeItem()
    {
        Rarity = Random.Range(0, 6);
        Level= Random.Range(0, 100);
        Damage= Random.Range((Rarity*Level/3), 100);

        Instantiate(Weapon, new Vector3(0,4,0), Quaternion.identity);
    }
}
