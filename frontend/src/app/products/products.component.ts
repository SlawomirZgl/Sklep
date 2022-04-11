import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/model/Product';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  @Input() data: Product[]
  
  @Output() onClick: EventEmitter<Product> = new EventEmitter<Product> ();

  constructor() { }

  ngOnInit(): void {
  }

  onDodajClick(p:Product): void{    
      this.onClick.emit(p)
  }
}
