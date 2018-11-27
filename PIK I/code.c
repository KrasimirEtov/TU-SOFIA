#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <conio.h>

#define MAX 200

char choice; // global variable

// function prototypes
void menu();
void ReadSave(); // 1-vo poduslovie
void ShowResult(); // 2-ro poduslovie
void SavetoScreen(); // 3-to poduslovie
void PrinttoScreen(); // 4-to poduslovie
void Count(char *str, int *loopF, int *loopW, int *loopDW, int *empty, int *com, int *quotes); // counts loops, emptylines

// menu
void menu() {
    printf("\n Menu[1-5]:\n");
    printf(" 1. Read from file and save result to file\n");
    printf(" 2. Read from file and output result to screen\n");
    printf(" 3. Read from screen and save result to file\n");
    printf(" 4. Read from screen and output result to screen\n");
    printf(" 5. Exit.\n\n");
    printf(" Choose your selection:");
}

// 1-vo poduslovie
void ReadSave() {
    // flags
    char str[MAX], inputFileName[50], outputFileName[50], *check;
    int fix, loopF=0, loopW=0, loopDW=0, empty=0, com=0, quotes=0; // integers for Count function
    FILE *fp;

        system("cls"); // clears the screen
        printf("\n Type a .C file destination or file name:\n"); // user enters a file
        fflush(stdin);
        fgets(inputFileName, 50, stdin);

        fix=strlen(inputFileName)-1; // if fgets end is a newline(\n) it replaces it with terminal symbol (\0)
        if (inputFileName[fix]=='\n')
            inputFileName[fix]='\0';

        if((fp = fopen(inputFileName, "r"))==NULL) { // check if file is open successfully
            printf(" Cannot open file.\n");
            return;
        }
        check=strrchr(inputFileName, '.'); // *check is set to look from the last character '.'
        if(!(check!=NULL && strcmp(check, ".C")) || !(check!=NULL && strcmp(check, ".c"))) { // looks if there is .C after finding '.'

            while(fgets(str, MAX, fp)) { // read line by line in file
                Count(str, &loopF, &loopW, &loopDW, &empty, &com, &quotes); // count loops, emptylines
            }
            fclose(fp); // closes the file for reading

              // creating a new file
        printf(" Type destination or the name of the result file.\n");
        fflush(stdin);
        fgets(outputFileName, 50, stdin);

        fix=strlen(outputFileName)-1; // fgets end is a newline(\n) it replaces it with terminal symbol (\0)
        if(outputFileName[fix]=='\n')
            outputFileName[fix]='\0';

                if((fp = fopen(outputFileName, "w"))==NULL) { // check if file is open successfully
                    printf(" Cannot create file.\n");
                        return;
                }
        }
        else printf(" File extension is not .C\n"); // if extension is not .C
                        fprintf(fp, " Empty lines: %d \n\n", empty);
                        fprintf(fp, " Number of loops:\n");
                        fprintf(fp, " For: %d \n", loopF);
                        fprintf(fp, " While: %d \n", loopW);
                        fprintf(fp, " Do/While: %d ", loopDW);
                    fclose(fp); // closes the file for writing
              }

// 2-ro poduslovie
void ShowResult() {
    char str[MAX], inputFileName[50], *check;
    int fix, loopF=0, loopW=0, loopDW=0, empty=0, com=0, quotes=0; // integers for Count function
    FILE *fp;

        system("cls"); // clears the screen
        printf("\n Type destination or the name of the .C file.\n");
        fflush(stdin);
        fgets(inputFileName, 50, stdin);

        fix=strlen(inputFileName)-1; // if fgets end is a newline(\n) it replaces it with terminal symbol (\0)
        if(inputFileName[fix]=='\n')
            inputFileName[fix]='\0';

        if((fp = fopen(inputFileName, "r"))==NULL) {
            printf(" Cannot open file.\n");
                return;
        }
        check=strrchr(inputFileName, '.'); // *check is set to look from the last character '.'
        if(!(check!=NULL && strcmp(check, ".C")) || !(check!=NULL && strcmp(check, ".c"))) { // looks if there is .C after finding '.'

            while(fgets(str, MAX, fp)!=NULL) { // reads line by line in file
                    Count(str, &loopF, &loopW, &loopDW, &empty, &com, &quotes); // count loops, emptylines
            }

    fclose(fp);
            printf("---------------------\n");
            printf(" Empty lines: %d \n\n", empty);
            printf(" Number of loops:\n");
            printf(" For: %d \n", loopF);
            printf(" While: %d \n", loopW);
            printf(" Do/While: %d \n", loopDW);
            printf("---------------------\n");
        }
        else printf(" File extension is not .C\n"); // if extension is not .C
        return;
}

