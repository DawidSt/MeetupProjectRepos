import React, { useEffect, useState } from "react";
import axios from "axios";
import moment from "moment";
import { baseUrl } from "../constants/constants";
import { A, navigate } from "hookrouter";
import LecturesItem from "./lecturesItem";
import "../styles/meetupDetails.scss";

const MeetupDetails = ({ id }) => {
  const [meetup, setMeetup] = useState({});

  useEffect(() => {
    (async () => {
      const users = await axios.get(`${baseUrl}/meetup/${id}`);
      setMeetup(users.data);
    })();
  }, []);

  const onDeleteClick = async () => {
    await axios.delete(`${baseUrl}/meetup/${id}`);
    navigate("/");
  };

  return (
    <>
      <div className="details">
        <div className="details__header">
          <A className="details__header__btn" href={`/edit/${id}`}>
            <span>Edytuj</span>
          </A>
          <span className="details__header__btn" onClick={onDeleteClick}>
            Usuń
          </span>
        </div>
        <small>{moment(meetup.date).format("MMMM Do YYYY")}</small>
        <h2 className="meetupName">{meetup.name}</h2>
        <p className="organizer">{meetup.organizer}</p>
        <p>{meetup.city}</p>
        <p>{meetup.postCode}</p>
        <p>{meetup.street}</p>
        <div className="lectures">
          <div></div>
          <div>
            <h3>Agenda</h3>
            {meetup.lectures
              ? meetup.lectures.map((x, index) => (
                  <LecturesItem
                    key={index}
                    author={x.author}
                    topic={x.topic}
                    description={x.description}
                  />
                ))
              : null}
          </div>
        </div>
        <div
          className="back-btn"
          onClick={() => {
            navigate("/");
          }}
        >
          Powrót
        </div>
      </div>
    </>
  );
};

export default MeetupDetails;
