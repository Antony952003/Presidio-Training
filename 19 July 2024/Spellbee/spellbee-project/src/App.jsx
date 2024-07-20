import React, { useState } from "react";
import "./App.css";
import Letter from "./components/Letter";
import { validWords } from "./components/Words";

const letters = ["c", "i", "r", "t", "o", "a", "h"];
const compulsoryLetter = "h";

const pangrams = ["chariot", "haricot", "thoracic"];

function App() {
  const [currentWord, setCurrentWord] = useState("");
  const [foundWords, setFoundWords] = useState([]);
  const [message, setMessage] = useState("");

  const handleLetterClick = (letter) => {
    setCurrentWord(currentWord + letter);
    setMessage("");
  };

  const handleSubmit = () => {
    if (isValidWord(currentWord)) {
      setFoundWords([...foundWords, currentWord]);
      if (isPerfectPangram(currentWord)) {
        setMessage("Perfect Pangram!");
      } else if (isPangram(currentWord)) {
        setMessage("Pangram!");
      } else {
        setMessage("Word found!");
      }
      setCurrentWord("");
    } else {
      setMessage("Invalid word. Try again!");
      setCurrentWord("");
    }
  };

  const handleDelete = () => {
    setCurrentWord(currentWord.slice(0, -1));
  };

  const isValidWord = (word) => {
    return (
      word.length >= 4 &&
      word.includes(compulsoryLetter) &&
      validWords.includes(word)
    );
  };

  const isPangram = (word) => {
    return letters.every((letter) => word.includes(letter));
  };

  const isPerfectPangram = (word) => {
    const letterCount = {};
    for (const letter of word) {
      if (letterCount[letter]) {
        letterCount[letter]++;
      } else {
        letterCount[letter] = 1;
      }
    }
    return letters.every((letter) => letterCount[letter] === 1);
  };

  return (
    <div className="App">
      <div className="letters">
        {letters.map((letter, index) => (
          <Letter
            key={index}
            letter={letter}
            compulsoryLetter={compulsoryLetter}
            handleLetterClick={handleLetterClick}
          />
        ))}
      </div>
      <div className="current-word">
        <input type="text" value={currentWord} readOnly />
        <button onClick={handleDelete}>Delete</button>
        <button onClick={handleSubmit}>Submit</button>
      </div>
      <div className="found-words">
        {foundWords.map((word, index) => (
          <div key={index}>{word}</div>
        ))}
      </div>
      {message && <div className="message">{message}</div>}
    </div>
  );
}

export default App;
