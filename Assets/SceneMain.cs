using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        UIPackageXML.SetLoader(new StreamingAssetsLoader());

        var path = Application.streamingAssetsPath + "/mods/native/UI";
        UIPackageXML.AddPackage(path);


        var com = UIPackageXML.CreateObject("Package", nameof(SceneMain)).asCom;
        GRoot.inst.AddChild(com);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
