import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DishesListComponent } from './components/dishes-list/dishes-list.component';

const routes: Routes = [
  { path: "", redirectTo: "all-dishes", pathMatch: 'full'},
  { path: "all-dishes", component: DishesListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})  
export class AppRoutingModule {}