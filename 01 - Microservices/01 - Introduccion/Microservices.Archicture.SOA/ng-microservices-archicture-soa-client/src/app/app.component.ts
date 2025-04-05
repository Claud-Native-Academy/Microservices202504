import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Product } from './models/product.model';
import { Order } from './models/order.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { OrdersService } from './services/orders.service';
import { ProductsService } from './services/products.service';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    ReactiveFormsModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  products: Product[] = [];
  orders: Order[] = [];
  productControl = new FormControl(0);
  quantityControl = new FormControl(1);
  error = '';

  private ordersService = inject(OrdersService);
  private productsService = inject(ProductsService);


  ngOnInit() {
    this.loadProducts();    
  }

  private loadProducts() {
    this.productsService.getProducts().subscribe(data => {
      this.products = data;
      if (data.length > 0) this.productControl.setValue(data[0].id);
      this.loadOrders();
    },
      error => this.error = 'Error to load products. Please try again later.'
    );
  }

  private loadOrders() {
    this.ordersService.getOrders().subscribe(data => {
      this.orders = data;
      this.orders.forEach(order => {
        const product = this.products.filter(p => p.id === order.productId)[0];
        
        if (product) {
          order.productName = product.name;
        }
      });
    },
      error => this.error = 'Error to load orders. Please try again later.'
    );
  }

  public createOrder(event: Event) {
    event.preventDefault();
    const productId = this.productControl.value ?? 0;
    const quantity = this.quantityControl.value ?? 0;
    this.ordersService.createOrder({ productId, quantity } as Order).subscribe({
      next: result => {
        this.loadOrders();
        this.error = '';
      },
      error: (err) => {
        const message = err?.error?.title || 'Error to create order. Please try again later.';
        this.error = message;
      }
    });
  }
}
