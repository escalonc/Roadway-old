import React, { Component } from "react";

import { Layout, Menu, Icon } from "antd";
import { Link } from "@reach/router";
import "./index.css";
const { Header, Sider, Content } = Layout;
const { SubMenu } = Menu;

class Dashboard extends Component {
  state = {
    collapsed: false
  };

  toggle = () => {
    this.setState({
      collapsed: !this.state.collapsed
    });
  };

  render() {
    const { children } = this.props;
    return (
      <Layout style={{ minHeight: "100vh" }}>
        <Sider trigger={null} collapsible collapsed={this.state.collapsed}>
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
              type={this.state.collapsed ? "menu-unfold" : "menu-fold"}
              onClick={this.toggle}
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
}

export default Dashboard;
