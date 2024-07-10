using System;

public abstract class PdValue<T>
{
    protected string ReceiveSymbol;
    protected LibPdInstance PdInstance;
    public T Value 
    { 
        get { return Value; }
        set 
        { 
            Value = value; 
            SendValue();
        }
    }

    public PdValue () {}
    public PdValue (string receiveSymbol)
        : this () 
        => ReceiveSymbol = receiveSymbol;
    
    public PdValue (string receiveSymbol, T value)
        : this (receiveSymbol)
        => Value = value;

    public PdValue (string receiveSymbol, T value, LibPdInstance pdInstance)
        : this (receiveSymbol, value)
        => PdInstance = pdInstance;
    
    protected abstract void SendValue();
}

public class PdFloat : PdValue<float>
{
    protected override void SendValue ()
    {
        PdInstance.SendFloat(ReceiveSymbol, Value);
    }
}