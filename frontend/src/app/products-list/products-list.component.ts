import { Component, OnInit } from '@angular/core';
import { BasketItemDto } from 'src/model/basket-item';
import { Pagination } from 'src/model/pagination';
import { Product } from 'src/model/Product';
import { BasketService } from '../basket.service';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  page: number = 0;
  rowsPerPage: number = 5;
  produkty: Product[]=[];
  basket: BasketItemDto[]=[];
  wyswietl:boolean = false;
  
  constructor(private productsService: ProductsService,  private basketService: BasketService) {   
    this.refresh();
  }

  ngOnInit(): void {
  }   

  onDodawanieClick(event: Product){ 
    this.wyswietl = true;
    this.basketService.post(event.id, 1).subscribe(response => this.basket = response);
  }

  onWyczyscClick(){
    this.basket = [];
    this.basketService.delete().subscribe();
    this.wyswietl = false;
  }
  refresh(): void {
    let pagination = new Pagination();
    pagination.page = this.page;
    pagination.rowsPerPage = this.rowsPerPage;
    pagination.sortAscending = true;
    pagination.sortColumn = "name";

    this.productsService.get(pagination).subscribe(response => this.produkty = response.data);
  }

}
