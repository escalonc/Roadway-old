import React from "react";
import { Table } from "antd";

interface Props<T> {
  children: JSX.Element[] | JSX.Element;
  dataSource?: T[];
  rowKey?: string | ((record: T, index: number) => string);
}

function DataTable<T>({ children, dataSource, rowKey }: Props<T>) {
  return (
    <Table dataSource={dataSource} rowKey={rowKey}>
      {children}
    </Table>
  );
}

export default DataTable;
