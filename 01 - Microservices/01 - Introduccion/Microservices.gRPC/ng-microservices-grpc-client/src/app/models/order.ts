export class Order {
  constructor() {
    this.orderId = '';
    this.productName = '';
    this.status = '';
    this.totalPrice = 0;
   }

  public orderId: string;
  public productName: string;
  public status: string;
  public totalPrice: number;  
}
