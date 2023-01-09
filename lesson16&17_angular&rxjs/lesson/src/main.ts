import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { RoutingModule } from './app/routing/routing.module';


platformBrowserDynamic().bootstrapModule(RoutingModule)
  .catch(err => console.error(err));
