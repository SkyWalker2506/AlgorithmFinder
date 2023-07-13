

float[] numbers = new float[]
{
    1 , 7 , 17 , 24 , 41
};

float result = 208;



FindAlgorithm();



void FindAlgorithm()
{
    string algorithm = "";

    foreach (var combination in GetPairs(numbers))
    {
        foreach (float value in combination)
        {
            Console.Write(value+", ");
        }
        Console.WriteLine("");
        Console.WriteLine("Next combination");

    }

}


List<NumbersWithEarlierOperation> GetListNumbersWithEarlierOperation(NumbersWithEarlierOperation numbersWithEarlierOperation)
{
    List<NumbersWithEarlierOperation> numbersWithEarlierOperations = new List<NumbersWithEarlierOperation>();

    
    
    return numbersWithEarlierOperations;
}

float Calculate(float value1, float value2, Operations operation)
{
    switch (operation)
    {
        case Operations.Sum:
            return value1+value2;
        case Operations.Subtraction:
            return value1-value2;
        case Operations.Multiplication:
            return value1*value2;
        case Operations.Division:
            return value2==0?float.MaxValue:value1/value2;
    }

    return 0;
}

string OperationToString(Operations operation)
{
    switch (operation)
    {
        case Operations.Sum:
            return "+";
        case Operations.Subtraction:
            return "-";
        case Operations.Multiplication:
            return "*";
        case Operations.Division:
            return "/";
    }

    return "";
}

IEnumerable<float[]> GetPairs(float[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] != array[j])
            {
                yield return new[] { array[i], array[j] };
                yield return new[] { array[j], array[i] };
            }
        }
    }
}



enum Operations
{
    Sum,
    Subtraction,
    Multiplication,
    Division
}


struct NumbersWithEarlierOperation
{
    public float[] Numbers; 
    public string Operations;
}
