import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewEditComponent } from './componentes/new-edit/new-edit.component';
import { ProductosComponent } from './componentes/productos/productos.component';

const routes: Routes = [
  {path:"Productos",component: ProductosComponent},
  {path:"Editar-New/:id",component:NewEditComponent},
  {path:"Editar-New",component:NewEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
