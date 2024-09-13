import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DishesListComponent } from './components/dishes-list/dishes-list.component';
import path from 'path';
import { FilterFormComponent } from './components/filter-form/filter-form.component';
import { DishDetailsComponent } from './components/dish-details/dish-details.component';

const routes: Routes = [
  { path: "", redirectTo: "all-dishes", pathMatch: 'full'},
  { path: "all-dishes", children:[
    {
      path: '',
      component: DishesListComponent,
      outlet: 'dishes-list'
    },
    {
      path: '',
      component: FilterFormComponent,
      outlet: 'filter-form'
    }
  ]},
  { path: 'dish-details/:id', component: DishDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})  
export class AppRoutingModule {}