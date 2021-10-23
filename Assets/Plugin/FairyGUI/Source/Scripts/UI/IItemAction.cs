using System;

namespace FairyGUI
{
    public interface IItemAction
    {
    }

    public interface IButtonAction : IItemAction
    {
        Action OnClick { get; }
    }
}