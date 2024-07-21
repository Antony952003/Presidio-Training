import React, { useEffect, useState } from "react";
import "./App.css";
import Letter from "./components/Letter";
import { validWords } from "./components/Words";
import confetti from "canvas-confetti";

const compulsoryLetter = "h";
const pangrams = ["chariot", "haricot", "thoracic"];

function App() {
  const [letters, setLetters] = useState(["h", "i", "r", "t", "o", "a", "c"]);
  const [currentWord, setCurrentWord] = useState("");
  const [foundWords, setFoundWords] = useState([]);
  const [message, setMessage] = useState("");
  const [popupMessage, setPopupMessage] = useState("");
  const [showPopup, setShowPopup] = useState(false);

  useEffect(() => {}, [letters]);

  const handleLetterClick = (letter) => {
    setCurrentWord(currentWord + letter);
    setMessage("");
  };

  const handleSubmit = () => {
    if (
      isValidWord(currentWord) &&
      !foundWords.some((item) => item.word === currentWord)
    ) {
      const isPerfect = isPerfectPangram(currentWord);
      const isPangramWord = isPangram(currentWord);

      setFoundWords([
        ...foundWords,
        { word: currentWord, isPerfect, isPangramWord },
      ]);

      if (isPerfect) {
        setPopupMessage("Perfect Pangram!");
        triggerConfetti();
      } else if (isPangramWord) {
        setPopupMessage("Pangram!");
        triggerConfetti();
      } else {
        setPopupMessage("Word found!");
      }
      setCurrentWord("");
      setShowPopup(true);
      setTimeout(() => setShowPopup(false), 5000); // Hide popup after 2 seconds
    } else {
      setPopupMessage("Invalid word. Try again!");
      setCurrentWord("");
      setShowPopup(true);
      setTimeout(() => setShowPopup(false), 5000); // Hide popup after 2 seconds
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

  const shuffle = (array) => {
    const newArray = [...array];
    for (let i = newArray.length - 1; i > 1; i--) {
      const j = Math.floor(Math.random() * (i - 1)) + 1; // Ensure j is between 1 and i
      [newArray[i], newArray[j]] = [newArray[j], newArray[i]];
    }
    setLetters(newArray);
    console.log(newArray);
  };

  const triggerConfetti = () => {
    confetti({
      particleCount: 500,
      spread: 160,
      origin: { y: 0.6 },
    });
  };

  return (
    <div className="App">
      <h1 className="heading">
        Spell <span className="contrast">Bee</span>
      </h1>
      <div className="main-div">
        <div className="leftdiv">
          <div className="hex-container">
            {letters.map((letter, index) => (
              <Letter
                key={index}
                index={index}
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
            <button onClick={() => shuffle(letters)}>Shuffle</button>
          </div>
        </div>
        <div className="found-words">
          <span className="fwhead">
            Found <span className="fwhead contrast"> Words</span>
          </span>
          <div className="wordsfounded">
            {foundWords.map((item, index) => (
              <div key={index}>
                {item.word}
                <span
                  className={
                    item.isPerfect
                      ? "perfect-pangram"
                      : item.isPangramWord
                      ? "pangram"
                      : ""
                  }
                >
                  {item.isPerfect && " Perfect Pangram"}
                  {!item.isPerfect && item.isPangramWord && " Pangram"}
                </span>
              </div>
            ))}
          </div>
        </div>
      </div>
      {message && <div className="message">{message}</div>}
      {showPopup && <div className="popup">{popupMessage}</div>}
    </div>
  );
}

export default App;
