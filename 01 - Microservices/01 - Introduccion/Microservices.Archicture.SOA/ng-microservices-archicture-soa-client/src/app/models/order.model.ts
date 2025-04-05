export interface Order {
  id: number;
  productId: number;
  quantity: number;
  totalPrice: number;
  productName?: string;
}
