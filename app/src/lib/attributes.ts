import {Attribute} from "@/lib/types";

export const Attributes: Attribute[] = [
	{
		name: 'Constitution',
		short: 'CON',
		skills: []
	},
	{
		name: 'Strength',
		short: 'STR',
		skills: [
			{
				name: 'Athletics'
			}
		]
	},
	{
		name: 'Dexterity',
		short: 'DEX',
		skills: [
			{
				name: 'Slight of Hand'
			},
			{
				name: 'Stealth'
			},
			{
				name: 'Acrobatics'
			},
		]
	},
	{
		name: 'Intelligence',
		short: 'INT',
		skills: [
			{
				name: 'Arcana'
			},
			{
				name: 'History'
			},
			{
				name: 'Investigation'
			},
			{
				name: 'Nature'
			},
			{
				name: 'Religion'
			},
		]
	},
	{
		name: 'Wisdom',
		short: 'WIS',
		skills: [
			{
				name: 'Animal Handling'
			},
			{
				name: 'Insight'
			},
			{
				name: 'Medicine'
			},
			{
				name: 'Perception'
			},
			{
				name: 'Survival'
			},
		]
	},
	{
		name: 'Charisma',
		short: 'CHA',
		skills: [
			{
				name: 'Deception'
			},
			{
				name: 'Intimidation'
			},
			{
				name: 'Investigation'
			},
			{
				name: 'Performance'
			},
			{
				name: 'Persuasion'
			},
		]
	},
];



export const StatsMap = new Map<string, number>();
StatsMap.set('CON', 0);
StatsMap.set('STR', 0);
StatsMap.set('DEX', 0);
StatsMap.set('WIS', 0);
StatsMap.set('INT', 0);
StatsMap.set('CHA', 0);
