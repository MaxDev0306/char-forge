export type Abillity = {
	name: string,
	skills: Skill[],
	value?: number
}

export type Skill = {
	name: string,
}

export type Background = {
	name: string,
	description: string,
	proficiencies: Proficiency[],
	features: BackgroundFeature[]
}

export type Feature = {
	name: string,
	description: string,
}

export type BackgroundFeature = Feature & {

}

export type Character = {
	name: string,
	background: Background,
	class: Class,
	abilities: Abillity[],
	items: Item[],
	proficiencies: Proficiency,
	race: Race,
	level: number,
	alignment: string,
	experiencePoints: number,
	ideals: string,
	bonds: string,
	flaws,
}