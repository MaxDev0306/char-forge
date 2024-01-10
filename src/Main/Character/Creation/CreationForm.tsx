import {Form, Input, InputNumber, Select} from "antd";
import {useForm} from "antd/lib/form/Form";
import {useEffect, useState} from "react";
import {ApiClass, ApiClassResult} from "../../Compendium/components/ClassView";
import SkeletonInput from "antd/lib/skeleton/Input";
import {Attributes, StatsMap} from "../../lib/attributes";
import {standardArray} from "../../lib/standard-array";
import {AttributeShort} from "../../../types/char-forge";
export default function CreationForm() {

    const [form] = useForm()

    const [classes, setClasses] = useState<ApiClass[]>()
    const [statMethod, setStatMethod] = useState<'ROLL'|'STANDARD'|'CUSTOM'>("STANDARD");
    const [stats, setStats] = useState(new Map(StatsMap));



    useEffect(() => {
        if (!classes) {
            setStatMethod('ROLL')
            fetch("https://www.dnd5eapi.co/api/classes")
                .then(response => response.json())
                .then((result : ApiClassResult) => {
                    setClasses(result.results);
                })
                .catch(error => console.log('error', error));
        }
    })

    const setStat = (number: number|null, stat: AttributeShort) => {
        if (number !== null) {
            const statCopy = new Map(stats);
            statCopy.set(stat, number);
            setStats(statCopy);
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
                                <InputNumber value={stats.get(attr.short)} min={0} onChange={(value) => setStat(value, attr.short)}/>
                            </Form.Item>
                        )
                    }

                    if (statMethod === 'STANDARD') {
                        return (
                            <Form.Item label={attr.name} key={attr.short}>
                                <Select
                                    onChange={(value, option) => console.log(value, option)}
                                    onSelect={(value) => setStat(value, attr.short)}
                                    options={standardArray.map((value) => (
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