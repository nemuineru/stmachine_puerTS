using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Puerts;


//lua enviroments loads as static.
//its because of the convenience.

public class scriptEngine_Onload : MonoBehaviour
{
    public static scriptEngine_Onload main;
    //public Puerts LEnv;
    // Start is called before the first frame update
    void Awake()
    {
        main = this;
        //LEnv = new LuaEnv();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        //LEnv.Dispose();
    }
}
