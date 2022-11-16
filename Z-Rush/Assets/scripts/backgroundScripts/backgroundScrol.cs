using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundScrol : MonoBehaviour
{
    [SerializeField] float scrollerSpeed = 0.2f;
    Material bgMat;
    Vector2 oofset;
    void Start()
    {
        bgMat = GetComponent<Renderer>().material;
        oofset = new Vector2(0f, scrollerSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        bgMat.mainTextureOffset += oofset * Time.deltaTime;
    }
}