// 3-to poduslovie
void SavetoScreen() {
    char str[MAX], inputFileName[50];
    int fix, loopF=0, loopW=0, loopDW=0, empty=0, com=0, quotes=0; // integers for Count function
    FILE *fp;

        system("cls"); // clears the screen
        printf("\n Type destination or the name of the result file.\n");
        fflush(stdin);
        fgets(inputFileName, 50, stdin);

        fix=strlen(inputFileName)-1; // checks if a newline exist and removes it
        if(inputFileName[fix]=='\n')
            inputFileName[fix]='\0';

        if((fp = fopen(inputFileName, "w"))==NULL) { // check if file is open successfully
            printf(" Cannot create file.\n");
                return;
        }
        printf("\n Type your program here. Ctrl+Z and enter to stop.\n");
            while(fgets(str, MAX, stdin)!=NULL) { // read line by line in stdin
                Count(str, &loopF, &loopW, &loopDW, &empty, &com, &quotes); // count loops, emptylines
            }
                        fprintf(fp, " Empty lines: %d \n\n", empty);
                        fprintf(fp, " Number of loops:\n");
                        fprintf(fp, " For: %d \n", loopF);
                        fprintf(fp, " While: %d \n", loopW);
                        fprintf(fp, " Do/While: %d ", loopDW);
        fclose(fp); // closes the file for writing
}

// 4-to poduslovie
void PrinttoScreen() {
    char str[MAX];
    int loopF=0, loopW=0, loopDW=0, empty=0, com=0, quotes=0; // integers for Count function

    system("cls"); // clears the screen
    printf(" Type a program here. Ctrl+Z and enter to stop.\n");
    fflush(stdin);

        while(fgets(str, MAX, stdin)!=NULL){ // read line by line in stdin
            Count(str, &loopF, &loopW, &loopDW, &empty, &com, &quotes); // count loops, emptylines
        }
                printf("---------------------\n");
                printf(" Empty lines: %d \n\n", empty);
                printf(" Number of loops:\n");
                printf(" For: %d \n", loopF);
                printf(" While: %d \n", loopW);
                printf(" Do/While: %d \n", loopDW);
                printf("---------------------\n");
}

// main program
int main() {
        do{ // loops until user enters a choice from  the menu
            menu();
            scanf(" %[^\n]c", &choice); // reads a global char and does skips the countline
        switch(choice) {
            case '1':
                // 1-vo poduslovie
                ReadSave();
                break;
            case '2':
                // 2-ro poduslovie
                ShowResult();
                break;
            case '3':
                // 3-to poduslovie
                SavetoScreen();
                break;
            case '4':
                // 4-to poduslovie
                PrinttoScreen();
                break;
            case '5': // exit
                return 0;
            default:
                printf("\n Wrong choice. Press any key to go back...\n\n");
                getch();
                system("cls"); // clears the screen
        }
    }while(choice!='5');
 }// end of program

 void Count(char *str, int *loopF, int *loopW, int *loopDW, int *empty, int *com, int *quotes) { // count loops, emptylines
     int i, lines;
     char *p;
        if(choice>=1 || choice<=4){ // if user enters a choice from the menu

            for(i=0; i<strlen(str); i++) { // i goes through the whole string(str)

                    if(str[i]=='/' && str[i+1]=='/') { // if single-line comment is found it breaks and goes to next line
                            break;
                    }
                    if(str[i]=='/' && str[i+1]=='*') { // if multi-line comment is started, *com pointer gets value 1
                            (*com)=1;
                    }
                    if(str[i]=='*' && str[i+1]=='/') { // if end of multi-line comment has ended, *com pointer gets value 0
                            *(com)=0;
                    }
                    if(str[i]==34) { // if there is a ' " ' (ASCI CODE 34) *quotes pointer starts incrementing
                            (*quotes)++;
                    }
                    if((*quotes)%2==0 && !*(com)) { // if *quotes is a even number and *com=0 it checks the upper if and goes below to count loops and empty lines

                    // count loops
                    if(str[i]=='f' && str[i+1]=='o' && str[i+2]=='r') { // check every symbol to make a 'for'
                            (*loopF)++;
                    }
                    if(str[i]=='w' && str[i+1]=='h' && str[i+2]=='i' && str[i+3]=='l' && str[i+4]=='e') { // check every symbol to make a 'for'
                            (*loopW)++;
                    }
                    if(str[i]=='d' && str[i+1]=='o') { // check every symbol to make a 'do'
                            (*loopDW)++;
                        if((*loopDW)>=1) (*loopW)--; // if do is counted it removes one from the while loops because a do must have a while at the end to work
                    }
                    }
            }
                    // count empty lines

                p=str; // *p pointer gets a value of string(str) which reads the file
                lines=0; // integer for lines counting

                    while(*p!='\n'){ // a while loop it goes until str is not a newline

                        if(*p!=' ') { // if a line on str is not a newline or spacebar( ) it makes lines=1 which indicates that the line is not empty
                            lines=1;
                        }
                        p++; // goes to next line
                    }

                        if(!lines) { // if lines=0 which means no characters are detected in the string
                            (*empty)++; // *empty pointer counts the number of lines;
                            lines=0; // lines needs to be reseted after every line
                        }
        }
 }
