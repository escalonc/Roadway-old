import React, { Suspense } from "react";
import "antd/dist/antd.css";
import { Router } from "@reach/router";
import Dashboard from "containers/Dashboard";

import { NetworkErrorBoundary } from "rest-hooks";
import Brand from "../Brands";

const App: React.FC = () => {
  return (
    <div className="App">
      <Dashboard>
        <Suspense fallback={"Working!!!"}>
          <NetworkErrorBoundary>
            <Router>
              <Brand path="brands" />
            </Router>
          </NetworkErrorBoundary>
        </Suspense>
      </Dashboard>
    </div>
  );
};

export default App;
