import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdersTranscodingService {
  private baseUrl = 'https://localhost:7264/api';

  constructor(private http: HttpClient) { }

  createOrder(order: { productId: string; quantity: number }): Observable<Order> {
    return this.http.post<Order>(`${this.baseUrl}/orders`, order);
  }

  getOrder(orderId: string): Observable<Order> {
    return this.http.get<Order>(`${this.baseUrl}/orders/${orderId}`);
  }

  updateOrder(orderId: string, updateData: { status: string; productName: string; totalPrice: number }):Observable<Order> {
    return this.http.put<Order>(`${this.baseUrl}/orders/${orderId}`, updateData);
  }

  deleteOrder(orderId: string): Observable<string> {
    return this.http.delete<string>(`${this.baseUrl}/orders/${orderId}`);
  }
}
