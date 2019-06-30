import React, { Component } from "react";
import Column from "antd/lib/table/Column";
import { ColumnProps, FilterDropdownProps } from "antd/lib/table";
import { Button, Icon, Input } from "antd";

import Highlighter from "react-highlight-words";

interface Props<T> extends ColumnProps<T> {}
interface State {
  searchText: string;
}

class SearchDialogColumn<T> extends Component<Props<T>, State> {
  state = {
    searchText: ""
  };

  searchInput: any = {};

  handleSearch = (selectedKeys: string[], confirm: () => void) => {
    confirm();
    this.setState({ searchText: selectedKeys[0] });
  };

  handleReset = (clearFilters: any) => {
    clearFilters();
    this.setState({ searchText: "" });
  };

  getColumnSearchProps = (dataIndex: string) => ({
    filterDropdown: ({
      setSelectedKeys,
      selectedKeys,
      confirm,
      clearFilters
    }: FilterDropdownProps) => (
      <div style={{ padding: 8 }}>
        <Input
          ref={node => {
            this.searchInput = node;
          }}
          placeholder={`Search ${dataIndex}`}
          value={selectedKeys![0]}
          onChange={e =>
            setSelectedKeys!(e.target.value ? [e.target.value] : [])
          }
          onPressEnter={() => this.handleSearch(selectedKeys!, confirm!)}
          style={{ width: 188, marginBottom: 8, display: "block" }}
        />
        <Button
          type="primary"
          onClick={() => this.handleSearch(selectedKeys!, confirm!)}
          icon="search"
          size="small"
          style={{ width: 90, marginRight: 8 }}
        >
          Search
        </Button>
        <Button
          onClick={() => this.handleReset(clearFilters)}
          size="small"
          style={{ width: 90 }}
        >
          Reset
        </Button>
      </div>
    ),
    filterIcon: (filtered: boolean) => (
      <Icon type="search" style={{ color: filtered ? "#1890ff" : undefined }} />
    ),
    onFilter: (value: any, record: any) =>
      record[dataIndex]
        .toString()
        .toLowerCase()
        .includes(value.toLowerCase()),
    onFilterDropdownVisibleChange: (visible: boolean) => {
      if (visible) {
        setTimeout(() => this.searchInput.select());
      }
    },
    render: (text: string) => (
      <Highlighter
        highlightStyle={{ backgroundColor: "#ffc069", padding: 0 }}
        searchWords={[this.state.searchText]}
        autoEscape
        textToHighlight={text.toString()}
      />
    )
  });

  render() {
    return (
      <Column
        {...this.props}
        {...this.getColumnSearchProps(this.props.dataIndex!)}
      />
    );
  }
}

export default SearchDialogColumn;
