import {Form, Input, InputNumber, Select} from "antd";
import {useForm} from "antd/lib/form/Form";
import React, {useEffect, useState} from "react";
import {ApiClass, ApiClassResult} from "../../Compendium/components/ClassView";
import SkeletonInput from "antd/lib/skeleton/Input";
import {Attributes} from "../../lib/attributes";
import {standardArray} from "../../lib/standard-array";

interface Character {
    name: string
    class: string,
    level: number,
}
export default function CreationForm() {

    const [form] = useForm()

    const [classes, setClasses] = useState<ApiClass[]>()
    const [statMethod, setStatMethod] = useState<'ROLL'|'STANDARD'|'CUSTOM'>("STANDARD");
    const [unassignedStandard, setUnassignedStandard] = useState(standardArray);
    const [stats, setStats] =
        useState<{CON: number, STR: number, DEX: number, INT: number, WIS: number, CHA: number}>({
            CON: 0, STR: 0, DEX: 0, INT: 0, WIS: 0, CHA: 0
        })

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

    const useStandard = (number: number, stat: 'CON'|'STR'|'DEX'|'INT'|'WIS'|'CHA') => {
        const statCopy = {...stats};
        const array = [...unassignedStandard]
        switch (stat) {
            case 'CON':
                if (statCopy.CON === 0) {
                    statCopy.CON = number;
                    if ()
                }
        }
    }

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
            <div>
                <h3>Stats</h3>
                {Attributes.map((attr) =>  {
                    if (statMethod === "CUSTOM") {
                        return (
                            <Form.Item label={attr.name} key={attr.short}>
                                <InputNumber min={0}/>
                            </Form.Item>
                        )
                    }

                    if (statMethod === 'STANDARD') {
                        return (
                            <Form.Item label={attr.name} key={attr.short}>
                                <Select
                                    onChange={(value, option) => console.log(value, option)}
                                    onSelect={(value) => useStandard(value)}
                                    options={unassignedStandard.map((value) => (
                                    {value: value, label: value})
                                    )}
                                />
                            </Form.Item>
                        )
                    }
                })}
            </div>
        </Form>
    )
}