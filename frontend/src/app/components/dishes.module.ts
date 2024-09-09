import { NgModule } from '@angular/core';

import { DishesListComponent } from './dishes-list/dishes-list.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { DishesService } from '../services/dishes.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [BrowserModule, HttpClientModule, ReactiveFormsModule],
    exports: [DishesListComponent],
    declarations: [DishesListComponent],
    providers: [DishesService],
})
export class DishesListModule {}