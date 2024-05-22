import {Button, Checkbox, Form, Input, InputNumber, Radio, Select} from "antd";
import {useForm} from "antd/lib/form/Form";
import {useState} from "react";
import SkeletonInput from "antd/lib/skeleton/Input";
import {Abilities, acolyte, monk, StatsMap, woodElf} from "@/lib/attributes";
import {standardArray} from "@/lib/standard-array";
import {FaDeleteLeft} from "react-icons/fa6";
import {Background, Class, Race} from "@/lib/types";
export default function CreationForm() {

    const [form] = useForm()

    const [classes, setClasses] = useState<Class[]>([monk])
    const [races, setRaces] = useState<Race[]>([woodElf])
    const [backgrounds, setBackgrounds] = useState<Background[]>([acolyte])

    const [statMethod, setStatMethod] = useState<'ROLL'|'STANDARD'|'CUSTOM'>("STANDARD");
    const [stats, setStats] = useState(new Map(StatsMap));
    const [proficiencies, setProficiencies] = useState<Map<string, {expertise: boolean}>>(new Map())
    const [tabs, setTabs] = useState<'BIO'|'STATS'|'INVENTORY'>()

    const setStat = (number: number|null, stat: string) => {
        if (number !== null) {
            const statCopy = new Map(stats);
            statCopy.set(stat, number);
            setStats(statCopy);
        }
    }

    function setProficiency(add: boolean, name: string) {
        const copy = new Map(proficiencies);

        if (add) {
            if (!copy.has(name)) {
                copy.set(name, {expertise: false})
            }
        } else {
            if (copy.has(name)) {
                copy.delete(name)
            }
        }
        setProficiencies(copy)
    }

    function setExpertise(add: boolean, name: string) {
        const copy = new Map(proficiencies);
        if (copy.has(name)) {
            copy.set(name, {expertise: add})
        }
        setProficiencies(copy)
    }

    function rollStat(stat: string) {
        const number = Math.floor(Math.random() * 6) + 1
            + Math.floor(Math.random() * 6) + 1
            + Math.floor(Math.random() * 6) + 1

        setStat(number, stat)
    }

    function isNumberAlreadyUsed(number: number) {
        const values = Array.from(stats.values());
        return values.includes(number)
    }

    function renderStatDisplay(stat: string) {
        switch (statMethod) {
            case "ROLL": {
                return (<span>{stats.get(stat)}</span>)
            }
            case "CUSTOM": {
                return (<Input type={'number'} onChange={(e) => setStat(parseInt(e.target.value), stat)}/>)
            }
            case "STANDARD": {
                return (
                    <Select
                        onChange={(value, option) => console.log(value, option)}
                        onSelect={(value) => setStat(value, stat)}
                        options={standardArray.map((value) => (
                            {value: value, label: value, disabled: isNumberAlreadyUsed(value)})
                        )}
                    />
                )
            }
        }
    }

    function renderTab() {
        switch (tabs) {
            case "BIO": {
                return (
                    <div>
                        <div style={{display: "flex"}}>
                            <Form.Item label={'Level'} required>
                                <InputNumber max={20} min={1}/>
                            </Form.Item>
                            <Form.Item label={'Class'} required>
                                <Select
                                    style={{width: '10vw'}}
                                    options={classes.map((item) => (
                                        {value: item.id, label: item.baseClassName}
                                    ))}
                                />
                            </Form.Item>
                            <Form.Item label={'Subclass'} required>
                                <Select
                                    style={{width: '10vw'}}
                                    options={classes.map((item) => (
                                        {value: item.id, label: item.subClassName}
                                    ))}
                                />
                            </Form.Item>
                        </div>
                        <div style={{display: "flex"}}>
                            <Form.Item label={'Name'} required>
                                <Input/>
                            </Form.Item>
                            <Form.Item label={'Race'} required>
                                {!classes && (
                                    <SkeletonInput active/>
                                )}
                                {classes && (
                                    <Select
                                        style={{width: '10vw'}}
                                        options={classes.map((item) => (
                                            {value: item.id, label: item.baseClassName}
                                        ))}
                                    />
                                )}
                            </Form.Item>
                            <Form.Item label={'Background'} required>
                                {!classes && (
                                    <SkeletonInput active/>
                                )}
                                {classes && (
                                    <Select
                                        style={{width: '10vw'}}
                                        options={classes.map((item) => (
                                            {value: item.id, label: item.baseClassName}
                                        ))}
                                    />
                                )}
                            </Form.Item>
                        </div>
                    </div>
                )
            }
            case "STATS": {
                return (
                    <div>
                        <h3>Stats</h3>
                        <Radio.Group onChange={(e) => setStatMethod(e.target.value)}>
                            <Radio.Button value={'ROLL'}>Roll</Radio.Button>
                            <Radio.Button value={'STANDARD'}>Standard</Radio.Button>
                            <Radio.Button value={'CUSTOM'}>Custom</Radio.Button>
                        </Radio.Group>
                        <Button onClick={() => {
                            setStats(new Map(StatsMap))
                        }}><FaDeleteLeft/></Button>
                        <div style={{
                            display: "flex",
                            flexDirection: "row",
                            width: '100%',
                            justifyContent: "space-evenly",
                            marginTop: '5vh'
                        }}>
                            {Abilities.map((attr) => (
                                <div key={attr.id}>
                                    <Checkbox
                                        value={proficiencies.has(attr.name + '_SAVE')}
                                        onClick={() => setProficiency(!proficiencies.has(attr.name + '_SAVE'), attr.name + '_SAVE')}
                                    />
                                    <Checkbox
                                        disabled={!proficiencies.has(attr.name + '_SAVE')}
                                        value={proficiencies.get(attr.name + '_SAVE')?.expertise}
                                        onClick={() => setExpertise(!proficiencies.get(attr.name + '_SAVE')?.expertise, attr.name + '_SAVE')}
                                    />
                                </div>
                            ))}
                        </div>
                        <div style={{
                            display: "flex",
                            flexDirection: "row",
                            width: '100%',
                            justifyContent: "space-evenly",
                            marginTop: '5vh'
                        }}>
                            {Abilities.map((attr) => (
                                <div key={attr.id} style={{display: "flex", alignItems: "center", flexDirection: "column"}}>
                                    {statMethod === "ROLL" && (
                                        <Button onClick={() => rollStat(attr.name)}>Roll</Button>
                                    )}
                                    <div style={{
                                        height: '9vw',
                                        width: '9vw',
                                        background: "white",
                                        borderRadius: 15,
                                        textAlign: "center",
                                        flexDirection: "column",
                                        display: "flex",
                                        padding: '1vw'
                                    }}>
                                        <span>{attr.name}</span>
                                        <div style={{justifySelf: "center", fontSize: 20, marginBottom: '3%'}}>
                                            {stats.get(attr.name)! > 11 ? '+' : ''}
                                            {Math.floor((stats.get(attr.name)! - 10) / 2)}
                                        </div>
                                        {renderStatDisplay(attr.name)}
                                    </div>
                                </div>
                            ))}
                        </div>
                        <div style={{
                            display: "flex",
                            flexDirection: "row",
                            width: '100%',
                            justifyContent: "space-evenly",
                            marginTop: '5vh'
                        }}>
                            {Abilities.map((attr) => (
                                <div key={attr.id}>
                                    {attr.skills.map((skill) => (
                                        <div key={skill.id}>
                                            {skill.name}:
                                            <Checkbox
                                                value={proficiencies.has(skill.name)}
                                                onClick={() => setProficiency(!proficiencies.has(skill.name), skill.name)}
                                            />
                                            <Checkbox
                                                disabled={!proficiencies.has(skill.name)}
                                                value={proficiencies.get(skill.name)?.expertise}
                                                onClick={() => setExpertise(!proficiencies.get(skill.name)?.expertise, skill.name)}
                                            />
                                        </div>
                                    ))}
                                </div>
                            ))}
                        </div>
                    </div>
                )
            }
        }
    }

    return (
        <div>
            <Radio.Group onChange={(e) => setTabs(e.target.value)}>
                <Radio.Button value={'BIO'}>Bio</Radio.Button>
                <Radio.Button value={'STATS'}>Stats</Radio.Button>
                <Radio.Button value={'INVENTORY'}>Inventory</Radio.Button>
            </Radio.Group>
            {renderTab()}
        </div>
    )
}