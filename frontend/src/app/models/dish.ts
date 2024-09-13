import { IIngredient } from "./ingredient"

export interface IDish {
    id: number
    name: string
    description: string
    pictureUrl: string
    rating: string
    dishCategory: string
    dishSubcategory: string
    ingredients: IIngredient[]
  }