import { Injectable } from '@angular/core';
import { gql, GraphQLClient } from 'graphql-request';
import { firstValueFrom, from } from 'rxjs';
import { OrdersResponse } from './order.response';
import { Observable } from 'rxjs';
import { ProductsResponse } from './products.response';

@Injectable({
  providedIn: 'root'
})
export class GraphqlService {
  private client = new GraphQLClient('https://localhost:7258/graphql'); 

  private readonly ordersQuery = gql`
    query {
      orders {
        id,        
        quantity,
        status,
        totalPrice,
        product {
          id,
          name,
          price  
        }
      }
    }
  `;

  private readonly productsQuery = gql`
    query {
      products{
        id,
        name,
        price,
        category{
          name
        }
      }
    }
  `;

  public getOrders(): Observable<OrdersResponse> {
    return from(
      firstValueFrom(
        from(this.client.request<OrdersResponse>(this.ordersQuery))
      )
    );
  }

  public getProducts(): Observable<ProductsResponse> {
    return from(
      firstValueFrom(
        from(this.client.request<ProductsResponse>(this.productsQuery))
      )
    );
  }
}
