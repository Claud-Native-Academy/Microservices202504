import * as jspb from 'google-protobuf'

import * as google_api_annotations_pb from './google/api/annotations_pb'; // proto import: "google/api/annotations.proto"


export class CreateOrderRequest extends jspb.Message {
  getProductid(): string;
  setProductid(value: string): CreateOrderRequest;

  getQuantity(): number;
  setQuantity(value: number): CreateOrderRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): CreateOrderRequest.AsObject;
  static toObject(includeInstance: boolean, msg: CreateOrderRequest): CreateOrderRequest.AsObject;
  static serializeBinaryToWriter(message: CreateOrderRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): CreateOrderRequest;
  static deserializeBinaryFromReader(message: CreateOrderRequest, reader: jspb.BinaryReader): CreateOrderRequest;
}

export namespace CreateOrderRequest {
  export type AsObject = {
    productid: string,
    quantity: number,
  }
}

export class GetOrderRequest extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): GetOrderRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): GetOrderRequest.AsObject;
  static toObject(includeInstance: boolean, msg: GetOrderRequest): GetOrderRequest.AsObject;
  static serializeBinaryToWriter(message: GetOrderRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): GetOrderRequest;
  static deserializeBinaryFromReader(message: GetOrderRequest, reader: jspb.BinaryReader): GetOrderRequest;
}

export namespace GetOrderRequest {
  export type AsObject = {
    orderid: string,
  }
}

export class UpdateOrderRequest extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): UpdateOrderRequest;

  getProductid(): string;
  setProductid(value: string): UpdateOrderRequest;

  getQuantity(): number;
  setQuantity(value: number): UpdateOrderRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): UpdateOrderRequest.AsObject;
  static toObject(includeInstance: boolean, msg: UpdateOrderRequest): UpdateOrderRequest.AsObject;
  static serializeBinaryToWriter(message: UpdateOrderRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): UpdateOrderRequest;
  static deserializeBinaryFromReader(message: UpdateOrderRequest, reader: jspb.BinaryReader): UpdateOrderRequest;
}

export namespace UpdateOrderRequest {
  export type AsObject = {
    orderid: string,
    productid: string,
    quantity: number,
  }
}

export class DeleteOrderRequest extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): DeleteOrderRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): DeleteOrderRequest.AsObject;
  static toObject(includeInstance: boolean, msg: DeleteOrderRequest): DeleteOrderRequest.AsObject;
  static serializeBinaryToWriter(message: DeleteOrderRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): DeleteOrderRequest;
  static deserializeBinaryFromReader(message: DeleteOrderRequest, reader: jspb.BinaryReader): DeleteOrderRequest;
}

export namespace DeleteOrderRequest {
  export type AsObject = {
    orderid: string,
  }
}

export class DeleteOrderResponse extends jspb.Message {
  getStatus(): string;
  setStatus(value: string): DeleteOrderResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): DeleteOrderResponse.AsObject;
  static toObject(includeInstance: boolean, msg: DeleteOrderResponse): DeleteOrderResponse.AsObject;
  static serializeBinaryToWriter(message: DeleteOrderResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): DeleteOrderResponse;
  static deserializeBinaryFromReader(message: DeleteOrderResponse, reader: jspb.BinaryReader): DeleteOrderResponse;
}

export namespace DeleteOrderResponse {
  export type AsObject = {
    status: string,
  }
}

export class EmptyRequest extends jspb.Message {
  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): EmptyRequest.AsObject;
  static toObject(includeInstance: boolean, msg: EmptyRequest): EmptyRequest.AsObject;
  static serializeBinaryToWriter(message: EmptyRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): EmptyRequest;
  static deserializeBinaryFromReader(message: EmptyRequest, reader: jspb.BinaryReader): EmptyRequest;
}

export namespace EmptyRequest {
  export type AsObject = {
  }
}

export class ListOrdersResponse extends jspb.Message {
  getOrdersList(): Array<OrderResponse>;
  setOrdersList(value: Array<OrderResponse>): ListOrdersResponse;
  clearOrdersList(): ListOrdersResponse;
  addOrders(value?: OrderResponse, index?: number): OrderResponse;

  getTotalitems(): number;
  setTotalitems(value: number): ListOrdersResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): ListOrdersResponse.AsObject;
  static toObject(includeInstance: boolean, msg: ListOrdersResponse): ListOrdersResponse.AsObject;
  static serializeBinaryToWriter(message: ListOrdersResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): ListOrdersResponse;
  static deserializeBinaryFromReader(message: ListOrdersResponse, reader: jspb.BinaryReader): ListOrdersResponse;
}

export namespace ListOrdersResponse {
  export type AsObject = {
    ordersList: Array<OrderResponse.AsObject>,
    totalitems: number,
  }
}

export class OrderResponse extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): OrderResponse;

  getStatus(): string;
  setStatus(value: string): OrderResponse;

  getProductname(): string;
  setProductname(value: string): OrderResponse;

  getTotalprice(): number;
  setTotalprice(value: number): OrderResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderResponse.AsObject;
  static toObject(includeInstance: boolean, msg: OrderResponse): OrderResponse.AsObject;
  static serializeBinaryToWriter(message: OrderResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderResponse;
  static deserializeBinaryFromReader(message: OrderResponse, reader: jspb.BinaryReader): OrderResponse;
}

export namespace OrderResponse {
  export type AsObject = {
    orderid: string,
    status: string,
    productname: string,
    totalprice: number,
  }
}

