import React from "react";
import moment from 'moment';
import {A} from 'hookrouter';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faMapMarkerAlt} from "@fortawesome/free-solid-svg-icons";

const MeetupListItem = ({id, name, city, date, organizer}) => {
    return <div className="meetupListItem">
        <div className="meetupListItem__content">
        <A className="meetupListItem__link" href={`/details/${id}`}>
<div>
    <p className="date">{moment(date).format('MMMM Do YYYY hh:mm')}</p>
        <h3>{name}</h3>
        <p>{organizer}</p>
        <div>
        <FontAwesomeIcon className="mapMarker" icon={faMapMarkerAlt}/>
    <span>{city}</span>
    </div>
    <div className="meetupListItem__details">Szczegóły</div>
        </div>
        </A>
        </div>
        </div>
};

export default MeetupListItem;