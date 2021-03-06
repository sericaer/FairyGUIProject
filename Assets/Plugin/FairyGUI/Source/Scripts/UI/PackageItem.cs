using System.Collections;
using UnityEngine;
using FairyGUI.Utils;
using System;

namespace FairyGUI
{
	/// <summary>
	/// 
	/// </summary>
	public class PackageItem
	{
		public UIPackage owner;

		public PackageItemType type;
		public string id;
		public string name;
		public int width;
		public int height;
		public string file;
		public bool decoded;
		public bool exported;

		//image
		public Rect? scale9Grid;
		public bool scaleByTile;
		public int tileGridIndice;
		public NTexture texture;

		//movieclip
		public float interval;
		public float repeatDelay;
		public bool swing;
		public MovieClip.Frame[] frames;

		//component
		public XML componentData;
		public DisplayListItem[] displayList;
		public UIObjectFactory.GComponentCreator extensionCreator;

		//font
		public BitmapFont bitmapFont;

		//sound
		public AudioClip audioClip;

		//misc
		public byte[] binary;

		public object Load()
		{
			return owner.GetItemAsset(this);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class DisplayListItem
	{
		public PackageItem packageItem;
		public string type;
		public XML desc;
		public int listItemCount;

		public IItemAction action;

		public DisplayListItem(PackageItem pi, string type)
		{
			this.packageItem = pi;
			this.type = type;

			if (pi != null && pi.type == PackageItemType.Component)
            {
                string extention = pi.componentData.GetAttribute("extention");
				switch(extention)
                {
					case "Button":
						action = new ButtonAction();
						break;
                }
            }
		}
	}

    internal class ButtonAction : IButtonAction
	{
		public Action OnClick => new Action(() => { Debug.Log("Button Click"); });
	}
}
