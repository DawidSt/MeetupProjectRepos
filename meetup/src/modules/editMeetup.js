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
      .put(`${baseUrl}/meetup/${id}`, values)
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
            defaultValue={meetup.name}
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="organizer"
            placeholder="Organizator"
            defaultValue={meetup.organizer}
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="date"
            type="datetime-local"
            defaultValue={meetup.date}
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="city"
            placeholder="Miasto"
            defaultValue={meetup.city}
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="postalCode"
            placeholder="Kod pocztowy"
            defaultValue={meetup.postCode}
            ref={register({
              required: "Required",
            })}
          />
        </div>
        <div className="form-input">
          <input
            name="street"
            placeholder="Ulica"
            defaultValue={meetup.street}
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
        {meetup.lectures
          ? meetup.lectures.map((item, index) => {
              return (
                <div className="agenda-item" key={item.id}>
                  <input
                    name={`lectures[${index}].author`}
                    placeholder="Autor"
                    defaultValue={item.author}
                    ref={register({})}
                  />
                  <input
                    placeholder="Temat"
                    name={`lectures[${index}].topic`}
                    defaultValue={item.topic}
                    ref={register({})}
                  />
                  <input
                    placeholder="Opis"
                    name={`lectures[${index}].description`}
                    defaultValue={item.description}
                    ref={register({})}
                  />
                </div>
              );
            })
          : null}
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

export default EditMeetup;
