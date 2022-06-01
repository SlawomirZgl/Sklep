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
  navLinks: any[];

   constructor(){     
    this.navLinks = [
      {
          label: 'Produkty',
          link: './products',
          index: 0
      }, {
          label: 'Users',
          link: './users',
          index: 1
      }, {
          label: 'Basket',
          link: './basket',
          index: 2
      }, 
  ];
   }

}
