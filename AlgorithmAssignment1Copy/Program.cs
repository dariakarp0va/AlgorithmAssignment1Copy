// See https://aka.ms/new-console-template for more information

using System;
using AlgorithmAssignment1Copy;

var num = Console.ReadLine();
var mainalgorithms = new MainAlgorithm();
mainalgorithms.Tokenisation(num);
mainalgorithms.Postinfixation();
mainalgorithms.Initialisation();