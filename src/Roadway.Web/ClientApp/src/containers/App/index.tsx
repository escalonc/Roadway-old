import React, { Suspense } from "react";
import "antd/dist/antd.css";
import { Router } from "@reach/router";
import Dashboard from "containers/Dashboard";

import Brand from "../Brands";

const App: React.FC = () => {
  return (
    <div className="App">
      <Dashboard>
            <Router>
              <Brand path="brands" />
            </Router>
      </Dashboard>
    </div>
  );
};

export default App;
