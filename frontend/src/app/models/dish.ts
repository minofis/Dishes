import { IIngredient } from "./ingredient"

export interface IDish {
    id: number
    name: string
    description: string
    rating: string
    recipe: string
    dishCategory: string
    dishSubcategory: string
    ingredients: IIngredient[]
  }