import React from "react";
import { Table } from "antd";
import { useResource } from "rest-hooks";
import BrandResource from "../hooks/BrandResource";
import Column from "antd/lib/table/Column";
import DataTable from "../../../components/DataTable";
import SearchDialogColumn from "../../../components/DataTable/SearchDialogColumn";

function BrandList() {
  const brands = useResource(BrandResource.listRequest(), {});

  return (
    <DataTable<BrandResource> dataSource={brands} rowKey="id">
      <SearchDialogColumn<number>
        title="Código"
        dataIndex="id"
        key="id"
        width="30%"
      />
      <SearchDialogColumn title="Nombre" dataIndex="name" key="name" />
    </DataTable>
  );
}

export default BrandList;
