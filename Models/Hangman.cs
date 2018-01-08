using System;
using System.Collections.Generic;

namespace hangman_c.Models
{
public class Hangman
{
    private int GameId { get; set; }
    public int Guesses { get; set; }
    public string[] GuessedLetters { get; set; }
    public string[] Words = {"paridism", "xylophone","alkoxy","vexing"};
}
}
