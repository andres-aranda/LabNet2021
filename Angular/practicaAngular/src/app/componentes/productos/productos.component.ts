import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto-service.service';
import { MyPopUpComponent } from '../my-pop-up/my-pop-up.component';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss']
})
export class ProductosComponent implements OnInit {

  listaProductos: Producto[];

  //#region Constructor y OnInit

  constructor(private productService: ProductoService, public dialog: MatDialog) {
    productService.getProductos().subscribe({
      next: resp => {
        this.listaProductos = resp;
      },
      error: error => {
        this.openDialog("Error. No se pudo recuperar lista de productos.");
      }
    });
  }
  ngOnInit(): void {
  }

  //#endregion

  //#region Funciones y metodos

  goToUrl = (x) => {
    document.location.href = 'Editar-New/' + x;
  }

  eliminar = (id) => {
    this.productService.deleteProducto(id).subscribe({
      next: data => {
        this.openDialog("El producto fue eliminado con Exito.");
        this.productService.getProductos().subscribe(resp =>
          this.listaProductos = resp)
      },
      error: error => {
        this.openDialog("Error. Producto no eliminado. Intentelo mas tarde");
      }
    });
  }
  openDialog(messaga: string): void {
    const dialogRef = this.dialog.open(MyPopUpComponent, {
      width: '360px',
      data: messaga,
    })
  }

  //#endregion


}
