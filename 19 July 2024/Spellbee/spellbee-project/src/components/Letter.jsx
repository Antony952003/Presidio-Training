import React from "react";
import "../App.css"; // Ensure the correct path to your CSS file

function Letter({ letter, compulsoryLetter, handleLetterClick }) {
  return (
    <button
      className={`letter ${letter === compulsoryLetter ? "compulsory" : ""}`}
      onClick={() => handleLetterClick(letter)}
    >
      {letter}
    </button>
  );
}

export default Letter;
