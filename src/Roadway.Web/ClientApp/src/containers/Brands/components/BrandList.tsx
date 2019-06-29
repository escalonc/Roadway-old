import React from "react";
import { Table } from "antd";
import { useResource } from "rest-hooks";
import BrandResource from "../hooks/BrandResource";

function BrandList() {
  const brands = useResource(BrandResource.listRequest(), {});

  const columns = [
    {
      title: "Código",
      dataIndex: "id",
      key: "id"
    },
    {
      title: "Nombre",
      dataIndex: "name",
      key: "name"
    }
  ];

  return <Table dataSource={brands} columns={columns} />;
}

export default BrandList;
