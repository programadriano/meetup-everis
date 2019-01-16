import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { Products } from '../../model/products';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  constructor(private productsService: ProductsService) {}

  ngOnInit() {}

  save(name, category, description, price, thumb) {
    const p = new Products();
    p.name = name;
    p.category = category;
    p.description = description;
    p.price = price;
    p.thumb = thumb;

    this.productsService.save(p).subscribe(data => {
      alert('Produto salvo com sucesso!');
    });
  }
}
