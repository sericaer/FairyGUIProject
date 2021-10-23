using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIPackage.SetLoader(new ResourcesLoader());
        UIPackage.AddPackage("SingleButton");

        var com = UIPackage.CreateObject("SingleButton", "Component1").asCom;
        GRoot.inst.AddChild(com);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
