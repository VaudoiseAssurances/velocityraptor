import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public products: Product;

  constructor (private client: HttpClient) {

  }
  ngOnInit(): void {
    // TODO: move to dedicated service
    this.client.get<Product>('/api/products').subscribe(o => this.products = o);
  }
}

// todo: move to dedicated file
interface Product {
  id: string;
  name: string;
  developers: any[];
  sprints: any[];
}