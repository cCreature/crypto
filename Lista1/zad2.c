#include <stdio.h>
#include <errno.h>
#include <string.h>
#include <stdlib.h>
#include <unistd.h>
#include <math.h>

int noCharToConvert = 0;
int forConvert[8];
int messageTable[64];

void toBinary(int oneOrTwo)
{
	unsigned char myChar;
	
	int j;
	
	if (noCharToConvert <=7)
	{
		if (oneOrTwo == 48)
		{
			forConvert[noCharToConvert] = 0;
			noCharToConvert++;
			//printf("%d\n", noCharToConvert);
			//system("pause");
		}
		else if (oneOrTwo == 49)
		{
			forConvert[noCharToConvert] = 1;
			noCharToConvert++;
			//printf("%d\n", noCharToConvert);
			//system("pause");
		}
		else
			printf("Cos poszlo bardzo nie tak!!!\n");
	}
	else
	{
		int i;
		for(i = 0; i<8; i++)
		{
			myChar = myChar + ((pow(2, (i+1))*forConvert[i]));
		}
		noCharToConvert = 0;
		

		messageTable[noChar] = myChar;
		noChar++;
		//printf("messageTableinput noMessage: %d noChar: %d, value: %d\n", noMessage, noChar, messageTable[noMessage][noChar]);
		//system("pause");
	}
}


void decrypt ()
{
	
}


int main(int argc, char *argv[])
{
	FILE *plik = stdin;
	char *nplik = NULL;

	if (optind < argc)
		nplik = argv[optind++];

	if (nplik)
	{
		if ((plik = fopen(nplik, "r")) == NULL)
		{
			fprintf(stderr, "Nie umiem otworzyc %s: %s\n", nplik, strerror(errno));
			exit(-1);
		}
	}
	
	int i;
	while ((i = fgetc(plik)) != EOF)
	{
		
		if(i == 32 || i = 10)
		{
			continue;
		}
		else
		{
			toBinary(i);
		}
	}
	
	decrypt();
return 0;	
}
