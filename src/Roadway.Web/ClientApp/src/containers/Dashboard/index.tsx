import React, { useState } from "react";

import { Layout, Menu, Icon } from "antd";
import { Link } from "@reach/router";
import "./index.css";
const { Header, Sider, Content } = Layout;
const { SubMenu } = Menu;

export interface Props {
  children: JSX.Element[] | JSX.Element;
}
function Dashboard(props: Props) {
  const [collapsed, setCollapsed] = useState(false);

  const toggle = () => setCollapsed(collapsed);

  const { children } = props;
  return (
    <Layout style={{ minHeight: "100vh" }}>
      <Sider trigger={null} collapsible collapsed={collapsed}>
        <div className="logo" />
        <Menu theme="dark" mode="inline" defaultSelectedKeys={["1"]}>
          <SubMenu
            key="brands"
            title={
              <span>
                <Icon type="car" theme="filled" />
                <span>Autos</span>
              </span>
            }
          >
            <Menu.Item key="1">
              <Link to="brands/add">
                <span>Registro</span>
              </Link>
            </Menu.Item>
            <Menu.Item key="2">
              <span>Brands</span>
            </Menu.Item>
            <Menu.Item key="3">
              <span>nav 3</span>
            </Menu.Item>
          </SubMenu>
        </Menu>
      </Sider>
      <Layout>
        <Header style={{ background: "#fff", padding: 0 }}>
          <Icon
            className="trigger"
            type={collapsed ? "menu-unfold" : "menu-fold"}
            onClick={toggle}
          />
        </Header>
        <Content
          style={{
            margin: "24px 16px",
            padding: 24,
            background: "#fff",
            minHeight: 280
          }}
        >
          {children}
        </Content>
      </Layout>
    </Layout>
  );
}

export default Dashboard;
