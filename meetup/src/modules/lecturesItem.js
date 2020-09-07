import React from "react";
import "../styles/lecture.scss";

const LecturesItem = ({ author, topic, description }) => {
  return (
    <>
      <ul className="lecture-list-item">
        <li className="lecture-topic">{topic}</li>
        <ul>
          <li className="lecture-details">{author}</li>
          <li className="lecture-details">{description}</li>
        </ul>
      </ul>
    </>
  );
};

export default LecturesItem;
