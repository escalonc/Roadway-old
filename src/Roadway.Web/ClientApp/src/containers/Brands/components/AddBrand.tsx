import React, { Component } from "react";
import { RouteComponentProps } from "@reach/router";
import BrandForm from "./BrandForm";

interface Props extends RouteComponentProps {}

class AddBrand extends Component<Props, {}> {
  render() {
    return <BrandForm />;
  }
}

export default AddBrand;
