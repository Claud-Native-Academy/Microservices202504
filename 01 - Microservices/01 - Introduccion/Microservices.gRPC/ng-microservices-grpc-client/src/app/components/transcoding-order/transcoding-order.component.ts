import { Component } from '@angular/core';
import { OrdersTranscodingService } from '../../services/orders-transcoding.service';
import { CurrencyPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Order } from '../../models/order';

@Component({
  selector: 'app-transcoding-order',
  imports: [
    CurrencyPipe,
    FormsModule
  ],
  templateUrl: './transcoding-order.component.html',
  styleUrl: './transcoding-order.component.scss'
})
export class TranscodingOrderComponent {
  productId = '';
  quantity = 1;
  result: Order = new Order();


  constructor(private orderService: OrdersTranscodingService) {
    
  }

  create(event: Event) {
    const request = { productId: this.productId, quantity: this.quantity };
    this.orderService.createOrder(request).subscribe(result => {
      this.result = result;
    });
  }
}
