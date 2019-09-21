import React, { useState, ChangeEvent, useEffect } from "react";
import { Table, Input } from "antd";

import Column from "antd/lib/table/Column";
import { PaginationConfig } from "antd/lib/table";
import BrandModel from "../brandModel";

function BrandList() {
  const [searchTerm, setSearchTerm] = useState("");
  const [brands, setBrands] = useState<BrandModel[]>([]);
  const [pagination, setPagination] = useState<PaginationConfig>({});
  const [isLoading, setIsLoading] = useState(false);

  //async function fetchServer() {
  //  try {
  //    let url: string;

  //    if (searchTerm.trim() === "") {
  //      url = brandsUrl;
  //    } else {
  //      url = `${brandsUrl}/search`;
  //    }
  //    setIsLoading(true);
  //    const resp = await axios(url, {
  //      params: {
  //        searchTerm,
  //        size: pagination.pageSize,
  //        page: pagination.current
  //      }
  //    });
  //    const data = resp.data as DataPagination;
  //    updateData(data);
  //    setIsLoading(false);
  //  } catch (e) {
  //    console.error(e);
  //  }
  //}

  useEffect(() => {
    //fetchServer();
  }, [searchTerm, pagination]);

  function handleTableChange(
    pagination: PaginationConfig,
    _filters: any,
    _sorter: any,
    _extra: any
  ) {
    const pager: PaginationConfig = { ...pagination, total: brands.totalCount };
    pager.current = pagination.current;
    setPagination(pager);
  }

  return (
    <>
      <Input
        placeholder="Buscar..."
        style={{ marginBottom: 20 }}
        onChange={(event: ChangeEvent<HTMLInputElement>) =>
          setSearchTerm(event.target.value)
        }
      ></Input>
      <Table
        //dataSource={brands.data}
        rowKey="id"
        loading={isLoading}
        onChange={handleTableChange}
        pagination={pagination}
      >
        <Column title="Código" dataIndex="id" key="id" width="30%" />
        <Column title="Nombre" dataIndex="name" key="name" />
      </Table>
    </>
  );
}

export default BrandList;
