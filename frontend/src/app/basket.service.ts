import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketItemDto } from 'src/model/basket-item';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private httpClient: HttpClient) { }
  post(productId: number, count:number): Observable<BasketItemDto[]>{
      return this.httpClient.post<BasketItemDto[]>('https://localhost:44312/api/Basket/' + productId, count);
  }
  delete(){
    return this.httpClient.delete('https://localhost:44312/api/Basket');
  }
}
