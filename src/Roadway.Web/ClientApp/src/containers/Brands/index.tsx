import React from "react";
import BrandList from "./components/BrandList";
import { RouteComponentProps } from "@reach/router";

interface Props extends RouteComponentProps {}

function Brand(props: Props) {
  return <BrandList />;
}

export default Brand;
