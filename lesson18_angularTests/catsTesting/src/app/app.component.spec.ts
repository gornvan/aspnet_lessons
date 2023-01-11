import { ComponentFixture, TestBed } from '@angular/core/testing';
import { StubCatfoodService } from 'src/testing/stubs/StubCatFoodService';
import { AppComponent } from './app.component';

import { CatfoodService } from './services/catfood.service';

describe('AppComponent', () => {
  let appComponent: AppComponent;
  let appCompFixture: ComponentFixture<AppComponent>;
  let catFoodServiceStub: StubCatfoodService;

  function initStubs() {
    catFoodServiceStub = new StubCatfoodService();
  }
  async function initComponent() {
    await TestBed
      .configureTestingModule({
        declarations: [
          AppComponent
        ],
        providers: [
          { provide: CatfoodService, useValue: {} }
        ]
      })
      .overrideProvider(CatfoodService, { useValue: catFoodServiceStub })
      .compileComponents();

    appCompFixture = TestBed.createComponent(AppComponent);
    appComponent = appCompFixture.componentInstance;
  }

  beforeEach(async () => {
    initStubs();
  });

  it('should create the app', async () => {
    await initComponent();
    expect(appComponent).toBeTruthy();
  });

  it(`should have as title 'catsTesting'`, async () => {
    await initComponent();
    expect(appComponent.title).toEqual('catsTesting');
  });

  it('should render title', async () => {
    await initComponent();
    appCompFixture.detectChanges();
    const compHtmlElement = appCompFixture.nativeElement as HTMLElement;
    expect(compHtmlElement.querySelector('.content span')?.textContent)
      .toContain('catsTesting app is running!');
  });

  it('shows that cat is hungry in case there is no food', async () => {
    catFoodServiceStub.setFood('');
    expect(catFoodServiceStub.requestFoodCalled).toEqual(0);
    await initComponent();

    appCompFixture.detectChanges();

    const text = appCompFixture.nativeElement.querySelector('#catStat').textContent;
    expect(text).toContain('hungry!');
  });

  it('tries to feed the cat', async () => {
    await initComponent();
    appCompFixture.detectChanges();
    expect(catFoodServiceStub.requestFoodCalled).toEqual(1);
  });
});
