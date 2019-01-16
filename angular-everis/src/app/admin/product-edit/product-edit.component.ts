import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  public productId: number;


  constructor(private activatedRoute: ActivatedRoute, ) {
    this.activatedRoute.params.subscribe(param => {
      this.productId = param['id'];
    })

  }

  ngOnInit() {
  }

}
