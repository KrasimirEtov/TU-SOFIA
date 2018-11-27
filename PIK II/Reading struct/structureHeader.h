#ifndef STRUCTUREHEADER_H_INCLUDED
#define STRUCTUREHEADER_H_INCLUDED
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

/* Global variables */
char *monthName[] = {"January", "February", "March", "April", "May", "June",
"July", "August", "September", "October", "November", "December"}, *FileName;

/* Time struct */
typedef struct {
    int day;
    int month;
    int year;
} Date;

/* Product struct */
typedef struct {
    double weight;
    double price;
    Date date;
} tsProduct;

tsProduct Info;

/* Node struct */
typedef struct Node {
    tsProduct Info;
    struct Node *next;
} Node;

Node *head = NULL;

/* Functions */
void Menu(); // prints menu
void createNewInfo(); // create and fill new info to structure
void returnMonthChoose(int *choice); // choose a month
void printMonth(); // print the months
void enterProductInfo(); // enter product info to structure
void PrintProductInfo(); // print structure to screen
void writeBinaryFile(char *fileName); // write structure into binary file
void readBinaryFileToStruct(char *fileName); // read from binary file into structure pointer
void returnBuySellChoice(); // return choose of user : bought or sold product
char *createFileName(int MonthNumber, int BuySellChoose); // create a filename according to the user choice
void getCurrentTime(int monthNumber); // function to fill time structure
Node *makeNodeFromFile(char *FileName); // read price from binary file to a node
void printNode(char menuChoice, int MonthNumber, char *FileName); // print node to screen
void freeNode(); // free nodes from memory

#endif // STRUCTUREHEADER_H_INCLUDED
