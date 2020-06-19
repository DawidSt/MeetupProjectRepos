import React, { useEffect, useState } from "react";
import axios from "axios";
import { baseUrl } from "../constants/constants";
import MeetupListItem from "./meetupListItem";
import { A } from "hookrouter";
import "../styles/meetupList.scss";
