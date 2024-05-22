export type Ability = {
	id: number,
	name: string,
	skills: Skill[],
	value?: number
}

export type Skill = {
	id: number,
	name: string,
}

export type Background = {
	id: number,
	name: string,
	description: string,
	proficiencies: Proficiency[],
	features: BackgroundFeature[],
	equipment: Item[]
}

export type Feature = {
	id: number,
	name: string,
	description: string,
}

export type BackgroundFeature = Feature & {

}

export type Character = {
	id: number,
	name: string,
	background: Background,
	class: Class,
	abilities: Ability[],
	items: Item[],
	proficiencies: Proficiency,
	race: Race,
	level: number,
	alignment: string,
	experiencePoints: number,
	ideals: string,
	bonds: string,
	flaws: string,
}

type Class = {
	id: number,
	baseClassName: string,
	hitDice: number,
	startEquipment: Item[],
	startEquipmentChoices: ItemChoice[],
	classSpecificFeatures: ClassSpecificFeature[],
	subClassName: string,
	proficiencies: Proficiency[]
};

export type ClassSpecificFeature = Feature & {
	level: number,
}

type Item = {
	id: number,
	name: string,
	description: string,
	value: number,
	weight: number,
	armorClass: number,
	armorType: string|null,
	requiredStrength: number,
	stealthDisadvantage: boolean,
	isArmor: boolean,
	damageDie: number,
	weaponType: string|null,
	properties: string|null,
	damageType: string|null,
	isWeapon: boolean,
};

type ItemChoice = {
	id: number,
	name: string,
	choiceAmount: number,
	items: Item[],
};

type Proficiency = {
	id: number,
	name: string,
	description: string|null,
	skill: Skill|null,
	isExpertise: boolean,
	ability: Ability
};

type Race = {
	id: number,
	name: string,
	baseRaceName: string,
	description: string,
	abilityScoreIncreases: RaceAbilityScoreIncrease[],
	size: string,
	walkingSpeed: number,
	flyingSpeed: number,
	swimmingSpeed: number,
	climbingSpeed: number,
	proficiencies: Proficiency[],
	raceFeatures: RaceFeature[],
};

type RaceAbilityScoreIncrease = {
	id: number,
	ability: Ability,
	amount: number,
};

export type RaceFeature = Feature & {

}