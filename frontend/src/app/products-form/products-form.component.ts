import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/model/Product';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products-form',
  templateUrl: './products-form.component.html',
  styleUrls: ['./products-form.component.css']
})
export class ProductsFormComponent implements OnInit {
  product: Product;
  private productId: number;

  constructor(private activatedRoute: ActivatedRoute, 
    private productsService: ProductsService,
    private router:Router,
    ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(res => {
      this.productId = res['id'];
      this.productsService.getById(res['id']).subscribe(res2 => this.product = res2);
    });
  }

  onSubmit(event: NgForm): void {
    //this.productsService.put(this.productId, this.product);
    this.productsService.put(this.productId, event.value).subscribe(res => {
      this.router.navigateByUrl('products');
    }), (error) => console.log(error);    

  }
}