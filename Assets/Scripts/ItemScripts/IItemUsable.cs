using System;

public interface IITemUsable
{
    void Use();

    event EventHandler OnUsed;
}