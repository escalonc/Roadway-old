import React, { useState, ChangeEvent } from "react";
import { Table, Input } from "antd";

import Column from "antd/lib/table/Column";
import {FetchBrands} from "../brandHooks";

function BrandList() {
    const brands = FetchBrands();
    const [searchTerm, setSearchTerm] = useState("");
  return (
      <>
          <Input placeholder="Buscar..." style={{ marginBottom: 20 }} onChange={(event: ChangeEvent<HTMLInputElement>) => setSearchTerm(event.target.value)}></Input>
          <Table dataSource={brands} rowKey="id">
              <Column
                  title="Código"
                  dataIndex="id"
                  key="id"
                  width="30%"
              />
              <Column title="Nombre" dataIndex="name" key="name" />
          </Table>
      </>
  );
}

export default BrandList;
