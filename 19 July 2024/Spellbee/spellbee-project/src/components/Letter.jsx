import React from "react";
import "../App.css"; // Ensure the correct path to your CSS file

function Letter({ index, letter, compulsoryLetter, handleLetterClick }) {
  return (
    <>
      <div
        className={`hex hex${index + 1}`}
        onClick={() => handleLetterClick(letter)}
      >
        <span>{letter}</span>
      </div>
    </>
  );
}

export default Letter;
