#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#define _GNU_SOURCE
#include <unistd.h>

#define RESET "\x1B[0m"
#define BOLD "\x1B[1m"
#define CURSOR "\e[?25h"
#define HIDE_CURSOR "\e[?25l"
#define MAX_ITEMS 100 

typedef struct item
{
  char* name;
  long nameLength;
  long count;
} item;

void error(char* message) {
  printf("%s", message);
  exit(1);
}
char getchr(char *prompt) {
    printf("%s%s", prompt, CURSOR);
    char c = getc(stdin);
    while (getc(stdin) != '\n');
    return c;
}
char *getstr(char *prompt) {
    printf("%s\n > %s", prompt, CURSOR);
    char *line = NULL;
    size_t len = 0;
    getline(&line, &len, stdin);
    line[strcspn(line, "\n")] = '\0';
    return line;
}
long getNum(char* prompt) {
  char* num = getstr(prompt);
  long numL = strtol(num, NULL, 10);
  free(num);
  return numL;
}
char *gets(char *strBuf, int length, FILE *buffer)
{
    printf(CURSOR);
    char c;
    for (size_t i = 0; (c = getc(buffer)) != '\n'; i++)
        if (i < length)
            strBuf[i] = c;
    return strBuf;
}

item** items;
int itemCount = 0;

void win() {
  char *args[] = {"/bin/sh", NULL};

  // Environment variables (set to NULL to use the current environment)
  char *env[] = {NULL};

    // Execute /bin/sh
  execve("/bin/sh", args, env);
}

void menu() {
  puts(BOLD"What do you want to do?"RESET);
  puts("[a]dd a item");
  puts("[l]ist items");
  puts("[f]etch shopping list from file");
  puts("[s]ave your shopping list");
  puts("[e]dit a item");
  puts("[c]hange the quantity of a item");
  puts("[r]emove a item");
  puts("[q]uit");

  char c = getchr(" > ");
  char* name;
  int itemID;
  switch (c)
  {
  case 'a':
    int index;
    for(index = 0; index < MAX_ITEMS && items[index] != NULL; index++);

    item* newEntry = malloc(sizeof(item));
    newEntry->name=getstr(BOLD"\nName of the item: "RESET);
    newEntry->nameLength = strlen(newEntry->name);
    newEntry->count = getNum(BOLD"How many of this item do you need?"RESET);
    items[index] = newEntry;
    printf("\nAdded %ldx %s to your shopping list.\n\n", newEntry->count, newEntry->name);
    itemCount++;
    break;
  case 'l':
    if(itemCount == 0) {
      puts("\nPlease add a item to your shopping list first.\n");
      break;
    }
    printf(BOLD"\nYour shopping list:\n"RESET);
    for (int i = 0; i < MAX_ITEMS; i++) if (items[i] != NULL)
      printf(" - %ldx %s\n", items[i]->count, items[i]->name);
    puts("");
    break;
  case 'e':
    name = getstr(BOLD"\nWhich item do you want to edit?"RESET);
    itemID = -1;
    for (int i = 0; i < MAX_ITEMS; i++) if (items[i]!=NULL && strstr(items[i]->name, name) != NULL) itemID = i;
    if (itemID < 0) {
      printf("\nNo item found with named %s.\n\n", name);
      break;
    }
    free(name);
    printf(BOLD"New name of the item:"RESET"\n > ");
    gets(items[itemID]->name,items[itemID]->count+1, stdin);
    puts("");
    break;
  case 'f':
    puts("\nThis method will be implemented in a future release.\n\n");
    break;
  case 'c':
    name = getstr(BOLD"Which item quantity do you want to change?"RESET);
    itemID = -1;
    for (int i = 0; i < MAX_ITEMS; i++) if (items[i]!=NULL && strstr(items[i]->name, name) != NULL) itemID = i;
    if (itemID < 0) {
      printf("\nNo item found with named %s.\n\n", name);
      break;
    }
    printf(BOLD"How many do you need?\n > "RESET);
    scanf("%ld%*c", &items[itemID]->count);
    if(items[itemID]->nameLength==1337) 
      printf("You've found my little secret, as a reward you will get: %p\n\n", win);
    free(name);
    puts("");
    break;
  case 's':
    if(itemCount == 0) {
      puts("\nPlease add a item to your shopping list first.\n");
      break;
    }
    char* filename = getstr("Filename:");
    FILE *fptr;
    if (strchr(filename, '/') != NULL) {
      puts("hacker detected, you will be reported to the admin.");
      fptr = fopen("flag", "w");
      fprintf(fptr, "I told you not to overstep any boundaries...");
      fclose(fptr);
    }
    fptr = fopen(filename, "w");
    fprintf(fptr, "# Shopping list\n");
    for (int i = 0; i < MAX_ITEMS; i++) if (items[i] != NULL)
      fprintf(fptr, " - %ldx %s\n", items[i]->count, items[i]->name);
    fclose(fptr);

    printf("Created File %s.\n\n", filename);

    free(filename);
    break;

  case 'r':
    name = getstr(BOLD"Which item do you want to delete?"RESET);
    itemID = -1;
    for (int i = 0; i < itemCount; i++) if (items[i]!=NULL && strstr(items[i]->name, name) != NULL) itemID = i;
    if (itemID < 0) {
      printf("\nNo item found with named %s.\n\n", name);
      break;
    }
    printf("Do you really want to delete %s (y/n)? ", name);
    if(getchr("") != 'y') break;
    printf("\nRemoved %s.\n\n", name);
    free(items[itemID]->name);
    free(items[itemID]);
    free(name);
    items[itemID]=NULL;
    itemCount--;
    break;
  case 'q':
    puts("Bye.");
    exit(0);
  default:
    puts(BOLD"\nPlease chose one of the options above.\n"RESET);
    break;
  }
}

#define COLOR_BOLD "\e[1m"
#define COLOR_BOLD_GREY "\e[1;2m"
#define COLOR_OFF "\e[m"

int main(int argc, char** argv) {
  setvbuf(stdin, NULL, _IONBF, 0);
  setvbuf(stdout, NULL, _IONBF, 0);
  setvbuf(stderr, NULL, _IONBF, 0);
  puts(BOLD"Shoppinglist creator 📋"RESET"\nThe first and last you will ever need, with state-of-the-art hacker protection.\n");

  items = malloc(sizeof(item*)*MAX_ITEMS);
  while(1) {
    menu();
  }
  return 0;
}