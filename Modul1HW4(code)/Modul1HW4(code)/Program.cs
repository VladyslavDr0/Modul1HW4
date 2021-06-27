﻿/*
Создать массив на N элементов, где N указывается с консольной строки.+
Заполнить его случайными числами от 1 до 26 включительно.+
Создать 2 массива, где в 1 массиве будут значение только четных значений, а во втором нечетных.+
Заменить числа в 1 и 2 массиве на буквы английского алфавита.+
Значения ячеек этих массивов равны порядковому номеру каждой буквыв алфавите.+
Если же буква является одной из списка (a, e, i, d, h, j) то она должна быть в верхнем регистре.+
Вывести на экран результат того, в каком из массивов будет больше букв в верхнем регистре.+
Вывести оба массива на экран.+
Каждый из массивов должен быть выведен 1 строкой, где его значения будут разделены пробелом.+
 */

using System;

Console.Write("Enter array size: ");

int.TryParse(Console.ReadLine(), out var arraySize);

var arrayOfIntegers = new int[arraySize];

FillingArrayWithRandomNumbers(arrayOfIntegers, 1, 27);

var arraySizeEven = GetNumberOfEvenElementsInTheArray(arrayOfIntegers);
var arraySizeOdd = GetNumberOfOddElementsInTheArray(arrayOfIntegers);

var arrayOfEvenIntegers = new int[arraySizeEven];
var arrayOfOddIntegers = new int[arraySizeOdd];

var counterForEven = 0;
var counterForOdd = 0;

// заполнение чётных и нечётных массивов
foreach (var i in arrayOfIntegers)
{
    if (i % 2 == 0)
    {
        arrayOfEvenIntegers[counterForEven++] = i;
    }
    else
    {
        arrayOfOddIntegers[counterForOdd++] = i;
    }
}

// для наглядности
Console.WriteLine();
Console.WriteLine($"arrayOfIntegers[]: {string.Join(" ", arrayOfIntegers)}");
Console.WriteLine();
Console.WriteLine($"arrayOfEvenIntegers[]: {string.Join(" ", arrayOfEvenIntegers)}");
Console.WriteLine($"arrayOfOddIntegers[]: {string.Join(" ", arrayOfOddIntegers)}");
Console.WriteLine();

var arrayOfEvenLetters = ReplaceNumbersWithLetters(arrayOfEvenIntegers);
var arrayOfOddLetters = ReplaceNumbersWithLetters(arrayOfOddIntegers);

// для наглядности
Console.WriteLine($"arrayOfEvenLetters[]: {string.Join(" ", arrayOfEvenLetters)}");
Console.WriteLine($"arrayOfOddLetters[]: {string.Join(" ", arrayOfOddLetters)}");
Console.WriteLine();

SubstitutionOfLettersByConditionToUppercase(arrayOfEvenLetters);
SubstitutionOfLettersByConditionToUppercase(arrayOfOddLetters);

// для наглядности
Console.WriteLine($"arrayOfEvenLetters[]: {string.Join(" ", arrayOfEvenLetters)}");
Console.WriteLine($"arrayOfOddLetters[]: {string.Join(" ", arrayOfOddLetters)}");
Console.WriteLine();

var quantityEvenLetters = NumberOfUppercaseLettersInArray(arrayOfEvenLetters);
var quantityOddLetters = NumberOfUppercaseLettersInArray(arrayOfOddLetters);

Console.WriteLine($"quantityEvenLetters: {quantityEvenLetters}");
Console.WriteLine($"quantityOddLetters: {quantityOddLetters}");
Console.WriteLine();

if (quantityEvenLetters > quantityOddLetters)
{
    Console.WriteLine("The number of capital letters is greater in the array: arrayOfEvenLetters[]");
}
else if (quantityEvenLetters < quantityOddLetters)
{
    Console.WriteLine("The number of capital letters is greater in the array: arrayOfOddLetters[]");
}
else
{
    Console.WriteLine("The number of capital letters is equally");
}

int NumberOfUppercaseLettersInArray(string[] arrayOfLetters)
{
    var counterUppercaseLetter = 0;

    foreach (var letter in arrayOfLetters)
    {
        var temp = letter;

        if (temp.ToUpper() == letter)
        {
            counterUppercaseLetter++;
        }
    }

    return counterUppercaseLetter;
}

void SubstitutionOfLettersByConditionToUppercase(string[] arrayOfLetter)
{
    var arrayOfLettersThatMustBeUppercase = new string[] { "a", "e", "i", "d", "h", "j" };

    for (var i = 0; i < arrayOfLetter.Length; i++)
    {
        foreach (var symbol in arrayOfLettersThatMustBeUppercase)
        {
            if (arrayOfLetter[i] == symbol)
            {
                arrayOfLetter[i] = arrayOfLetter[i].ToUpper();
                counterForEven++;
            }
        }
    }
}

string[] ReplaceNumbersWithLetters(int[] arrayOfIntegers)
{
    var arrayOfLetter = new string[arrayOfIntegers.Length];

    for (var i = 0; i < arrayOfIntegers.Length; i++)
    {
        arrayOfLetter[i] = Enum.GetName(typeof(Alphabet), arrayOfIntegers[i]).ToLower();
    }

    return arrayOfLetter;
}

int GetNumberOfEvenElementsInTheArray(int[] arrayOfIntegers)
{
    var counterEven = 0;

    foreach (var i in arrayOfIntegers)
    {
        if (i % 2 == 0)
        {
            counterEven++;
        }
    }

    return counterEven;
}

int GetNumberOfOddElementsInTheArray(int[] arrayOfIntegers)
{
    var counterOdd = 0;

    foreach (var i in arrayOfIntegers)
    {
        if (i % 2 != 0)
        {
            counterOdd++;
        }
    }

    return counterOdd;
}

void FillingArrayWithRandomNumbers(int[] arrayOfIntegers, int min, int max)
{
    for (var i = 0; i < arrayOfIntegers.Length; i++)
    {
        arrayOfIntegers[i] = new Random().Next(min, max);
    }
}