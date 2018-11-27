#include <structureHeader.h>
#include <structureFunctionality.h>
int main()
{
    int BuySellChoice, monthNumber;
    char menuChoice;
    Menu();
    do
    {
        scanf(" %[^\n]c", &menuChoice);
        switch (menuChoice)
        {
        case '1':
            returnBuySellChoice(&BuySellChoice);
            returnMonthChoose(&monthNumber);
            FileName = createFileName(monthNumber, BuySellChoice);
            printNode(menuChoice, monthNumber, FileName);
			freeNode();
			Menu();
            break;

        case '2':
            returnBuySellChoice(&BuySellChoice);
            returnMonthChoose(&monthNumber);
            FileName = createFileName(monthNumber, BuySellChoice);
            printNode(menuChoice, monthNumber, FileName);
			freeNode();
			Menu();
            break;

        case '3':
            createNewInfo();
            printf("\n");
            PrintProductInfo();
            Menu();
            break;

        case '4':
            returnBuySellChoice(&BuySellChoice);
            returnMonthChoose(&monthNumber);
            FileName = createFileName(monthNumber, BuySellChoice);
            readBinaryFileToStruct(FileName);
            Menu();
            break;

        case '5':
            return 0;

        default:
            printf("Wrong choice. Choose again.\n");
        } // end of switch cases

    }while (menuChoice != '6'); // end of do while loop

    return 0;
}
