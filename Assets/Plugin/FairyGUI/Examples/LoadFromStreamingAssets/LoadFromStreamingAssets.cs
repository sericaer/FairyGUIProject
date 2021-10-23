using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromStreamingAssets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UIPackage.SetLoader(new StreamingAssetsLoader());
        //UIPackage.AddPackage("SingleButton2");

        //var com = UIPackage.CreateObject("SingleButton", "Component1").asCom;
        //GRoot.inst.AddChild(com);

        UIPackageXML.SetLoader(new StreamingAssetsLoader());
        UIPackageXML.AddPackage(@"D:\git\FairyGUIStudy\FairyGUISource\SingleButton");

        var com = UIPackageXML.CreateObject("Package", "Component1").asCom;
        GRoot.inst.AddChild(com);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
