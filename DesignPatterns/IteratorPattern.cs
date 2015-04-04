/*
 This is a custom implementation of Iterator pattern in C#

 For further reading refer: http://www.codeproject.com/Tips/359873/Csharp-Iterator-Pattern-demystified
*/
using System;
using System.Collections.Generic;

public interface IMyEnumerator<T>
{
    T Current { get; }
    bool MoveNext();
    void Reset();
}

public class FibonacciSequence : IMyEnumerator<int>
{
    private int _numberOfValues;
    private int _currentPosition;
    private int _previousTotal;
    private int _currentTotal;

    public FibonacciSequence(int numberOfValues)
    {
        _numberOfValues = numberOfValues;
    }

    public int Current
    {
        get { return _currentTotal; }
    }
    public bool MoveNext()
    {
        if (_currentPosition == 0)
        {
            _currentTotal = 1;
        }
        else
        {
            int newTotal = _previousTotal + _currentTotal;
            _previousTotal = _currentTotal;
            _currentTotal = newTotal;
        }
        _currentPosition++;

        return (_currentPosition <= _numberOfValues);
    }

    public void Reset()
    {
        _numberOfValues = _currentPosition = _previousTotal = _currentTotal = 0;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var seq = new FibonacciSequence(7);
        IMyEnumerator<int> iter = seq;
        while (iter.MoveNext())
        {
            Console.Write(iter.Current + " ");
        }
        iter.Reset();
        Console.ReadLine();
    }
}