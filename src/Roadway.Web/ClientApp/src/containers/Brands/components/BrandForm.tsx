import React, { ChangeEvent, useState } from "react";

import { Form, Input, Tooltip, Icon, Button } from "antd";

import { FormComponentProps } from "antd/lib/form";

export interface Props extends FormComponentProps {}

function BrandForm(props: Props) {
  const [isDirty, setIsDirty] = useState(false);
  const [name, setName] = useState("");

  const handleSubmit = (e: React.FormEvent<HTMLInputElement>) => {
    e.preventDefault();
    props.form.validateFieldsAndScroll((err, values) => {
      if (!err) {
        console.log("Received values of form: ", values);
      }
    });
  };

  const handleNameChange = (event: React.ChangeEvent<HTMLInputElement>) =>
    setName(event.target.value);

  const { getFieldDecorator } = props.form;

  const formItemLayout = {
    labelCol: {
      xs: { span: 24 },
      sm: { span: 8 },
      md: { span: 4 }
    },
    wrapperCol: {
      xs: { span: 24 },
      sm: { span: 16 },
      md: { span: 6 }
    }
  };
  const tailFormItemLayout = {
    wrapperCol: {
      xs: {
        span: 24,
        offset: 0
      },
      sm: {
        span: 16,
        offset: 8
      },
      md: { span: 16, offset: 12 }
    }
  };

  return (
    <Form {...formItemLayout} onSubmit={handleSubmit}>
      <Form.Item label="Nombre">
        {getFieldDecorator("name", {
          initialValue: name,
          rules: [
            {
              type: "string",
              message: "El campo nombre es obligatorio",
              required: true
            }
          ]
        })(<Input onChange={handleNameChange} />)}
      </Form.Item>
      <Form.Item {...tailFormItemLayout}>
        <Button type="primary" htmlType="submit">
          Register
        </Button>
      </Form.Item>
    </Form>
  );
}

export default Form.create<Props>()(BrandForm);
