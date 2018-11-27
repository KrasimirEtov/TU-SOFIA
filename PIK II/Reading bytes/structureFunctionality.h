#ifndef STRUCTUREFUNCTIONALITY_H_INCLUDED
#define STRUCTUREFUNCTIONALITY_H_INCLUDED

void Menu() // prints menu
{
    printf("------------------------------------------------\n");
    printf(" 1. Print lowest and highest price for a month.\n\n");
    printf(" 2. Print the most winning product for a month.\n\n");
    printf(" 3. Write new info to binary file.\n\n");
    printf(" 4. Print info for a month from file.\n\n");
    printf(" 5. Exit.\n");
    printf("------------------------------------------------\n");
} // end of Menu()

void printMonth() // prints months
{
    printf("\nChoose month:\n");
    printf(" 1. January\n 2. February\n 3. March\n 4. April\n 5. May\n 6. June\n 7. July\n");
    printf(" 8.August\n 9. September\n 10. October\n 11. November\n 12. December\n 13. Exit\n");
} // end of printMonth()

void returnBuySellChoice(int *choice) // choose bought or sold
{
    printf("\nChoose BOUGHT or SOLD:\n");
    printf("1. Bought | 2. Sold | 3. EXIT\n");
    scanf("%d", choice); // user chooses type of the deal to a pointer
    if ((*choice) == 3) exit(EXIT_SUCCESS); // if  the user types 3 the program shutdowns
} // end of returnBuySellChoice()

void createNewInfo()
{
    int BuySellChoice, monthNumber;

    returnBuySellChoice(&BuySellChoice); // BuySellChoice gets the value entered by user about the choice - bought or sold

    switch (BuySellChoice)
    {
    case 1: // if bought is selected
        returnMonthChoose(&monthNumber); // monthNumber gets the value entered by user and gets the month number
        FileName = createFileName(monthNumber, BuySellChoice); // creates filename based upon user choice of month and type of deal(bought, sold)
        getCurrentTime(monthNumber); // writes date into the Date structure based upon the monthNumber choice by used

        enterProductInfo(); // fill the Info structure with data
        writeBinaryFile(FileName); // write the Info structure to a binary file according proper filename for every choose month
        break;

    case 2: // if sold is selected
        returnMonthChoose(&monthNumber); // monthNumber gets the value entered by user and gets the month number
        FileName = createFileName(monthNumber, BuySellChoice); // creates filename based upon user choice of month and type of deal(bought, sold)
        getCurrentTime(monthNumber); // writes date into the Date structure based upon the monthNumber choice by used

        enterProductInfo(); // fill the Info structure with data
        writeBinaryFile(FileName); // write the Info structure to a binary file according proper filename for every choose month
        break;
    case 3:
        exit(EXIT_SUCCESS);
    } // end of switch cases
} // end of createNewInfo()

void returnMonthChoose(int *choice)
{
    printMonth(); // prints months
    scanf("%d", choice); // user chooses month to a pointer
    if ((*choice) == 13) exit(EXIT_SUCCESS); // if user types 13 the program shutdowns
} // end of returnMonthChoose()

char *createFileName(int MonthNumber, int BuySellChoose)
{
    static char FileName2[20];
    strcpy(FileName2, monthName[MonthNumber - 1]); // copy the month name to a local static string FileName2

    switch (BuySellChoose)
    {
    case 1: // if bought is selected
        strcat(FileName2, "BOUGHT.bin"); // adds an identify tag to the filename to know which one is bought
        break;
    case 2: // if sold is selected
        strcat(FileName2, "SOLD.bin"); // adds an identify tag to the filename to know which one is sold
        break;
    }
    return FileName2; // function returns the string with the complete filename
} // end of createFileName()

void enterProductInfo()
{
    printf("\nEnter price:\n");
    scanf("%lf", &Info.price); // fills price to the Info structure
    printf("Enter weight:\n");
    scanf("%lf", &Info.weight); // fills weight to the Info structure
    printf("-------------\n");
    printf("Entered info:\n");
} // end of enterProductInfo()

void PrintProductInfo()
{
    printf(" Date: %d.%d.%d\n Price: %lf\n Weight: %lf\n\n", Info.date.day, Info.date.month, Info.date.year, Info.price, Info.weight); // printish structurata
} // end of PrintProductInfo()

void writeBinaryFile(char *fileName)
{
    FILE *fp = NULL;
    fp = fopen(fileName, "ab+");  // opens file for appending and reading
    if (fp == NULL)
    {
        printf("Error writing file in writeBinaryFile()\n");
        exit(EXIT_FAILURE); // check if file is empty
    }

    if (fwrite(&Info.date.day, sizeof(int), 1, fp) != 1)
    {
        printf("Error writing day in WriteBinaryFile()\n");
        exit(EXIT_FAILURE); // check if there is error writing the day into the file
    }

    if (fwrite(&Info.date.month, sizeof(int), 1, fp) != 1)
    {
        printf("Error writing month in WriteBinaryFile()\n");
        exit(EXIT_FAILURE); // check if there is error writing the month into the file
    }

    if (fwrite(&Info.date.year, sizeof(int), 1, fp) != 1)
    {
        printf("Error writing year in WriteBinaryFile()\n");
        exit(EXIT_FAILURE); // check if there is error writing the year into the file
    }

    if (fwrite(&Info.price, sizeof(double), 1, fp) != 1)
    {
        printf("Error writing price file in WriteBinaryFile()\n");
        exit(EXIT_FAILURE); // check if there is error writing the price into the file
    }

    if (fwrite(&Info.weight, sizeof(double), 1, fp) != 1)
    {
        printf("Error writing weight file in WriteBinaryFile()\n");
        exit(EXIT_FAILURE); // check if there is error writing the weight into the file
    }
    fclose(fp); // close file
} // end of writeBinaryFile()

