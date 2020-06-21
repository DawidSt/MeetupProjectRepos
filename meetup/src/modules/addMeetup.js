import React, { useState } from "react";
import { useFieldArray, useForm } from "react-hook-form";
import axios from "axios";
import { baseUrl } from "../constants/constants";
import { navigate } from "hookrouter";

const AddMeetup = () => {
  const { handleSubmit, register, control } = useForm({
    defaultValues: {
      lectures: [
        {
          author: "",
          topic: "",
          description: "",
        },
      ],
    },
  });
};
