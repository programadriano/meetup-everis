import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Products } from '../model/products';
import { HttpUtilService } from '../services/http-util.service';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private url: string = this._httpUtil.url('product');

  constructor(private _http: HttpClient, private _httpUtil: HttpUtilService) { }

  /**
   * Get All products
   */
  getAll() {
    return this._http.get<Products[]>(this.url, { observe: 'response' });
  }

  /**
   * Get products by Id
   */
  getById(id) {
    return this._http.get<Products>(`${this.url}/${id}`, {
      observe: 'response'
    });
  }

  /**
   * Save product
   * @param products
   */
  save(products) {
    console.log(products);
    return this._http.post(this.url, products);
  }

  /**
   * Update product
   * @param products
   */
  update(products) {
    return this._http.put(`${this.url}/${products._id}`, products);
  }

  /**
   * Remove product
   * @param products
   */
  delete(id) {
    return this._http.delete(`${this.url}/?id=${id}`);
  }
}
