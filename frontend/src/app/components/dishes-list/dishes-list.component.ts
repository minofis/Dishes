import { Component, OnInit } from '@angular/core';
import { IDish } from '../../models/dish';
import { DishesService } from '../../services/dishes.service';
import { Observable } from 'rxjs';
import { ICategory } from '../../models/category';
import { FormControl, FormGroup } from '@angular/forms';
import { ISubcategory } from '../../models/subcategory';
import { IIngredient } from '../../models/ingredient';
import { FilterData } from '../../models/filterData';

@Component({
  selector: 'app-dishes-list',
  templateUrl: './dishes-list.component.html',
  styleUrl: './dishes-list.component.scss'
})
export class DishesListComponent implements OnInit{

  public dishes$?: Observable<IDish[]>;
  public categories$?: Observable<ICategory[]>;
  public subcategories$?: Observable<ISubcategory[]>;
  public ingredients$?: Observable<IIngredient[]>;
 
  public myForm = new FormGroup({
    category: new FormControl(''),
    subcategory: new FormControl(''),
    ingredient: new FormControl(''),
  });
  
  constructor(private dishesService: DishesService){}

  public ngOnInit(): void {
    this.dishes$ = this.dishesService.getDishes();
    this.categories$ = this.dishesService.getCategories();
    this.subcategories$ = this.dishesService.getSubcategories();
    this.ingredients$ = this.dishesService.getIngredients();
  }

  public addFilter() : void{

    var filterData = new FilterData(this.myForm.value.category ?? '', this.myForm.value.subcategory ?? '', this.myForm.value.ingredient ?? '');

    this.dishes$ = this.dishesService.getDishesByFilter(filterData);
  }

  public resetFilterByCategory() : void{
    this.dishes$ = this.dishesService.getDishes();
  }
}