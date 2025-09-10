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
    }

    float x = 0;
    float repTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime;
        bool switcher = repTime / 2.0f >= Mathf.Repeat(x, repTime);
        if (switcher)
        {
                textMesh.text = scEnv.Eval<string>(@"
            (function()
            {
                console.log('hello world');
                return 'Hello_World';
            })()
            ");
        }
        else
        { 
            
            textMesh.text = scEnv.Eval<string>(@"
                (function()
                {
                    console.log('goodbye world');
                    return 'GoodBye_World';
                })()
                ");
        }
    }

    void OnDestroy()
    {
        //LEnv.Dispose();
    }
}
