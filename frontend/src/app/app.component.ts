import { Component } from '@angular/core';
import { BasketItemDto } from 'src/model/basket-item';
import { Product } from 'src/model/Product';
import { BasketService } from './basket.service';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'taiipLab2';
  produkty: Product[]=[];

   constructor(productsService: ProductsService,
    private basketService: BasketService){
      productsService.get().subscribe(response => this.produkty = response.data);
   }

  wyswietl:boolean = false;
   
  basket: BasketItemDto[]=[];

  onDodawanieClick(event: Product){ 
    this.basketService.post(event.id, 1).subscribe(response => this.basket = response);
  }

  onWyczyscClick(){
    this.basket = [];
    this.wyswietl = false;
  }

}
