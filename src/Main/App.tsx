import React, {useState} from 'react';
import {Button, Layout, Menu, theme, Typography} from 'antd';
import {MdMenu, MdMenuOpen, MdUpload} from 'react-icons/md';
import {FaDiceD20} from 'react-icons/fa6';
import {FaDragon, FaHome} from 'react-icons/fa';
import {Link, Outlet} from 'react-router-dom';
import {GiAncientSword} from "react-icons/gi";

const { Header, Footer, Sider, Content } = Layout;

export default function App() {

	const [collapsed, setCollapsed] = useState(false);
	const {
		token: { colorBgContainer },
	} = theme.useToken();

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
							icon: <Link to={'/'}><FaHome/></Link>,
							label: 'Home',
						},
						{
							key: '1',
							icon: <FaDiceD20/>,
							label: 'Characters',
							children: [
								{
									key: '11',
									icon: <Link to={'character'}><FaDiceD20/></Link>,
									label: 'Create Character',
								},
								{
									key: '12',
									icon: <Link to={'/'}><FaDiceD20/></Link>,
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
									icon: <Link to={'classes'}><GiAncientSword/></Link>,
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
					<Outlet />
				</Content>
			</Layout>
		</Layout>
	)
}