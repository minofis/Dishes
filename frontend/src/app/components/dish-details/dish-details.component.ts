import { Component, OnInit } from '@angular/core';
import { IDish } from '../../models/dish';
import { ActivatedRoute } from '@angular/router';
import { DishesService } from '../../services/dishes.service';

@Component({
  selector: 'app-dish-details',
  templateUrl: './dish-details.component.html',
  styleUrl: './dish-details.component.scss'
})
export class DishDetailsComponent implements OnInit {
  dishId: string | null = null;
  dish: IDish;

  constructor(private route: ActivatedRoute, private dishesService: DishesService){}

  ngOnInit(): void {
    this.dishId = this.route.snapshot.paramMap.get('id');

    if (this.dishId){
      this.dishesService.getDishById(this.dishId).subscribe(data =>{
        this.dish = data;
      });
    }
  }
}
