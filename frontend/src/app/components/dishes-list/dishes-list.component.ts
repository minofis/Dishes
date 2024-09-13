import { Component, OnInit } from '@angular/core';
import { IDish } from '../../models/dish';
import { DishesService } from '../../services/dishes.service';
import { Observable } from 'rxjs';
import { FilterData } from '../../models/filterData';

@Component({
  selector: 'app-dishes-list',
  templateUrl: './dishes-list.component.html',
  styleUrl: './dishes-list.component.scss'
})
export class DishesListComponent implements OnInit{

  public dishes$?: Observable<IDish[]>;

  constructor(private dishesService: DishesService){}

  public ngOnInit(): void {
    this.dishes$ = this.dishesService.getDishes();

    this.dishesService.currentFilterData$.subscribe(filter =>{
      if(filter){
        this.applyFilter(filter)
      }
    })
  }

  public applyFilter(filterData: FilterData) : void{
    this.dishes$ = this.dishesService.getDishesByFilter(filterData);
  }
}