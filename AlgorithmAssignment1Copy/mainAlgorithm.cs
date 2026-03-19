using System;

namespace AlgorithmAssignment1Copy;

public class MainAlgorithm
{
    private ListOfChars _array = new();
    private ListOfString _tokens = new();
    private ListOfString _letters = new();
    private String _splitTogether = "";
    private ListOfString _result = new();
    private (string, int) _lvl1 = new ValueTuple<string, int>( "+-", 1);
    private (string, int) _lvl2 = new ValueTuple<string, int>( "*/", 2);
    private (string, int) _lvl3 = new ValueTuple<string, int>( "^sincosmaxmin", 3);
    private (string, int) _lvl0 = new ValueTuple<string, int>( "+-*/^sincosmaxmin(),",0);
    private readonly Stack _stackForPostinfixation = new();
    private readonly Stack _stackForInitialisation = new();
    
    public void Tokenisation(string num)
    {
        foreach (var symbol in num)
        {
            
            if (char.IsDigit(symbol) || symbol.ToString() == "." )
            {
                _array.Add(symbol);
            }
            else if (char.IsLetter(symbol))
            {
                _letters.Add(symbol.ToString());
                CheckIfOperator(_letters);
            }
            else if (_lvl0.Item1.Contains(symbol.ToString()))
            {
                _splitTogether = _array.GetStringTogether();
                Console.WriteLine($"Split {_splitTogether}");
                if (_splitTogether != "") 
                {
                    _tokens.Add(_splitTogether);
                }
                _tokens.Add(symbol.ToString());
                
            }

        }
        _splitTogether = _array.GetStringTogether();
        Console.WriteLine($"Split {_splitTogether}");
        if (_splitTogether != "") 
        {
            _tokens.Add(_splitTogether);
        }
    }

    public void Postinfixation()
    {
        int i = 0;
        while (i < _tokens.Count())
        {
            if (double.TryParse(_tokens.GetAt(i), out var token))
            {
                _result.Add(_tokens.GetAt(i));
            }
            else if (_lvl3.Item1.Contains(_tokens.GetAt(i)) || _tokens.GetAt(i) == "(")
            {
                _stackForPostinfixation.Push(_tokens.GetAt(i));
            }
            else if (_lvl2.Item1.Contains(_tokens.GetAt(i)))
            {
                while (_stackForPostinfixation.Peek() != null && _stackForPostinfixation.Peek() != "(" && (_lvl2.Item1.Contains(_stackForPostinfixation.Peek()) || _lvl3.Item1.Contains(_stackForPostinfixation.Peek()) && _stackForPostinfixation.Count() > 0))
                {
                    _result.Add(_stackForPostinfixation.Pull());
                }
                _stackForPostinfixation.Push(_tokens.GetAt(i));
            }
            else if (_lvl1.Item1.Contains(_tokens.GetAt(i)))
            {
                if (_stackForPostinfixation.Peek() != null && (_lvl2.Item1.Contains(_stackForPostinfixation.Peek()) || _lvl3.Item1.Contains(_stackForPostinfixation.Peek())))
                {
                    while (0 < _stackForPostinfixation.Count() && _stackForPostinfixation.Peek() != "(")
                    {
                        _result.Add(_stackForPostinfixation.Pull());
                    }
                }
                _stackForPostinfixation.Push(_tokens.GetAt(i));
            }
            else if (_tokens.GetAt(i) == ")")
            {
                while (_stackForPostinfixation.Peek() != "(")
                {
                    _result.Add(_stackForPostinfixation.Pull());
                }

                _stackForPostinfixation.Pull();
            }
            i++;
            
        }
        while (0 < _stackForPostinfixation.Count())
        {
            _result.Add(_stackForPostinfixation.Pull());
        }
    }

    public void Initialisation()
    {
        double result = 0;
        int i = 0;
        while (i < _result.Count())
        {
            if (double.TryParse(_result.GetAt(i), out var token))
            {
                
                _stackForInitialisation.Push(_result.GetAt(i));
            }
            else if (_lvl0.Item1.Contains(_result.GetAt(i)))
            {
                if (_result.GetAt(i) == "+")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    var b = double.TryParse(_stackForInitialisation.Pull(), out double secondnum );
                    result = a + secondnum;
                    Console.WriteLine($"{a} + {secondnum} = {result}");
                }
                else if (_result.GetAt(i) == "-")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    var b = double.TryParse(_stackForInitialisation.Pull(), out double secondnum );
                    result = secondnum - a;
                    Console.WriteLine($"{secondnum} - {a} = {result}");
                }
                else if (_result.GetAt(i) == "*")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    var b = double.TryParse(_stackForInitialisation.Pull(), out double secondnum );
                    result = a * secondnum;
                    Console.WriteLine($"{a} * {secondnum} = {result}");
                }
                else if (_result.GetAt(i) == "/")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    var b = double.TryParse(_stackForInitialisation.Pull(), out double secondnum );
                    if (a == 0)
                    {
                        throw new Exception("Can't divide on 0");
                    }
                    result = secondnum / a;
                    Console.WriteLine($"{secondnum} / {a} = {result}");
                }
                else if (_result.GetAt(i) == "^")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    var b = double.TryParse(_stackForInitialisation.Pull(), out double secondnum );
                    result = 1;
                    for (int y = 0; y < a; y++)
                    {
                        result *= secondnum;
                    }
                    Console.WriteLine($"{secondnum} ^ {a} = {result}");
                }
                else if (_result.GetAt(i) == "sin")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    result = Math.Sin(a);
                    Console.WriteLine($"sin {a}  = {result}");
                }
                else if (_result.GetAt(i) == "cos")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    result = Math.Cos(a);
                    Console.WriteLine($"cos {a} = {result}");
                }
                else if (_result.GetAt(i) == "min")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    var b = double.TryParse(_stackForInitialisation.Pull(), out double secondnum );
                    result = Math.Min(secondnum, a);
                    Console.WriteLine($"Min {secondnum}, {a} = {result}");
                }
                else if (_result.GetAt(i) == "max")
                {
                    double a = double.Parse(_stackForInitialisation.Pull());
                    var b = double.TryParse(_stackForInitialisation.Pull(), out double secondnum );
                    result = Math.Max(secondnum, a);
                    Console.WriteLine($"Max {secondnum}, {a} = {result}");
                }
                _stackForInitialisation.Push(result.ToString());
            }
            i++;
        }
        Console.WriteLine(double.Parse(_stackForInitialisation.Pull()));
    }

    public void CheckIfOperator(ListOfString letters)
    {
        var w = letters.GetStringTogether();
        Console.WriteLine(letters.GetStringTogether());
        if (w.Contains("sin") || w.Contains("cos") || w.Contains("min") || w.Contains("max"))
        {
            Console.WriteLine("OOO");
            _tokens.Add(letters.GetStringTogether());
            letters.ClearList();
        }
    }
}