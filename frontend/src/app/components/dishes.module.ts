import { NgModule } from '@angular/core';

import { DishesListComponent } from './dishes-list/dishes-list.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { DishesService } from '../services/dishes.service';
import { ReactiveFormsModule } from '@angular/forms';
import { SideBarComponent } from './side-bar/side-bar.component';
import { FilterFormComponent } from './filter-form/filter-form.component';
import { MainComponent } from './main/main.component';
import { RouterLink, RouterOutlet } from '@angular/router';
import { DishDetailsComponent } from './dish-details/dish-details.component';

@NgModule({
    imports: [BrowserModule, HttpClientModule, ReactiveFormsModule, RouterOutlet, RouterLink],
    exports: [DishesListComponent, SideBarComponent, FilterFormComponent, MainComponent],
    declarations: [DishesListComponent, SideBarComponent, FilterFormComponent, MainComponent, DishDetailsComponent],
    providers: [DishesService],
})
export class DishesListModule {}