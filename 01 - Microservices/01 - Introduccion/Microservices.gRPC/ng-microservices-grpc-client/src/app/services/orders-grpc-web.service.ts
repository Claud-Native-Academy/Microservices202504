import { Injectable } from '@angular/core';
import { CreateOrderRequest, OrderResponse } from '../../generated/orders_pb';
import { OrdersServiceClient } from '../../generated/OrdersServiceClientPb';
import { grpc } from '@improbable-eng/grpc-web';

@Injectable({
  providedIn: 'root'
})
export class OrdersGrpcWebService {
  private client: OrdersServiceClient;

  constructor() {
    this.client = new OrdersServiceClient('https://localhost:7264');
  }

  createOrder(productId: string, quantity: number): Promise<OrderResponse> {
    return new Promise((resolve, reject) => {
      const request = new CreateOrderRequest();
      request.setProductid(productId);
      request.setQuantity(quantity);

      this.client.createOrder(request, {}, (err, response) => {
        if (err) {
          console.error('gRPC error:', err.message);
          reject(err);
        } else {
          resolve(response);
        }
      });
    });
  }
}
