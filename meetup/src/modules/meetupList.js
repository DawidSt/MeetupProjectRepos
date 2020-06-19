import React, { useEffect, useState } from "react";
import axios from "axios";
import { baseUrl } from "../constants/constants";
import MeetupListItem from "./meetupListItem";
import { A } from "hookrouter";
import "../styles/meetupList.scss";

const MeetupList = () => {
  const [meetList, setMeetist] = useState([]);

  useEffect(() => {
    (async () => {
      const users = await axios.get(`${baseUrl}/meetup`);
      setMeetist(users.data);
    })();
  }, []);

  return (
    <div className="container">
      <div className="add">
        <A className="add__btn" href="/add">
          Dodaj nowe wydarzenie
        </A>
      </div>
      <div className="container__meetupList">
        {meetList.map((x, index) => (
          <MeetupListItem
            key={index}
            id={x.id}
            name={x.name}
            city={x.city}
            date={x.date}
            organizer={x.organizer}
          />
        ))}
      </div>
    </div>
  );
};

export default MeetupList;
