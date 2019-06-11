import React from "react";
import "antd/dist/antd.css";
import { Router } from "@reach/router";
import Dashboard from "containers/Dashboard";
import AddBrand from "components/Brands/AddBrand";
import EditBrand from "components/Brands/EditBrand";

const App: React.FC = () => {
  return (
    <div className="App">
      <Dashboard>
        <Router basepath="brands">
          <AddBrand path="add" />
          <EditBrand path="edit" />
        </Router>
      </Dashboard>
    </div>
  );
};

export default App;
