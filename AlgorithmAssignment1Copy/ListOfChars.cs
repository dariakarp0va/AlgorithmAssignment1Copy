namespace AlgorithmAssignment1Copy;

public class ListOfChars
{
    private char[] _array = new char [20];

    private int _pointer = 0;
    
    public void Add(char element)
    {
        _array[_pointer] = element;
        _pointer += 1;
        
        if (_pointer == _array.Length)
        {
            var extendedArray = new char[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray; 
        }

    }

    public char GetAt(int index)
    {
        return _array[index];
    }
    public void Remove(char element)
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

    public string GetStringTogether()
    {
        int i = 0;
        string result = "";
        while (i < _pointer)
        {
            result += _array[i];
            i++;
        }

        _pointer = 0;
        
        return result;
    }
    
    public int IndexOf(char element)
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
    
    public bool Contains(char element)
    {
        return IndexOf(element) != -1;
    }

    public int Count()
    {
        return _pointer;
    }
    
}