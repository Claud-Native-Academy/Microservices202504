import { Routes } from '@angular/router';
import { GrpcWebOrderComponent } from './components/grpc-web-order/grpc-web-order.component';
import { TranscodingOrderComponent } from './components/transcoding-order/transcoding-order.component';

export const routes: Routes = [
  { path: '', redirectTo: 'grpc-web-order', pathMatch: 'full' },
  { path: 'grpc-web-order', component: GrpcWebOrderComponent },
  { path: 'transcoding-order', component: TranscodingOrderComponent },
];
