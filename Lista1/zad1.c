#include <stdio.h>
#include <errno.h>
#include <string.h>
#include <stdlib.h>
#include <unistd.h>
#include <math.h>

int messageTable[20][560];
int noCharToConvert = 0;
int noChar = 0;
int forConvert[8];
int oldNoMessage = 0;

void toBinary(int oneOrTwo, int noMessage)
{
		unsigned char myChar;
	
	int j;
	if (oldNoMessage != noMessage)
	{
		for (j = noChar; j<560; j++)
			messageTable[oldNoMessage][j] = 0;
		
		noChar = 0;
		oldNoMessage++;
	}
	
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
		

		messageTable[noMessage][noChar] = myChar;
		noChar++;
		//printf("messageTableinput noMessage: %d noChar: %d, value: %d\n", noMessage, noChar, messageTable[noMessage][noChar]);
		//system("pause");
	}
}

void decrypt()
{
	int decryptTable[128][57];
	//ASCII letters and numbers 32 - 126
	int i, j, k, value;
	int counter = 0;
	
	for (i = 0; i < 128; i++)
		for (j = 0; j<57; j++)
			decryptTable[i][j] = 0;

	for (i = 0; i < 56; i++)
	{
		for (j = 0; j<20; j++)
		{
			for (k = 0; k<128; k++)
			{
				value = (messageTable[j][i] ^ k);
				//printf("messageTableout noMessage: %d noChar: %d, value: %d\n", j, i, messageTable[j][i]);
				//printf ("value: %d\n", value);
				if (value>=32 && value <=126)
				{
						decryptTable[k][i]++;
						printf("Znak: %d \t ile razy: %d\n", k, decryptTable[k][i]++);
				}
				//else
				//{
					//decryptTable[k][i]--;
					//printf("%d\n", decryptTable[k][i]);
				//}
			}
			//printf("Iteracja: %d; Klucz znaleziono w %d\n", j, (counter));
		}
	}
	
	for (i = 0; i<56; i++)
		for (j = 0; j<128; j++)
		{
			printf("Znak: %d, wartość: %d\n", i, j);	
		}
	
	
	int comparer = 0;
	for (i = 0; i<56; i++)
	{
		for (j = 0; j<128; j++)
		{
			if (decryptTable[i][j] > comparer)
			{
				comparer = decryptTable[i][j];
			}
		}
		
		printf("Znak: %d, wartość: %c\n", i, j);
	}
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
	unsigned char noOfMessages = 0;
	
	int i;
	while ((i = fgetc(plik)) != EOF)
	{
		
		if(i == 10)
		{
			noOfMessages++;
		}
		else if (i == 32)
		{
			continue;
		}
		else
		{
			toBinary(i, noOfMessages);
		}
	}
	
	decrypt();
return 0;	
}
