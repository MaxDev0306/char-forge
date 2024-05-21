'use client';
import {useState} from 'react';
import {Button, Layout, Menu, Typography} from 'antd';
import {MdMenu, MdMenuOpen} from 'react-icons/md';
import {FaDiceD20} from 'react-icons/fa6';
import {FaDragon, FaHome} from 'react-icons/fa';
import {GiAncientSword} from "react-icons/gi";
import CreationForm from "@/app/components/CreationForm";
import ClassView from "@/app/components/ClassView";


const { Header, Sider, Content } = Layout;

export default function App() {

    const [collapsed, setCollapsed] = useState(false);
    const [currentWindow, setCurrentWindow] = useState<string>()
    function renderWindow() {
        switch (currentWindow) {
            case 'character': {
                return <CreationForm />
            }
            case 'classes': {
                return <ClassView />;
            }
            default: {
                return (<></>)
            }
        }
    }

    return (
        <Layout style={{height: '100%'}}>
            <Sider trigger={null} collapsible collapsed={collapsed}>
                <div className="demo-logo-vertical" />
                <Menu
                    theme="dark"
                    mode="inline"
                    defaultSelectedKeys={['0']}
                    items={[
                        {
                            key: '0',
                            icon: <a onClick={() => setCurrentWindow(undefined)}><FaHome/></a>,
                            label: 'Home',
                        },
                        {
                            key: '1',
                            icon: <FaDiceD20/>,
                            label: 'Characters',
                            children: [
                                {
                                    key: '11',
                                    icon: <a onClick={() => setCurrentWindow('character')}><FaDiceD20/></a>,
                                    label: 'Create Character',
                                },
                                {
                                    key: '12',
                                    icon: <a onClick={() => setCurrentWindow('share')}><FaDiceD20/></a>,
                                    label: 'Share Character',
                                },
                            ]
                        },
                        {
                            key: '2',
                            icon: <FaDragon />,
                            label: 'Compendium',
                            children: [
                                {
                                    key: '21',
                                    icon: <a onClick={() => setCurrentWindow('classes')}><GiAncientSword/></a>,
                                    label: 'Classes'
                                }
                            ]
                        },
                    ]}
                />
            </Sider>
            <Layout>
                <Header style={{ padding: 0, backgroundColor: 'lightgray', display: 'flex', alignItems: 'center' }}>
                    <Button
                        type="text"
                        icon={collapsed ? <MdMenu /> : <MdMenuOpen />}
                        onClick={() => setCollapsed(!collapsed)}
                        style={{
                            fontSize: '16px',
                            width: 64,
                            height: 64,
                        }}
                    />
                    <Typography style={{fontSize: '32px', textAlign: 'center', width: '100%'}}>Char Forge</Typography>
                </Header>
                <Content
                    style={{
                        margin: '24px 16px',
                        padding: 24,
                        minHeight: 280,
                        backgroundColor: 'lightgray',
                        height: '100%',
                        maxHeight: '100%',
                        overflowY: 'scroll',
                    }}
                >
                    {renderWindow()}
                </Content>
            </Layout>
        </Layout>
    )
}