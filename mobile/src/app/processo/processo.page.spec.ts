import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ProcessoPage } from './processo.page';

describe('ProcessoPage', () => {
  let component: ProcessoPage;
  let fixture: ComponentFixture<ProcessoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProcessoPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ProcessoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
