import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranscodingOrderComponent } from './transcoding-order.component';

describe('TranscodingOrderComponent', () => {
  let component: TranscodingOrderComponent;
  let fixture: ComponentFixture<TranscodingOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TranscodingOrderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TranscodingOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
