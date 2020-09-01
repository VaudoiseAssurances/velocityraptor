import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

/**
 * @description
 * @class
 */
@Injectable()
export class VelocityraptorApiService {
  setAccomplishedPoints(productId: string, sprintId: string, accomplishedPoints: number): Observable<any> {
    return this.client.post<Sprint>('/api/products/' + productId + '/sprints/' + sprintId + '/achieved-points', accomplishedPoints);
  }
  GetAllProducts(): Observable<Product[]> {
    return this.client.get<Product[]>('/api/products');
  }

  getProduct(id: string): Observable<Product> {
    return this.client.get<Product>('/api/products/' + id);
  }

  getSprint(productId: string, sprintId: string): Observable<Sprint> {
    return this.client.get<Sprint>('/api/products/' + productId + '/sprints/' + sprintId);
  }

  createSprint(productId: string, sprint: Sprint) {
    return this.client.post<Sprint>('/api/products/' + productId + '/sprints/', sprint);
  }

  constructor(private client: HttpClient) {
  }

}

export interface Sprint {
  id: string;
  sprintAvailabilities: any[];
  achievedPoints: number;
  capacity: number;
}

// todo: move to dedicated file
export interface Product {
  id: string;
  name: string;
  developers: any[];
  sprints: any[];
}
