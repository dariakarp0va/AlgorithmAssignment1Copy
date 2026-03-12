using System;

namespace AlgorithmAssignment1Copy;

public class MainAlgorithm
{
    private ListOfChars _array = new();
    private ListOfString _tokens = new();
    private String _splitTogether = "";
    private ListOfString _result = new();
    private ListOfString _operators1level = new();
    private ListOfString _operators2level = new();
    private ListOfString _operators3level = new();
    private Stack _stackForPostinfixation = new();
    private Stack _stackForInitialisation = new();

    public void CreatingListOfOperators()
    {
        foreach (var operators in "+-")
        {
            _operators1level.Add(operators.ToString());
        }
        foreach (var operators in "*/")
        {
            _operators2level.Add(operators.ToString());
        }
        foreach (var operators in "^")
        {
            _operators3level.Add(operators.ToString());
        }
        foreach (var operators in "v")
        {
            _operators3level.Add("sin");
            _operators3level.Add("cos");
        }
    }
    public void Tokenisation(string num)
    {
        foreach (var symbol in num)
        {
            
            if (char.IsDigit(symbol))
            {
                _array.Add(symbol);
            }
            else if (_operators1level.Contains(symbol.ToString()) || _operators2level.Contains(symbol.ToString()) || _operators3level.Contains(symbol.ToString()))
            {
                _splitTogether = _array.GetStringTogether();
                Console.WriteLine($"Split {_splitTogether}");
                _tokens.Add(_splitTogether);
                _tokens.Add(symbol.ToString());
            }
            else if (symbol.ToString() == "n")
            {
                _tokens.Add("sin");
            }
            else if (symbol.ToString() == "c")
            {
                _tokens.Add("cos");
            }
            else if (symbol.ToString() == "(")
            {
                _tokens.Add(symbol.ToString());
            }

        }
        _splitTogether = _array.GetStringTogether();
        Console.WriteLine($"Split {_splitTogether}");
        _tokens.Add(_splitTogether);
    }

    public void Postinfixation()
    {
        int i = 0;
        while (i < _tokens.Count())
        {
            if (int.TryParse(_tokens.GetAt(i), out var token))
            {
                _result.Add(_tokens.GetAt(i));
            }
            else if (_operators3level.Contains(_tokens.GetAt(i)) || _tokens.GetAt(i) == "(")
            {
                _stackForPostinfixation.Push(_tokens.GetAt(i));
            }
            else if (_operators2level.Contains(_tokens.GetAt(i)))
            {
                while (_stackForPostinfixation.Peek() == "^")
                {
                    Console.WriteLine("opp");
                    _result.Add(_stackForPostinfixation.Pull());
                }
                _stackForPostinfixation.Push(_tokens.GetAt(i));
                Console.WriteLine($"TOKEN {_tokens.GetAt(i)}");
                Console.WriteLine($"Peek {_stackForPostinfixation.Peek()}");
            }
            else if (_operators1level.Contains(_tokens.GetAt(i)))
            {
                if (_operators2level.Contains(_stackForPostinfixation.Peek()) || _operators3level.Contains(_stackForPostinfixation.Peek()))
                {
                    while (0 < _stackForPostinfixation.Count())
                    {
                        Console.WriteLine("//");
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
            Console.WriteLine("//");
            _result.Add(_stackForPostinfixation.Pull());
        }

        int b = 0;
        while (b <= _result.Count())
        {
            Console.WriteLine(_result.GetAt(b));
            b++;
        }
    }

    public void Initialisation()
    {
        double result = 0;
        int i = 0;
        while (i < _result.Count())
        {
            Console.WriteLine(_result.GetAt(i));
            if (int.TryParse(_result.GetAt(i), out var token))
            {
                
                _stackForInitialisation.Push(_result.GetAt(i));
            }
            else if (_operators1level.Contains(_result.GetAt(i)) || _operators2level.Contains(_result.GetAt(i)) || _operators3level.Contains(_result.GetAt(i)))
            {
                int a = int.Parse(_stackForInitialisation.Pull());
                var b = int.TryParse(_stackForInitialisation.Pull(), out int secondnum );
                if (_result.GetAt(i) == "+")
                {
                    result = a + secondnum;
                }
                else if (_result.GetAt(i) == "-")
                {
                    result = secondnum - a;
                }
                else if (_result.GetAt(i) == "*")
                {
                    result = a * secondnum;
                }
                else if (_result.GetAt(i) == "/")
                {
                    if (a == 0)
                    {
                        throw new Exception("Can't divide on 0");
                    }
                    result = secondnum / a;
                }
                else if (_result.GetAt(i) == "^")
                {
                    result = 1;
                    for (int y = 0; y < a; y++)
                    {
                        result *= secondnum;
                    }
                }
                else if (_result.GetAt(i) == "sin")
                {
                    result = Math.Sin(a);
                }
                else if (_result.GetAt(i) == "cos")
                {
                    result = Math.Cos(a);
                }
                _stackForInitialisation.Push(result.ToString());
            }
            i++;
        }
        Console.WriteLine(double.Parse(_stackForInitialisation.Pull()));
    }
}