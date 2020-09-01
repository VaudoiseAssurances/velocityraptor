import { AddSprintComponent } from './add-sprint/add-sprint.component';
import { VelocityraptorApiService } from './services/velocityraptor-api.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SprintComponent } from './sprint/sprint.component';
import { ProductComponent } from './product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SprintComponent,
    ProductComponent,
    AddSprintComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'products/:productId', component: ProductComponent },
      { path: 'products/:productId/new-sprint', component: AddSprintComponent },
      { path: 'products:productId/sprints/:sprintId', component: SprintComponent },
    ])
  ],
  providers: [VelocityraptorApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
