using System;

public interface IItemUsable
{
    void Use();

    event EventHandler OnUsed;
}