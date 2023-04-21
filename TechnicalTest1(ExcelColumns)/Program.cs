string getColumnName(int value) {
    int asciiAValue = (int)('A');
    string name = "";

    int dif;

    while (value > 0) {
        name = name.Insert(0, ((char)(((value - 1) % 26) + asciiAValue)).ToString());
        value--;
        value /= 26;
    }

    return name;
}

int getColumnNumber(string value) {
    value = value.ToLower();
    int columnNumber = 0;
    int multiplier = (int)Math.Pow(26, value.Length - 1);

    foreach (var c in value) {
        columnNumber += multiplier * (c - 'a' + 1);
        multiplier /= 26;
    }

    return columnNumber;
}

int value = 1;
while(value != 3) {
    Console.WriteLine("What conversion would you like? 1-toColumnNumber, 2-toColumnName, 3-exit");
    value = Convert.ToInt32(Console.ReadLine());
    switch (value) {
        case 1:
            Console.WriteLine("Please input column name");
            string columnName = Console.ReadLine();
            Console.WriteLine($"Column number for {columnName} is {getColumnNumber(columnName)}");
            break;
        case 2:
            Console.WriteLine("Please input column number");
            string input = Console.ReadLine();
            if(!int.TryParse(input, out int columnNumber)) {
                Console.WriteLine("Input is not correct format please enter integer");
                break;
            }

            Console.WriteLine($"Column name for {columnNumber} is {getColumnName(columnNumber)}");
            break;
        case 3:
            break;
        default:
            Console.WriteLine("Input is not correct please input 1 2 or 3");
            break;
    }
}
Console.WriteLine("Bye!");
