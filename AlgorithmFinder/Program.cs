

float[] numbers =
{
    1 , 7 , 17 , 24 , 41
};

float targetValue = 205;

const float targetTolerance = .25f;

bool findAllSolutions = true;

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

    bool isSolutionFound = false;
    int solutionIndex = 1;
    while (numbersWithEarlierOperationsList.Count > 0)
    {
        if (isSolutionFound)
        {
            break;
        }
        List<NumbersWithEarlierOperations> newList = new List<NumbersWithEarlierOperations>();
        foreach (NumbersWithEarlierOperations nweo in numbersWithEarlierOperationsList)
        {
            newList.AddRange(GetListNumbersWithEarlierOperation(nweo));   
        }

        numbersWithEarlierOperationsList = newList;
        foreach (NumbersWithEarlierOperations nweo in numbersWithEarlierOperationsList)
        {
            if (nweo.Numbers.Length == 1)
            {
                if (Math.Abs(nweo.Numbers[0] - targetValue) < targetTolerance)
                {
                    Console.WriteLine($"\nAlgorithm {solutionIndex}");
                    WriteOperations(nweo.EarlierOperations);
                    Console.WriteLine($"Result: {nweo.Numbers[0]}");
                    isSolutionFound = true;
                    solutionIndex++;
                    if (!findAllSolutions)
                    {
                        break;
                    }
                }
            }
        }
    } 

    if (!isSolutionFound)
    {
        Console.Write($"There is no solution to find {targetValue} with given numbers");
    }  
    
}


List<NumbersWithEarlierOperations> GetListNumbersWithEarlierOperation(NumbersWithEarlierOperations numbersWithEarlierOperation)
{
    List<NumbersWithEarlierOperations> numbersWithEarlierOperations = new List<NumbersWithEarlierOperations>();

    List<float[]> pairs = GetPairs(numbersWithEarlierOperation.Numbers);

    foreach (float[] pair in pairs)
    {
        float[] restOfTheNumbers = new float[numbersWithEarlierOperation.Numbers.Length-2];
        int index = 0;
        foreach (float value in  numbersWithEarlierOperation.Numbers)
        {
            if (value != pair[0] && value != pair[1])
            {
                restOfTheNumbers[index] = value;
                index++;
            }
        }
        foreach (string operationString in Enum.GetNames(typeof(Operation)))
        {
            Operation operation = (Operation)Enum.Parse(typeof(Operation), operationString);
            NumbersWithEarlierOperations newNumbersWithEarlierOperations = new NumbersWithEarlierOperations 
            {
                Numbers = new float[numbersWithEarlierOperation.Numbers.Length-1],
                EarlierOperations = new List<NumbersWithOperation>()
            };
            newNumbersWithEarlierOperations.Numbers[0] = Calculate(pair[0], pair[1],operation);
            for (int i = 0; i < restOfTheNumbers.Length; i++)
            {
                newNumbersWithEarlierOperations.Numbers[i + 1] = restOfTheNumbers[i];
            }
            newNumbersWithEarlierOperations.EarlierOperations.AddRange(numbersWithEarlierOperation.EarlierOperations);
            newNumbersWithEarlierOperations.EarlierOperations.Add(new NumbersWithOperation
            {
                Number1 = pair[0], 
                Number2 = pair[1],
                Operation = operation
            });
            numbersWithEarlierOperations.Add(newNumbersWithEarlierOperations);
        }
    }
    
    return numbersWithEarlierOperations;
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


float Calculate(float number1, float number2, Operation operation)
{
    switch (operation)
    {
        case Operation.Sum:
            return number1 + number2;
        case Operation.Subtraction:
            return number1 - number2 ;
        case Operation.Multiplication:
            return number1 * number2 ;
        case Operation.Division:
            return number2 == 0?float.MaxValue : number1 / number2;
    }

    return 0;
}

string GetCalculationStringNumbersWithOperation(NumbersWithOperation numbersWithOperation)
{
    return GetCalculationString(numbersWithOperation.Number1, numbersWithOperation.Number2,
        numbersWithOperation.Operation);
}

string GetCalculationString(float value1, float value2, Operation operation)
{
    switch (operation)
    {
        case Operation.Sum:
            return $"{value1} + {value2} = {value1 + value2}";
        case Operation.Subtraction:
            return $"{value1} - {value2} = {value1 - value2}";
        case Operation.Multiplication:
            return $"{value1} * {value2} = {value1 * value2}";
        case Operation.Division:
            return $"{value1} / {value2} = {value1 / value2}";
    }

    return "";
}




void WriteOperations(List<NumbersWithOperation> earlierOperations)
{

//    string result = GetCalculationStringNumbersWithOperation(earlierOperations[0]);

    for (int i = 0; i < earlierOperations.Count; i++)
    {
        Console.WriteLine(GetCalculationStringNumbersWithOperation(earlierOperations[i]));
    }
    
  //  return result;
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


