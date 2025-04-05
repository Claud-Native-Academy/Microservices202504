import { Component, inject, OnInit, signal } from '@angular/core';
import { GraphqlService } from '../../services/graphql.service';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-products',
  imports: [],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {
  private readonly graphqlService = inject(GraphqlService);

  readonly products = signal<Product[] | null>(null);
  readonly loading = signal(true);
  readonly error = signal<string | null>(null);

  ngOnInit(): void {
    this.graphqlService.getProducts().subscribe({
      next: (data) => {        
        this.products.set(data.products);
        this.loading.set(false);
      },
      error: (err) => {
        this.error.set(err.message ?? 'Unknown error');
        this.loading.set(false);
      }
    });
  }
}
