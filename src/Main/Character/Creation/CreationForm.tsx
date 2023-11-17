import {Form, Input, InputNumber, Select} from "antd";
import {useForm} from "antd/lib/form/Form";
import React, {useEffect, useState} from "react";
import {ApiClass, ApiClassResult} from "../../Compendium/components/ClassView";
import SkeletonInput from "antd/lib/skeleton/Input";

interface Character {
    name: string
    class: string,
    level: number,
}
export default function CreationForm() {

    const [form] = useForm()

    const [classes, setClasses] = useState<ApiClass[]>()

    useEffect(() => {
        if (!classes) {
            fetch("https://www.dnd5eapi.co/api/classes")
                .then(response => response.json())
                .then((result : ApiClassResult) => {
                    setClasses(result.results);
                })
                .catch(error => console.log('error', error));
        }
    })

    return (
        <Form form={form}>
            <Form.Item label={'Name'} required>
                <Input />
            </Form.Item>
            <Form.Item label={'Level'} required>
                <InputNumber max={20} min={1} />
            </Form.Item>
            <Form.Item label={'Class'} required>
                {!classes && (
                    <SkeletonInput active/>
                )}
                {classes && (
                    <Select
                        mode="multiple"
                        options={classes.map((item) => (
                            { value: item.index, label: item.name}
                        ))}
                    />
                )}
            </Form.Item>
        </Form>
    )
}