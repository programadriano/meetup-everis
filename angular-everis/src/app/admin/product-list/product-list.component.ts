import { Component, OnInit } from '@angular/core';

import { Products } from '../../model/products';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public products: Products[];

  constructor(private productsService: ProductsService) {}

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.productsService
      .getAll()
      .subscribe(this.cbSuccess.bind(this), this.cbError.bind(this));
  }

  delete(id) {
    this.productsService.delete(id).subscribe(data => {});
  }

  edit(id) {
    alert(id);
  }

  /**
   * Handle Success
   * @param response
   */
  cbSuccess(response) {
    this.products = Object.assign(response.body);
  }

  /**
   * Handler Error
   * @param error
   */
  cbError(error) {
    console.log('ERROR', error);
  }
}
