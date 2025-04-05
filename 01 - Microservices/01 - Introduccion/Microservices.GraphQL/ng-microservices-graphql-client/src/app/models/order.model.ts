import { Product } from "./product.model";

export interface Order {
  id: number;  
  quantity: number;
  status: string;
  totalPrice: number;
  product?: Product;
}
