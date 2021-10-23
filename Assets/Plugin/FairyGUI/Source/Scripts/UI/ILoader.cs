using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FairyGUI
{
    public interface ILoader
    {
        byte[] LoadBytes(string fileName, string ext);
        AudioClip LoadAudioClip(string fileName, string ext, Type type);
        Texture2D LoadTexture2D(string filePath, string ext);
    }

    public class ResourcesLoader : ILoader
    {
        public AudioClip LoadAudioClip(string fileName, string ext, Type type)
        {
            throw new NotImplementedException();
        }

        public byte[] LoadBytes(string fileName, string ext)
        {
            var asset = Resources.Load(fileName) as TextAsset;
            return asset == null ? null : asset.bytes;
        }

        public Texture2D LoadTexture2D(string filePath, string ext)
        {
            throw new NotImplementedException();
        }
    }


    public class StreamingAssetsLoader : ILoader
    {
        public AudioClip LoadAudioClip(string fileName, string ext, Type type)
        {
            throw new NotImplementedException();
        }

        public byte[] LoadBytes(string fileName, string ext)
        {
            var path = $"{Application.streamingAssetsPath}/{fileName}{ext}";
            if(!File.Exists(path))
            {
                return null;
            }

            return File.ReadAllBytes(path) ;
        }

        public Texture2D LoadTexture2D(string filePath, string ext)
        {
            throw new NotImplementedException();
        }
    }

#if UNITY_EDITOR
    public class AssetDataLoader:ILoader
    {
        public AudioClip LoadAudioClip(string fileName, string ext, Type type)
        {
            throw new NotImplementedException();
        }

        public byte[] LoadBytes(string fileName, string ext)
        {
            var asset = AssetDatabase.LoadAssetAtPath(fileName + ext, typeof(TextAsset)) as TextAsset;
            return asset.bytes;
        }

        public Texture2D LoadTexture2D(string filePath, string ext)
        {
            throw new NotImplementedException();
        }
    }
#endif
}