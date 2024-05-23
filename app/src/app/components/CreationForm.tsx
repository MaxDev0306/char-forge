import {Button, Checkbox, Form, Input, InputNumber, Radio, Select} from "antd";
import {useForm} from "antd/lib/form/Form";
import {useState} from "react";
import {Abilities, acolyte, monk, StatsMap, woodElf} from "@/lib/attributes";
import {standardArray} from "@/lib/standard-array";
import {Background, Character, Class, Item, ItemChoice, Race} from "@/lib/types";
export default function CreationForm() {

    const [form] = useForm()

    const [classes, setClasses] = useState<Class[]>([monk])
    const [races, setRaces] = useState<Race[]>([woodElf])
    const [backgrounds, setBackgrounds] = useState<Background[]>([acolyte])
    const [items, setItems] = useState<Item[]>([...monk.startEquipment, ...acolyte.equipment])
    const [itemChoices, setItemChoices] = useState<ItemChoice[]>([...monk.startEquipmentChoices])

    const [currentLevel, setCurrentLevel] = useState<number>(0)
    const [currentClass, setCurrentClass] = useState<number|null>(null)
    const [currentBackground, setCurrentBackground] = useState<number|null>(null)
    const [currentRace, setCurrentRace] = useState<number|null>(null)

    const [statMethod, setStatMethod] = useState<'ROLL'|'STANDARD'|'CUSTOM'>("STANDARD");
    const [stats, setStats] = useState(new Map(StatsMap));
    const [proficiencies, setProficiencies] = useState<Map<string, {expertise: boolean}>>(new Map())
    const [tabs, setTabs] = useState<'BIO'|'STATS'|'INVENTORY'>('BIO')

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

    return (
        <div>
            <Radio.Group onChange={(e) => setTabs(e.target.value)}>
                <Radio.Button value={'BIO'}>Bio</Radio.Button>
                <Radio.Button value={'STATS'}>Stats</Radio.Button>
                <Radio.Button value={'INVENTORY'}>Inventory</Radio.Button>
            </Radio.Group>
            {tabs === 'STATS' && (
                <Radio.Group style={{marginLeft: '10vw'}} onChange={(e) => setStatMethod(e.target.value)}>
                    <Radio.Button value={'ROLL'}>Roll</Radio.Button>
                    <Radio.Button value={'STANDARD'}>Standard</Radio.Button>
                    <Radio.Button value={'CUSTOM'}>Custom</Radio.Button>
                </Radio.Group>
            )}
            {tabs === 'INVENTORY' && (
                <Button style={{marginLeft: '70vw'}}>Add</Button>
            )}
            <div style={{display: tabs === 'STATS' ? 'inherit' : 'none', marginTop: '5vh'}}>
                <div style={{display: "flex"}}>
                    <div style={{
                        height: '9vw',
                        width: '11vw',
                        background: "white",
                        borderRadius: 15,
                        textAlign: "center",
                        flexDirection: "column",
                        display: "flex",
                        padding: '1vw',
                        margin: '1vw'
                    }}>
                        <span>HP</span>
                        <div style={{justifySelf: "center", fontSize: 20, marginBottom: '3%'}}>
                            {monk.hitDice + (Math.floor((stats.get('Constitution')!)/2) + (monk.hitDice / 2 + 1) * (currentLevel -1))}
                        </div>
                    </div>
                    <div style={{
                        height: '9vw',
                        width: '11vw',
                        background: "white",
                        borderRadius: 15,
                        textAlign: "center",
                        flexDirection: "column",
                        display: "flex",
                        padding: '1vw',
                        margin: '1vw'
                    }}>
                        <span>Armor Class</span>
                        <div style={{justifySelf: "center", fontSize: 20, marginBottom: '3%'}}>
                            {Math.floor((stats.get('Dexterity')! - 10) / 2) + 10}
                        </div>
                    </div>
                    <div style={{
                        height: '9vw',
                        width: '11vw',
                        background: "white",
                        borderRadius: 15,
                        textAlign: "center",
                        flexDirection: "column",
                        display: "flex",
                        padding: '1vw',
                        margin: '1vw'
                    }}>
                        <span>Speed</span>
                        <div style={{justifySelf: "center", fontSize: 20, marginBottom: '3%'}}>
                            {woodElf.walkingSpeed} ft
                        </div>
                    </div>
                </div>
                <div style={{
                    display: "flex",
                    flexDirection: "row",
                    width: '100%',
                    justifyContent: "space-evenly",
                    marginTop: '5vh'
                }}>
                    {Abilities.map((attr) => (
                        <>
                            <div key={attr.id} style={{display: "flex", alignItems: "center", flexDirection: "column"}}>
                                {statMethod === "ROLL" && (
                                    <Button onClick={() => rollStat(attr.name)}>Roll</Button>
                                )}
                                <div style={{
                                    height: '9vw',
                                    width: '11vw',
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
                                <div key={attr.id} style={{
                                    display: "flex",
                                    flexDirection: "column",
                                    background: "darkgray",
                                    padding: '5%',
                                    borderRadius: 15,
                                    alignItems: "center"
                                }}>
                                    <div>
                                        <span>Saving throw:</span>
                                        <Checkbox
                                            value={proficiencies.has(attr.name + '_SAVE')}
                                            onClick={() => setProficiency(!proficiencies.has(attr.name + '_SAVE'), attr.name + '_SAVE')}
                                        />
                                        <Checkbox
                                            disabled={!proficiencies.has(attr.name + '_SAVE')}
                                            value={proficiencies.get(attr.name + '_SAVE')?.expertise}
                                            onClick={() => setExpertise(!proficiencies.get(attr.name + '_SAVE')?.expertise, attr.name + '_SAVE')}
                                        />
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
                                    </div>
                                </div>
                            </div>
                        </>
                    ))}
                </div>
            </div>
            <div style={{display: tabs === 'BIO' ? 'inherit' : 'none'}}>
                <Form.Item label={'Name'}>
                    <Input/>
                </Form.Item>
                <div style={{display: "flex"}}>
                    <Form.Item label={'Class'}>
                        <Select
                            style={{width: '10vw'}}
                            options={classes.map((item) => (
                                {value: item.id, label: item.baseClassName}
                            ))}
                            onChange={(e) => setCurrentClass(e)}
                        />
                    </Form.Item>
                    <Form.Item label={'Subclass'}>
                        <Select
                            style={{width: '15vw'}}
                            options={classes.map((item) => (
                                {value: item.id, label: item.subClassName}
                            ))}
                        />
                    </Form.Item>
                    <Form.Item label={'Level'}>
                        <InputNumber value={currentLevel} max={20} min={1} onChange={(e) => setCurrentLevel(e ?? 0)}/>
                    </Form.Item>
                </div>
                <div style={{display: "flex"}}>
                    <Form.Item label={'Race'}>
                        <Select
                            style={{width: '10vw'}}
                            options={races.map((item) => (
                                {value: item.id, label: item.name}
                            ))}
                            onChange={(e) => setCurrentRace(e)}
                        />
                    </Form.Item>
                    <Form.Item label={'Background'}>
                        <Select
                            style={{width: '10vw'}}
                            options={backgrounds.map((item) => (
                                {value: item.id, label: item.name}
                            ))}
                            onChange={(e) => setCurrentBackground(e)}
                        />
                    </Form.Item>
                </div>
                <div>
                    {currentRace && woodElf.raceFeatures?.map((feature) => (
                        <div key={feature.id}>
                            <h4>{feature.name}</h4>
                            {feature.description}
                        </div>
                    ))}
                    {currentClass && monk.classSpecificFeatures?.map((feature) => (
                        <div key={feature.id}>
                            <h4>{feature.name}</h4>
                            {feature.description}
                        </div>
                    ))}
                    {currentBackground && acolyte.features.map((feature) => (
                        <div key={feature.id}>
                            <h4>{feature.name}</h4>
                            {feature.description}
                        </div>
                    ))}
                </div>
            </div>
            <div style={{display: tabs === 'INVENTORY' ? 'inherit' : 'none'}}>
                <div style={{width: '65vw', padding: '2vw', background: "white"}}>
                    {items.map((item) => (
                        <div key={item.id} style={{padding: '6px', background: "lightgray", borderRadius: 15, margin: 15}}>
                            {item.name} {item.description}
                        </div>
                    ))}
                    {itemChoices.map((item) => (
                        <div key={item.id} style={{padding: '6px', background: "lightgray", borderRadius: 15, margin: 15}}>
                            <Select
                                style={{width: '20vw'}}
                                options={items.map((item) => (
                                    { label: item.name, value: item.id }
                                ))}
                            />
                        </div>
                    ))}
                </div>
            </div>
        </div>
    )
}