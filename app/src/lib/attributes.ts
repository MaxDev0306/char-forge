import {Ability, Background, Class, Item, Race, Skill} from "@/lib/types";

const athletics: Skill = { id: 1, name: 'Athletics' };
const acrobatics: Skill = { id: 2, name: 'Acrobatics' };
const sleightOfHand: Skill = { id: 3, name: 'Sleight of Hand' };
const stealth: Skill = { id: 4, name: 'Stealth' };
const arcana: Skill = { id: 5, name: 'Arcana' };
const history: Skill = { id: 6, name: 'History' };
const investigation: Skill = { id: 7, name: 'Investigation' };
const nature: Skill = { id: 8, name: 'Nature' };
const religion: Skill = { id: 9, name: 'Religion' };
const animalHandling: Skill = { id: 10, name: 'Animal Handling' };
const insight: Skill = { id: 11, name: 'Insight' };
const medicine: Skill = { id: 12, name: 'Medicine' };
const perception: Skill = { id: 13, name: 'Perception' };
const survival: Skill = { id: 14, name: 'Survival' };
const deception: Skill = { id: 15, name: 'Deception' };
const intimidation: Skill = { id: 16, name: 'Intimidation' };
const performance: Skill = { id: 17, name: 'Performance' };
const persuasion: Skill = { id: 18, name: 'Persuasion' };

const strength: Ability = {
	id: 1,
	name: 'Strength',
	skills: [ athletics ]
};
const dexterity: Ability = {
	id: 2,
	name: 'Dexterity',
	skills: [ acrobatics, sleightOfHand, stealth ]
};
const constitution: Ability = {
	id: 3,
	name: 'Constitution',
	skills: []
};
const intelligence: Ability = {
	id: 4,
	name: 'Intelligence',
	skills: [ arcana, history, investigation, nature, religion ]
};
const wisdom: Ability = {
	id: 5,
	name: 'Wisdom',
	skills: [ animalHandling, insight, medicine, perception, survival ]
};
const charisma: Ability = {
	id: 6,
	name: 'Charisma',
	skills: [ deception, intimidation, performance, persuasion ]
};

export const Abilities = [
	strength,
	dexterity,
	wisdom,
	constitution,
	intelligence,
	charisma
]

export const Skills: Skill[] = [
    athletics,
    acrobatics,
    sleightOfHand,
    stealth,
    arcana,
    history,
    investigation,
    nature,
    religion,
    animalHandling,
    insight,
    medicine,
    perception,
    survival,
    deception,
    intimidation,
    performance,
    persuasion
];

export const woodElf: Race = {
	"id": 6,
	"name": "Woodelf",
	"baseRaceName": "Elf",
	"description": "Forest dwellers that like to live among their own kind and see other races as inferior to them, especially dwarvens.",
	"abilityScoreIncreases": [
		{
			"id": 2,
			"ability": dexterity,
			"amount": 2
		},
		{
			"id": 3,
			"ability": wisdom,
			"amount": 1
		}
	],
	"size": "M",
	"walkingSpeed": 35,
	"flyingSpeed": 0,
	"swimmingSpeed": 0,
	"climbingSpeed": 0,
	"proficiencies": [
		{
			"id": 10,
			"name": "longsword",
			"description": null,
			"ability": strength,
			"skill": null,
			"isExpertise": false,
		},
		{
			"id": 11,
			"name": "shortbow",
			"description": null,
			"ability": dexterity,
			"skill": null,
			"isExpertise": false,
		},
		{
			"id": 12,
			"name": "longbow",
			"description": null,
			"ability": dexterity,
			"skill": null,
			"isExpertise": false,
		}
	],
	"raceFeatures": [
		{
			"id": 2,
			"name": "Fleet of Foot",
			"description": "Your base walking speed increases to 35 feet.",
		},
		{
			"id": 3,
			"name": "Dark Vision",
			"description": "You can see in dim light within 60 feet as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray.",
		}
	]
}

export const itemList: Item[] = [

]

