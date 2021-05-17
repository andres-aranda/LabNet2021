import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Producto } from '../models/producto';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http: HttpClient) { }

  postProducto(request: Producto) {
    return this.http.post(environment.product + 'Product/', request);
  }
  putProducto(request: Producto, id: number) {
    return this.http.put(environment.product + 'Product/' + id, request);
  }
  getProducto(id: number): Observable<Producto> {
    return this.http.get<any>(environment.product + 'Product/' + id);
  }
  deleteProducto(id: number): Observable<Producto> {
    return this.http.delete<any>(environment.product + 'Product/' + id);
  }
  getProductos(): Observable<Producto[]> {
    return this.http.get<any>(environment.product + 'Product')
  }
}
