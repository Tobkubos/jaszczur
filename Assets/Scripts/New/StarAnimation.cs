using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.rotateAround(this.gameObject, new Vector3(0, 0, 1),360, 20).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
    }


}
