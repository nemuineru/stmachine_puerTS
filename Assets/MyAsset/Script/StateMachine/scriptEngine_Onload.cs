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
    public TMPro.TMP_Text textMesh;
    public static scriptEngine_Onload main;
    public Puerts.JsEnv scEnv;
    // Start is called before the first frame update
    void Awake()
    {
        main = this;
        scEnv = new Puerts.JsEnv();
    }
    void Start()
    {
        scEnv.Eval(@"
        console.log('hello world');
        ");
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
