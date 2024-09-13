import { Component, OnInit } from '@angular/core';
import { DishesService } from '../../services/dishes.service';
import { ICategory } from '../../models/category';
import { Observable } from 'rxjs';
import { ISubcategory } from '../../models/subcategory';
import { IIngredient } from '../../models/ingredient';
import { FormControl, FormGroup } from '@angular/forms';
import { FilterData } from '../../models/filterData';

@Component({
  selector: 'app-filter-form',
  templateUrl: './filter-form.component.html',
  styleUrl: './filter-form.component.scss'
})
export class FilterFormComponent implements OnInit {

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
    this.categories$ = this.dishesService.getCategories();
    this.subcategories$ = this.dishesService.getSubcategories();
    this.ingredients$ = this.dishesService.getIngredients();
  }

  public addFilter() : void{
    let newFilter = new FilterData(this.myForm.value.category ?? '', this.myForm.value.subcategory ?? '', this.myForm.value.ingredient ?? '');
    this.dishesService.updateFilter(newFilter);
  }

  public resetFilter() : void{
    this.dishesService.updateFilter(new FilterData('', '', ''));
  }
}