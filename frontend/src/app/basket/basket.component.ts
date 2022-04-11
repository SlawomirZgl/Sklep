import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BasketItemDto } from 'src/model/basket-item';
import { Product } from 'src/model/Product';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  @Input() data: BasketItemDto[];

  constructor() { }

  ngOnInit(): void {
   
  }
}
