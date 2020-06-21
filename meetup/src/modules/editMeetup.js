import React, { useEffect, useState } from "react";
import axios from "axios";
import { baseUrl } from "../constants/constants";
import { useFieldArray, useForm } from "react-hook-form";
import { navigate } from "hookrouter";

const EditMeetup = ({ id }) => {
  const [meetup, setMeetup] = useState({});

  useEffect(() => {
    (async () => {
      const users = await axios.get(`${baseUrl}/meetup/${id}`);
      setMeetup(users.data);
    })();
  }, [id]);
};
