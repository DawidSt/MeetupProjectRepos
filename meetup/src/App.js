import React from "react";
import "./App.css";
import { useRoutes } from "hookrouter";
import routes from "./routes";
import "./styles/layout.scss";

function App() {
  const routeResult = useRoutes(routes);
  return routeResult;
}

export default App;
