import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IDish } from '../models/dish';
import { Observable } from 'rxjs';
import { IIngredient } from '../models/ingredient';
import { ICategory } from '../models/category';
import { ISubcategory } from '../models/subcategory';
import { FilterData } from '../models/filterData';

@Injectable()
export class DishesService {

  constructor(private _httpClient: HttpClient) {}

  baseServerUrl : string = "http://localhost:5147/api/dishes/";

   public getDishes(): Observable<IDish[]>{
    return this._httpClient.get<IDish[]>(this.baseServerUrl);
   }

   public getDishesByFilter(filterData : FilterData): Observable<IDish[]>{
    let params = new HttpParams();

    if(filterData.category){
      params = params.set('category', filterData.category);
    }
    if(filterData.subcategory){
      params = params.set('subcategory', filterData.subcategory)
    }
    if(filterData.ingredient){
      params = params.set('ingredient', filterData.ingredient)
    }

    return this._httpClient.get<IDish[]>(this.baseServerUrl + "by-filter/", {params})
   }

   public getIngredients(): Observable<IIngredient[]>{
    return this._httpClient.get<IIngredient[]>(this.baseServerUrl + 'ingredients');
   }

   public getCategories(): Observable<ICategory[]>{
    return this._httpClient.get<ICategory[]>(this.baseServerUrl + 'categories');
   }

   public getSubcategories(): Observable<ISubcategory[]>{
    return this._httpClient.get<ISubcategory[]>(this.baseServerUrl + 'subcategories');
   }
}
