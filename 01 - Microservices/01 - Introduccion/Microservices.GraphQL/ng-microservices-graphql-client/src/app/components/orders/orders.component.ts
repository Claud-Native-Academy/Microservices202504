import { Component, inject, OnInit, signal } from '@angular/core';
import { GraphqlService } from '../../services/graphql.service';
import { Order } from '../../models/order.model';

@Component({
  selector: 'app-orders',
  imports: [],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss'
})
export class OrdersComponent implements OnInit {
  private readonly graphqlService = inject(GraphqlService);
  readonly orders = signal<Order[] | null>(null);
  readonly loading = signal(true);
  readonly error = signal<string | null>(null);

  ngOnInit(): void {
    this.graphqlService.getOrders().subscribe({
      next: (data) => {
        this.orders.set(data.orders);
        this.loading.set(false);
      },
      error: (err) => {
        this.error.set(err.message ?? 'Unknown error');
        this.loading.set(false);
      }
    });
  }
}
