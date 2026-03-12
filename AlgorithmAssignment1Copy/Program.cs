// See https://aka.ms/new-console-template for more information

using AlgorithmAssignment1Copy;

var num = Console.ReadLine();
var mainalgorithms = new MainAlgorithm();
mainalgorithms.CreatingListOfOperators();
mainalgorithms.Tokenisation(num);
mainalgorithms.Postinfixation();
mainalgorithms.Initialisation();