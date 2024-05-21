import {ReactNode, useEffect, useState} from "react";
import {Card, Col, Row, Skeleton} from "antd";


export interface ApiClassResult {
    count: number,
    results: ApiClass[]
}

export interface ApiClass {
    index: string,
    name: string,
    url: string
}

export default function ClassView() {

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

    const renderClassBlocks = () => {
        const grid: ReactNode[] = [];

        if (classes) {
            const overflow = classes.length % 3;
            const numOfRows = Math.floor((classes.length - overflow) / 3);

            for (let i = 0; i < numOfRows; i++) {
                grid.push(
                    <Row gutter={16}>
                        {classes.slice(3*i, 3*i+3).map((value) => (
                            <Col span={8} style={{marginBottom: 8, marginTop: 8}}>
                                <Card title={value.name}>

                                </Card>
                            </Col>
                        ))}
                    </Row>
                )

            }
        } else {
            return (
                <Skeleton active></Skeleton>
            )
        }

        return grid
    }

    return renderClassBlocks();
}