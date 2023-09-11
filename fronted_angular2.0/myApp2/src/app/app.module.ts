import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // agregamos el http client para las solicitudes
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { ConfirmationModalComponent } from './confirmation-modal/confirmation-modal.component'; // Agrega esta línea


@NgModule({
declarations: [
AppComponent,
ConfirmationModalComponent
],
imports: [
BrowserModule,
AppRoutingModule,
HttpClientModule,
FormsModule// Agregar HttpClientModule
],
providers: [],
bootstrap: [AppComponent]
})
export class AppModule { }
