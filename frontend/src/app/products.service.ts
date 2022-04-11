import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginatedData } from 'src/model/paginated-data';
import { Pagination } from 'src/model/pagination';
import { Product } from 'src/model/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private produkty: Product[]=[
    new Product(1, "Chleb", "Dobrze wypieczony", 8),
    new Product(2, "Bulka", "Kajzerka", 2),
    new Product(3, "Ciastko", "Z kremem i owocami", 10),
  ]

  constructor(private httpClient: HttpClient) {
    
  }
  
  get(pagination?: Pagination): Observable<PaginatedData<Product>> {
    if(pagination == null){
      pagination = new Pagination();
      pagination.sortColumn = 'name';
      pagination.page = 0;
      pagination.rowsPerPage = 10;
      pagination.sortAscending = true; 
    }
    return this.httpClient.get<PaginatedData<Product>>('https://localhost:44312/api/Products?' + 
    'sortColumn=' + pagination.sortColumn +
    '&page='+ pagination.page +
    '&rowsPerPage=' + pagination.rowsPerPage +
    '&sortAscending=' + pagination.sortAscending
    );
  }
}
