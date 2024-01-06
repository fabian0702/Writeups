#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#define RESET "\x1B[0m"
#define BOLD "\x1B[1m"
#define CURSOR "\e[?25h"
#define HIDE_CURSOR "\e[?25l"

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
char* gets(char *prompt, char* buffer) {
  printf("%s\n > %s", prompt, CURSOR);
  char *line = NULL;
  size_t len = 0;
  long lengthread = getline(&line, &len, stdin);
  memcpy(buffer, line, lengthread-1);
  return buffer;
}

void tellflag() {
  char buffer[128];
  FILE *fp = fopen("flag", "r");
  if(fp == NULL) {
    error("Opening flag file failed!!! Please contact the admins.");
  }

  char flag[6];
  int len = fread(flag, 1, 5, fp);
  flag[len] = '\0';

  if(fclose(fp) < 0) {
    error("Closing flag file failed!!! Please contact the admins.");
  }

  system("./magic.sh");

  char* name = getstr("Santa: One last thing, can you tell me your name?");
  printf("\nSanta: Let me see. Oh no, this is bad, the flag vanished before i could read it entirely. All I can give you is this: %s. I am very sorry about this and would like to apologise for the inconvenience.\n", flag);
  gets("\nSanta: Can I assist you with anything else?", buffer);
  printf("\nSanta: You want me to help you with ");
  printf(buffer);
  puts("?\nSanta: I will see what I can do...");
}

#define MAX_PRESENTS 20

void task() {
  srand(time(NULL));

  int redPresents = 0;
  int yellowPresents = 0;
  int bluePresents = 0;

  puts("\nSanta: Great thanks for helping me.");
  puts("Santa: Can you count the different Presents and tell me how many of each i need?\n");
  for (int i = 0; i < MAX_PRESENTS; i++) {
    switch (rand() % 3)
    {
    case 0:
      redPresents++;
      puts(" - red");
      break;
    case 1:
      yellowPresents++;
      puts(" - yellow");
      break;
    case 2:
      bluePresents++;
      puts(" - blue");
      break;
    
    default:
      break;
    }
  }
  printf("\nSanta: How many red presents are needed?\n > ");
  int answerRed = 0, answerYellow = 0, answerBlue = 0;
  scanf("%d%*c", &answerRed);
  printf("Santa: And how many yellow presents are needed?\n > ");
  scanf("%d%*c", &answerYellow);
  printf("Santa: And how many blue presents are needed?\n > ");
  scanf("%d%*c", &answerBlue);

  if (redPresents == answerRed && yellowPresents == answerYellow && bluePresents == answerBlue){
    printf("\nSanta: Well done, now you may get the flag.\n");
    tellflag();
  } else {
    puts("Santa: Sorry, but I think there has been a mistake. I'm afraid I can't give you the flag just yet.\n");
  }
}

#define COLOR_BOLD "\e[1m"
#define COLOR_BOLD_GREY "\e[1;2m"
#define COLOR_OFF "\e[m"

int main(int argc, char** argv) {
  setvbuf(stdin, NULL, _IONBF, 0);
  setvbuf(stdout, NULL, _IONBF, 0);
  setvbuf(stderr, NULL, _IONBF, 0);

  printf("\e[1m🎁🎁🎁   Santa's gift factory   🎁🎁🎁\e[m\nWelcome generous helper, can you help Santa with the presents? As a token of his gratitude, he will give you the 🏁 at the end.");

  if(getchr("\nAre you willing to help him (y/n)? ") == 'y') {
    task();
  } else {
    error("I am sorry, but I am unable to help you any further.\n");
  }

  return 0;
}