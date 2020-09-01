import { Component, OnInit } from '@angular/core';
import { VelocityraptorApiService, Product } from '../services/velocityraptor-api.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})

export class ProductComponent implements OnInit {
  product: Product = {
    sprints: []
  } as Product;

  constructor(private route: ActivatedRoute, private service: VelocityraptorApiService) { }

  ngOnInit() {
    this.route.paramMap
    .pipe(
      switchMap(params => {
        const id = params.get('productId');
        return this.service.getProduct(id);
      })
    )
    .subscribe(p => this.product = p);
  }
}
