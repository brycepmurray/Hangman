CREATE TABLE hangdan (
    gameId int NOT NULL AUTO_INCREMENT,
    guesses INT (1) NOT NULL,
    guessedLetters CHAR (4),
    words VARCHAR (50),
    PRIMARY KEY (gameId)
    UNIQUE KEY email (email)
);