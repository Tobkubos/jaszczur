using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 4f);   
    }
}
