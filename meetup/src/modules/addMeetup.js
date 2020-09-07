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

  const { fields, append, remove } = useFieldArray({
    control,
    name: "lectures",
  });

  const onSubmit = async (values) => {
    await axios
      .post(`${baseUrl}/meetup`, values)
      .then((result) => console.log(result))
      .catch((error) => console.log("dd", error));
    navigate("/");
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="form-input-static">
        <div className="form-input">
          <input
            name="name"
            placeholder="Nazwa"
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="organizer"
            placeholder="Organizator"
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="date"
            type="datetime-local"
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="city"
            placeholder="Miasto"
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="postalCode"
            placeholder="Kod pocztowy"
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="street"
            placeholder="Ulica"
            ref={register({
              required: "Required",
            })}
          />
        </div>
      </div>
      <div>
        <div className="form-input">
          <h3 style={{ paddingTop: 0 }}>Agenda</h3>
          <button
            type="button"
            onClick={() => {
              append({ name: "append" });
            }}
          >
            Dodaj wystąpienie
          </button>
        </div>
        {fields.map((item, index) => {
          return (
            <div className="agenda-item" key={item.id}>
              <input
                placeholder="Autor"
                name={`lectures[${index}].author`}
                ref={register({})}
              />
              <input
                placeholder="Temat"
                name={`lectures[${index}].topic`}
                ref={register({})}
              />
              <input
                placeholder="Opis"
                name={`lectures[${index}].description`}
                ref={register({})}
              />
              <button type="button" onClick={() => remove(index)}>
                Delete
              </button>
            </div>
          );
        })}
      </div>
      <div>
        <button type="submit" className="save-btn">
          Zapisz
        </button>
        <button
          type="button"
          className="cancel-btn"
          onClick={() => {
            navigate("/");
          }}
        >
          Anuluj
        </button>
      </div>
    </form>
  );
};

export default AddMeetup;
