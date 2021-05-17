import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscriber } from 'rxjs';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto-service.service';
import { MyPopUpComponent } from '../my-pop-up/my-pop-up.component';


@Component({
  selector: 'app-new-edit',
  templateUrl: './new-edit.component.html',
  styleUrls: ['./new-edit.component.scss']
})
export class NewEditComponent implements OnInit {

  //#region Constructor y OnInit

    constructor(private readonly fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductoService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      nombre: [null, Validators.required],
      cantidadPorUnidad: [''],
      precioUnidad: [''],
      ordenadas: [''],
      stock: ['']
    });

    this.producto = new Producto();
    this.route.paramMap.subscribe(param => {
      if (param.has("id")) {
        let x = parseInt(param.get("id"))
        this.productService.getProducto(x).subscribe({
          next: prod => {
            this.producto = prod;
            this.seteo();
          },
          error: error => {
            this.openDialog("Error. No se pudo recuperar el producto. Verifique ID e intentelo mas tarde.");
          }
        })
      }
    })


  }

  //#endregion

  //#region Declaraciones

  producto: Producto;
  form: FormGroup;

  get nombreCtrl(): AbstractControl {
    return this.form.get('nombre');
  }

  get cantidadPorUnidadCtrl(): AbstractControl {
    return this.form.get('cantidadPorUnidad');
  }

  get precioUnidadCtrl(): AbstractControl {
    return this.form.get('precioUnidad');
  }

  get ordenadasCtrl(): AbstractControl {
    return this.form.get('ordenadas');
  }

  get stockCtrl(): AbstractControl {
    return this.form.get('stock');
  }

  //#endregion

  //#region Funciones y metodos

  openDialog(messaga: string): void {
    const dialogRef = this.dialog.open(MyPopUpComponent, {
      width: '360px',
      data: messaga,
    })
  }

  private seteo = () => {

    if (this.cantidadPorUnidadCtrl) {
      this.cantidadPorUnidadCtrl.setValue(this.producto.CantidadPorUnidad);
    }
    if (this.precioUnidadCtrl) {
      this.precioUnidadCtrl.setValue(this.producto.PrecioUnidad);
    }
    if (this.ordenadasCtrl) {
      this.ordenadasCtrl.setValue(this.producto.UnidadesOrdenadas);
    }
    if (this.stockCtrl) {
      this.stockCtrl.setValue(this.producto.UnidadesEnStock);
    }
    if (this.nombreCtrl) {
      this.nombreCtrl.setValue(this.producto.Nombre);
    }
  }

  onSubmit(): void {
    if (this.nombreCtrl.value != null) {
      this.producto.Nombre = this.nombreCtrl.value;
      this.producto.PrecioUnidad = this.precioUnidadCtrl.value;
      this.producto.CantidadPorUnidad = this.cantidadPorUnidadCtrl.value;
      this.producto.UnidadesEnStock = this.stockCtrl.value;
      this.producto.UnidadesOrdenadas = this.ordenadasCtrl.value;

      if (this.producto.ProductID != null) {
        this.productService.putProducto(this.producto, this.producto.ProductID).subscribe({
          next: data => {
            this.openDialog("El producto fue modificado con Exito.");
          },
          error: error => {
            this.openDialog("Error. No se pudo actualizar el producto. Intentelo mas tarde.");
          }
        });
      } else {
        this.productService.postProducto(this.producto).subscribe({
          next: data => {
            this.openDialog("El producto fue creado con Exito.");
            this.onClickLimpiar();
          },
          error: error => {
            this.openDialog("Error. No se pudo crear el producto. Intentelo mas tarde.");
          }
        });
      }
    }

  }

  onClickLimpiar(): void {
    this.form.reset();
  }

  //#endregion

}
