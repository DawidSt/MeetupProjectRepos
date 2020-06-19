import React, { useState } from "react";
import { useFieldArray, useForm } from "react-hook-form";

const AddMeetup = () => {
  const { handleSubmit, register, control } = useForm({
    defaultValues: {
      lectures: [
        {
          author: "",
          topic: "",
          description: "", //ddqwqdwqwd
        },
      ],
    },
  });
};
