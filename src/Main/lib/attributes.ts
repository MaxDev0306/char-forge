import {Attribute, AttributeShort} from "../../types/char-forge";
import * as module from "module";

export const Attributes: Attribute[] = [
	{
		name: 'Constitution',
		short: 'CON'
	},
	{
		name: 'Strength',
		short: 'STR'
	},
	{
		name: 'Dexterity',
		short: 'DEX'
	},
	{
		name: 'Wisdom',
		short: 'WIS'
	},
	{
		name: 'Intelligence',
		short: 'INT'
	},
	{
		name: 'Charisma',
		short: 'CHA'
	},
];



export const StatsMap = new Map<AttributeShort, number>();
StatsMap.set('CON', 0);
StatsMap.set('STR', 0);
StatsMap.set('DEX', 0);
StatsMap.set('WIS', 0);
StatsMap.set('INT', 0);
StatsMap.set('CHA', 0);
