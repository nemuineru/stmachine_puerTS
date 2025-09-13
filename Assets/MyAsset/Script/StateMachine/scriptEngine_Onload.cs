using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Puerts;
using Puerts.WebGL;
using Puerts.TSLoader;


//lua enviroments loads as static.
//its because of the convenience.

public class scriptEngine_Onload : MonoBehaviour
{
    public TMPro.TMP_Text textMesh;
    static scriptEngine_Onload main;

    public Puerts.JsEnv scEnv;
    // Start is called before the first frame update
    void Awake()
    {
        main = this;
        if (scEnv == null)
        {
            //scEnv = Puerts.WebGL.MainEnv.Get(new TSLoader());
            scEnv = new Puerts.JsEnv();
        }
    }
    void Start()
    {
    }

    float x = 0;
    float repTime = 1.0f;
    bool isInDebug = true;

    // Update is called once per frame
    void Update()
    {
        if (isInDebug)
        {
            test_1();
        }
    }

    void OnDestroy()
    {
        scEnv.Dispose();
    }

    void test_1()
    {
        x += Time.deltaTime;
        bool switcher = repTime / 2.0f >= Mathf.Repeat(x, repTime);
        if (textMesh != null)
        {
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
    }

    void test_2()
    {
        x += Time.deltaTime;
        bool switcher = repTime / 2.0f >= Mathf.Repeat(x, repTime);
        if (textMesh != null)
        {
            string scTex = @"
            (executer_01()
            { 
                console.log('hello world');
                return 'Hello_World';
            })()
            ";
            textMesh.text = scEnv.Eval<string>(scTex);
        }
    }
}
