using System;

public class Fraction
{
    private int _top;
    private int _bottom;
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }

    public void UpdateTop(int top)
    {
        _top = top;
    }

    public void UpdateBottom(int bottom)
    {
        _bottom = bottom;
    }

}