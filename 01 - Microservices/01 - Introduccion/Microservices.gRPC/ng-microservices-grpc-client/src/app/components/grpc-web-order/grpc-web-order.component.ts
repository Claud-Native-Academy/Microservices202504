import { Component } from '@angular/core';
import { OrderResponse } from '../../../generated/orders_pb';
import { OrdersGrpcWebService } from '../../services/orders-grpc-web.service';
import { CurrencyPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-grpc-web-order',
  imports: [
    CurrencyPipe,
    FormsModule
  ],
  templateUrl: './grpc-web-order.component.html',
  styleUrl: './grpc-web-order.component.scss'
})
export class GrpcWebOrderComponent {
  productId = '';
  quantity = 1;
  result: OrderResponse = new OrderResponse();
  constructor(private ordersService: OrdersGrpcWebService) { }

  async create(event: Event) {
    this.ordersService.createOrder(this.productId, this.quantity).then(res => {
      this.result = res;
    });
  }
}
