import React, { useState, ChangeEvent, useEffect } from "react";
import { Table, Input } from "antd";

import Column from "antd/lib/table/Column";
import { FetchBrands, SearchBrands } from "../brandHooks";
import BrandModel from "../brandModel";

function BrandList() {
  const [searchTerm, setSearchTerm] = useState("");

  const brands = SearchBrands(searchTerm);

  return (
    <>
      <Input
        placeholder="Buscar..."
        style={{ marginBottom: 20 }}
        onChange={(event: ChangeEvent<HTMLInputElement>) =>
          setSearchTerm(event.target.value)
        }
      ></Input>
      <Table dataSource={brands} rowKey="id">
        <Column title="Código" dataIndex="id" key="id" width="30%" />
        <Column title="Nombre" dataIndex="name" key="name" />
      </Table>
    </>
  );
}

export default BrandList;