export const monk: Class = {
	"id": 4,
	"baseClassName": "Monk",
	"hitDice": 8,
	"startEquipment": [
		{
			"id": 13,
			"name": "Dart",
			"description": "Throwing Dart",
			"value": 5,
			"weight": 0,
			"armorClass": 0,
			"armorType": null,
			"requiredStrength": 0,
			"stealthDisadvantage": false,
			"isArmor": false,
			"damageDie": 4,
			"weaponType": "Simple Melee Weapon",
			"properties": "Finesse, Thrown (20/60)",
			"damageType": "piercing",
			"isWeapon": true,
		}
	],
	"startEquipmentChoices": [
		{
			"id": 6,
			"name": "(a) a shortbow or (b) any simple weapon",
			"choiceAmount": 1,
			"items": [
				{
					"id": 14,
					"name": "Showtsword",
					"description": "A simple shortsword",
					"value": 10,
					"weight": 2,
					"armorClass": 0,
					"armorType": null,
					"requiredStrength": 0,
					"stealthDisadvantage": false,
					"isArmor": false,
					"damageDie": 6,
					"weaponType": "Martial Melee Weapon",
					"properties": "Finesse, light",
					"damageType": "slashing",
					"isWeapon": true,
				},
				{
					"id": 15,
					"name": "Any simple melee Weapon",
					"description": "Any simple melee Weapon",
					"value": 0,
					"weight": 0,
					"armorClass": 0,
					"armorType": null,
					"requiredStrength": 0,
					"stealthDisadvantage": false,
					"isArmor": false,
					"damageDie": 0,
					"weaponType": "Simple Melee Weapon",
					"properties": "",
					"damageType": "",
					"isWeapon": true,
				}
			]
		},
		{
			"id": 7,
			"name": "(a) a dungeoneers pack (b) an explorers pack",
			"choiceAmount": 1,
			"items": [
				{
					"id": 16,
					"name": "Dungeoneers pack",
					"description": "A pack full of everything one might need in a dungeon",
					"value": 12,
					"weight": 20,
					"armorClass": 0,
					"armorType": null,
					"requiredStrength": 0,
					"stealthDisadvantage": false,
					"isArmor": false,
					"damageDie": 0,
					"weaponType": null,
					"properties": null,
					"damageType": null,
					"isWeapon": false,
				},
				{
					"id": 17,
					"name": "Explorers pack",
					"description": "A pack full of everything one might need while being out and about in the wilderness",
					"value": 10,
					"weight": 17,
					"armorClass": 0,
					"armorType": null,
					"requiredStrength": 0,
					"stealthDisadvantage": false,
					"isArmor": false,
					"damageDie": 0,
					"weaponType": null,
					"properties": null,
					"damageType": null,
					"isWeapon": false,
				}
			]
		}
	],
	"classSpecificFeatures": [
		{
			"id": 8,
			"level": 1,
			"name": "Unarmored Defense",
			"description": "Beginning at 1st level, while you are wearing no armor and not wielding a shield, your AC equals 10 + your Dexterity modifier + your Wisdom modifier."
		},
		{
			"id": 9,
			"level": 1,
			"name": "Martial Arts",
			"description": "At 1st level, your practice of martial arts gives you mastery of combat styles that use unarmed strikes and monk weapons, which are shortswords and any simple meele weapon that don't have the two-handed or heavy property."
		},
		{
			"id": 10,
			"level": 2,
			"name": "Ki",
			"description": "Starting at 2nd level, your training allows you to harness the mystic energy of ki. Your access to this energy is represented by a number of ki points. Your monk level detemines the number of points you have, as shown in the Ki Points column in the Monk table."
		}
	],
	"proficiencies": [
		{
			"id": 5,
			"name": "Acrobatics",
			"description": null,
			"ability": dexterity,
			"isExpertise": false,
			"skill": acrobatics
		},
		{
			"id": 6,
			"name": "Sleight of Hand",
			"description": null,
			"isExpertise": false,
			"skill": sleightOfHand,
			"ability": dexterity
		}
	],
	"subClassName": "Way of the open Hand"
}

export const acolyte: Background =   {
	"id": 1,
	"name": "Acolyte",
	"description": "You have spent your life in a temple serving a god.",
	"proficiencies": [
		{
			"id": 5,
			"name": "Acrobatics",
			"description": null,
			"ability": dexterity,
			"skill": null,
			"isExpertise": false,
		}
	],
	"equipment": [
		{
			"id": 18,
			"name": "Dart",
			"description": "Throwing Dart",
			"value": 5,
			"weight": 0,
			"armorClass": 0,
			"armorType": null,
			"requiredStrength": 0,
			"stealthDisadvantage": false,
			"isArmor": false,
			"damageDie": 4,
			"weaponType": "Simple Melee Weapon",
			"properties": "Finesse, Thrown (20/60)",
			"damageType": "piercing",
			"isWeapon": true,
		}
	],
	"features": [
		{
			"id": 1,
			"name": " Shelter of the Faithful",
			"description": "Tempels will grant you and you rparty accomodation and help you if they can.",
		}
	]
}

export const StatsMap = new Map<string, number>();
StatsMap.set(constitution.name, 0);
StatsMap.set(strength.name, 0);
StatsMap.set(dexterity.name, 0);
StatsMap.set(wisdom.name, 0);
StatsMap.set(intelligence.name, 0);
StatsMap.set(charisma.name, 0);
