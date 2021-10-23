using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class SceneMain : MonoBehaviour
{
    LuaEnv luaenv = null;

    // Start is called before the first frame update
    void Start()
    {

        UIPackageXML.SetLoader(new StreamingAssetsLoader());

        var path = Application.streamingAssetsPath + "/mods/native/UI";
        UIPackageXML.AddPackage(path);


        var com = UIPackageXML.CreateObject("Package", nameof(SceneMain)).asCom;
        GRoot.inst.AddChild(com);


        luaenv = new LuaEnv();

        luaenv.AddLoader((ref string filename) =>
        {
            if (filename == "SceneMain")
            {
                filename = $"{Application.streamingAssetsPath}/mods/native/UI/assets/Package1/{filename}.lua";

                return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(filename));
                //return System.Text.Encoding.UTF8.GetBytes(script);
            }
            return null;
        });

        luaenv.DoString("require 'SceneMain'");

        LuaTable s = luaenv.Global.Get<LuaTable>("SceneMain");//”≥…‰µΩLuaTable£¨by ref
        var t = s.Get<LuaTable>("UI_DEFINE");
        t.ForEach<string, object>((key, obj) =>
        {
            Debug.Log(key);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (luaenv != null)
        {
            luaenv.Tick();
        }
    }

    void OnDestroy()
    {
        luaenv.Dispose();
    }
}
