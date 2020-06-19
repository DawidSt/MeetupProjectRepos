import React from "react";
import MeetupList from "./modules/meetupList";
/*import MeetupDetails from "./modules/meetupDetails";
import EditMeetup from "./modules/editMeetup";
import AddMeetup from "./modules/addMeetup";*/

const routes = {
  "/": () => <MeetupList />,
  /*"/add": () => <AddMeetup />,
  "/details/:id": ({ id }) => <MeetupDetails id={id} />,
  "/edit/:id": ({ id }) => <EditMeetup id={id} />,*/
};

export default routes;