void readBinaryFileToStruct(char *fileName)
{
    FILE *fp = NULL;

    fp = fopen(fileName, "rb");
    if (fp == NULL)
    {
        printf("Cant open file in readBinaryFile()\n");
        exit(EXIT_FAILURE); // check if file is empty
    }
    printf("---------------------\n");

    printf("Read info from file:\n\n");
    while (1)
    {
        if (fread(&Info.date.day, sizeof(int), 1, fp) != 1) // read day
        {
            break; // if no data is found exits the loop
        }
        fread(&Info.date.month, sizeof(int), 1, fp); // read month
        fread(&Info.date.year, sizeof(int), 1, fp); // read year
        fread(&Info.price, sizeof(double), 1, fp); // read price
        fread(&Info.weight, sizeof(double), 1, fp); // read weight

        PrintProductInfo(); // prints the current data read from the file
    } // end of while loop
    fclose(fp);
} // end of readBinaryFileToStruct()

Node *makeNodeFromFile(char *FileName)
{
    FILE *fp = NULL;
    Node *temp = NULL; // node pointer for current item in node

    fp = fopen(FileName, "rb"); // open file for reading
    if (fp == NULL)
    {
        printf("Cant open file in makeNodeFromFile()\n");
        exit(EXIT_FAILURE); // check if file is empty
    }

    while (1) // endless loop
    {
        temp = (Node*) malloc(sizeof(Node)); // creates a new node
        if (temp == NULL)
        {
            printf("Memory allocation error in makeNodeFromFile()\n");
            exit(EXIT_FAILURE); // if no memory is allocated for a new node exit the program
        }
        temp->next = NULL; // makes next pointer address NULL if there are no more elements from file to read in node

        fseek(fp, 3 * sizeof(int), SEEK_CUR); // skips 3 int from file(12bytes)
        if (fread(&temp->price, sizeof(double), 1, fp) != 1) // reads directly the price
        {
            break; // if no data is found exits the loop
        }
        fseek(fp, sizeof(double), SEEK_CUR); // skips the weight
        temp->next = head; // makes the next pointer head
        head = temp; // need to read more about linked lists
    } // end of while loop
    return head; // returns the first node to head
}

void printNode(char menuChoice, int MonthNumber, char *FileName)
{
    double Min = 0, Max = 0, Sum = 0;
    head = makeNodeFromFile(FileName); // creates a new node and reads file data into it

    if (head == NULL)
    {
        printf("Empty Node.\n");
        exit(EXIT_FAILURE);
    }

    Max = Min = head->price; // saves Min and Max value of the first element in the node

    while (head != NULL) // loops until node end is reached
    {
        Sum += head->price; // sums all the price and save them to Sum variable
        if (head->price > Max) // if the current price from node is larger than the first(max)
        {
            Max = head->price; // max takes value of the bigger value in the node
        }
        else if (head->price < Min) // if the current price from node is smaller than the first(min)
        {
            Min = head->price; // min takes value of the smaller value in the node
        }
        head = head->next; // iterates the loop to go to the next node
    } // end of while loop

    switch (menuChoice)
    {
    case '1': // if print min max is selected from menu
        printf("-----------------------------------\n");
        printf(" Min price for %s = %lf\n Max price for %s = %lf\n\n", monthName[MonthNumber - 1], Min, monthName[MonthNumber - 1], Max);
        break;

    case '2': // if max wins and total wins are selected
        printf("----------------------------------------------\n");
        printf(" Most wins from a deal in %s = %lf \n Total wins in %s = %lf\n\n", monthName[MonthNumber - 1], Max, monthName[MonthNumber - 1], Sum);
        break;
    } // end of switch cases
} // end of printNode()

void getCurrentTime(int monthNumber)
{
    time_t mytime;
    struct tm *timeinfo;
    time (&mytime);
    timeinfo = localtime (&mytime);
    Info.date.day = timeinfo->tm_mday; // saves local day number to Date structure
    Info.date.month = monthNumber; // saves month number selected by user to Date structure
    Info.date.year = timeinfo->tm_year + 1900; // save year number to Date structure
}

void freeNode()
{
    Node *temp; // create a new node pointer

    while (head != NULL) // loops until node is empty
    {
        temp = head; // assign temp to head
        head = head->next; // iterate head node to the next node;
        free(temp); // free node
        free(head); // free node
    } // end of while loop
} // end of freeNode()

#endif // STRUCTUREFUNCTIONALITY_H_INCLUDED
