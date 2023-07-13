

float[] numbers = new float[]
{
    1 , 7 , 17 , 24 , 41
};

float result = 208;



FindAlgorithm();



void FindAlgorithm()
{
    string algorithm = "";

    NumbersWithEarlierOperations numbersWithEarlierOperations = new NumbersWithEarlierOperations
    {
        Numbers = numbers,
        EarlierOperations = new List<NumbersWithOperation>()
    };

    List<NumbersWithEarlierOperations> numbersWithEarlierOperationsList =
        new List<NumbersWithEarlierOperations> { numbersWithEarlierOperations };
    
    while (numbersWithEarlierOperationsList.Count > 0)
    {
        List<NumbersWithEarlierOperations> newList = numbersWithEarlierOperationsList;
        foreach (NumbersWithEarlierOperations nweo in numbersWithEarlierOperationsList)
        {
            newList.AddRange(GetListNumbersWithEarlierOperation(nweo));   
        }

        numbersWithEarlierOperationsList = newList;
        foreach (NumbersWithEarlierOperations nweo in numbersWithEarlierOperationsList)
        {
            if (nweo.Numbers.Length == 1)
            {
                
            }
        }
    }

    if (numbersWithEarlierOperationsList.Count == 0)
    {
        Console.Write($"There is no solution fo find {result} with given numbers");
    }  
    
}


List<NumbersWithEarlierOperations> GetListNumbersWithEarlierOperation(NumbersWithEarlierOperations numbersWithEarlierOperation)
{
    List<NumbersWithEarlierOperations> numbersWithEarlierOperations = new List<NumbersWithEarlierOperations>();

    List<float[]> pairs = GetPairs(numbersWithEarlierOperation.Numbers);

    foreach (float[] pair in pairs)
    {
        
    }
    
    return numbersWithEarlierOperations;
}

float Calculate(NumbersWithOperation numbersWithOperation)
{
    switch (numbersWithOperation.Operation)
    {
        case Operation.Sum:
            return numbersWithOperation.Number1 + numbersWithOperation.Number1;
        case Operation.Subtraction:
            return numbersWithOperation.Number1 -numbersWithOperation.Number1 ;
        case Operation.Multiplication:
            return numbersWithOperation.Number1 * numbersWithOperation.Number1 ;
        case Operation.Division:
            return numbersWithOperation.Number1 == 0?float.MaxValue:numbersWithOperation.Number1 / numbersWithOperation.Number1 ;
    }

    return 0;
}

string GetCalculationStringNumbersWithOperation(NumbersWithOperation numbersWithOperation)
{
    return GetCalculationString(numbersWithOperation.Number1.ToString(), numbersWithOperation.Number2.ToString(),
        numbersWithOperation.Operation);
}

string GetCalculationString(string value1, string value2, Operation operation)
{
    switch (operation)
    {
        case Operation.Sum:
            return $"({value1} + {value2})";
        case Operation.Subtraction:
            return $"({value1} - {value2})";
        case Operation.Multiplication:
            return $"{value1} * {value2}";
        case Operation.Division:
            return $"{value1} / {value2}";
    }

    return "";
}




string GetEarlierOperationsString(List<NumbersWithOperation> earlierOperations)
{

    if (earlierOperations.Count == 0)
    {
        return "";
    }

    string result = GetCalculationStringNumbersWithOperation(earlierOperations[0]);

    for (int i = 1; i < earlierOperations.Count; i++)
    {
        result = GetCalculationString(result, GetCalculationStringNumbersWithOperation(earlierOperations[i]),
            earlierOperations[i].Operation);
    }
    
    return result;
}


string OperationToString(Operation operation)
{
    switch (operation)
    {
        case Operation.Sum:
            return "+";
        case Operation.Subtraction:
            return "-";
        case Operation.Multiplication:
            return "*";
        case Operation.Division:
            return "/";
    }

    return "";
}

List<float[]> GetPairs(float[] array)
{
    List<float[]> pairs = new List<float[]>();
    
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] != array[j])
            {
                pairs.Add(new[] { array[i], array[j] });
                pairs.Add(new[] { array[j], array[i] });
            }
        }
    }

    return pairs;
}



enum Operation
{
    Sum,
    Subtraction,
    Multiplication,
    Division
}


struct NumbersWithEarlierOperations
{
    public float[] Numbers;
    public List<NumbersWithOperation> EarlierOperations;
    
}

struct NumbersWithOperation
{
    public float Number1; 
    public float Number2; 
    public Operation Operation;
}


