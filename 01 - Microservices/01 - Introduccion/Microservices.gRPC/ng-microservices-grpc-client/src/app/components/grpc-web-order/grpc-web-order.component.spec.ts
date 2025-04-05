import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrpcWebOrderComponent } from './grpc-web-order.component';

describe('GrpcWebOrderComponent', () => {
  let component: GrpcWebOrderComponent;
  let fixture: ComponentFixture<GrpcWebOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GrpcWebOrderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GrpcWebOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
