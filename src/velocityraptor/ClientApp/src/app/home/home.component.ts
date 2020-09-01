import { VelocityraptorApiService } from './../services/velocityraptor-api.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from '../services/velocityraptor-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public products: Product[];

  constructor (private client: VelocityraptorApiService) {

  }
  ngOnInit(): void {
    // TODO: move to dedicated service
    this.client.GetAllProducts().subscribe(o => this.products = o);
  }
}

