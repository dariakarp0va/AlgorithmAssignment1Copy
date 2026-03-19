using System;

namespace AlgorithmAssignment1Copy;

public class ListOfTuples
{
    private (string, int)[] _array = new (string, int) [20];

    private int _pointer = 0;

    private string result;

    public void Add((string, int) element)
    {
        _array[_pointer] = element;
        _pointer += 1;
        
        if (_pointer == _array.Length)
        {
            var extendedArray = new (string, int)[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray; 
        }

    }

    public (string, int) GetAt(int index)
    {
        return _array[index];
    }
    public void Remove((string, int) element)
    {
        for (var i = 0; i < _pointer; i++)
        {
            if (_array[i] == element)
            {
                for (var j = i; j < _pointer - 1; j++)
                {
                    _array[j] = _array[j + 1];
                }

                _pointer -= 1;
                return;
            }
        }
    }
    
    public int IndexOf((string, int) element)
    {
        for (var i = 0; i < _array.Length; i++)
        {
            if (_array[i] == element)
            {
                return i;
            }
        }

        return -1;
    }
    
    public bool Contains((string, int) element)
    {
        return IndexOf(element) != -1;
    }

    public int Count()
    {
        return _pointer;
    }

    public string GetStringTogether()
    {
        int i = 0;
        string result = "";
        while (i < _pointer)
        {
            result += _array[i];
            i++;
        }
        
        
        return result;
    }

    public void ClearList()
    {
        _pointer = 0;
    }
    
    
    
}