import {Button, Form, Input, InputNumber, Radio, Select} from "antd";
import {useForm} from "antd/lib/form/Form";
import {useEffect, useState} from "react";
import SkeletonInput from "antd/lib/skeleton/Input";
import {Attributes, StatsMap} from "@/lib/attributes";
import {standardArray} from "@/lib/standard-array";
import {ApiClass, ApiClassResult} from "@/app/components/ClassView";
import {FaDeleteLeft} from "react-icons/fa6";
export default function CreationForm() {

    const [form] = useForm()

    const [classes, setClasses] = useState<ApiClass[]>()
    const [statMethod, setStatMethod] = useState<'ROLL'|'STANDARD'|'CUSTOM'>("STANDARD");
    const [stats, setStats] = useState(new Map(StatsMap));



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

    const setStat = (number: number|null, stat: string) => {
        if (number !== null) {
            const statCopy = new Map(stats);
            statCopy.set(stat, number);
            setStats(statCopy);
        }
    }

    function rollStat() {
        return (
            Math.floor(Math.random() * 6) + 1
            + Math.floor(Math.random() * 6) + 1
            + Math.floor(Math.random() * 6) + 1
        )
    }

    function isNumberAlreadyUsed(number: number) {
        const values = Array.from(stats.values());

        return values.includes(number)
    }

    function renderStatForm() {
        switch (statMethod) {
            case "STANDARD": {
                return Attributes.map((attr) =>  (
                    <Form.Item label={attr.name} key={attr.short}>
                        <Select
                            onChange={(value, option) => console.log(value, option)}
                            onSelect={(value) => setStat(value, attr.short)}
                            options={standardArray.map((value) => (
                                {value: value, label: value, disabled: isNumberAlreadyUsed(value)})
                            )}
                        />
                    </Form.Item>
                ))
            }
            case "CUSTOM":
                return Attributes.map((attr) =>  (
                    <Form.Item label={attr.name} key={attr.short}>
                        <InputNumber value={stats.get(attr.short)} min={0} onChange={(value) => setStat(value as number, attr.short)}/>
                    </Form.Item>
                ))
            case "ROLL":
                return (
                    <div style={{display: "flex", flexDirection: "column", width: '10%'}}>
                        {Attributes.map((attr) =>  (
                            <Button
                                key={attr.short}
                                onClick={() => setStat(rollStat(), attr.short)}
                            >
                                {attr.name}: {stats.get(attr.short)}
                            </Button>
                        ))}
                    </div>
                )
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
                <Radio.Group onChange={(e) => setStatMethod(e.target.value)}>
                    <Radio.Button value={'ROLL'}>Roll</Radio.Button>
                    <Radio.Button value={'STANDARD'}>Standard</Radio.Button>
                    <Radio.Button value={'CUSTOM'}>Custom</Radio.Button>
                </Radio.Group>
                <Button onClick={() => {setStats(new Map(StatsMap))}}><FaDeleteLeft/></Button>
                {renderStatForm()}
            </div>
        </Form>
    )
}