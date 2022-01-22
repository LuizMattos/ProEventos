import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {



  public eventosFiltrados: any = [];
  public eventos: any = [];

  private _filtrolista: string = '';

  public get filtrolista() {
    return this._filtrolista;
  }

  public set filtrolista(value: string) {
    this._filtrolista = value;
    this.eventosFiltrados = this.filtrolista ? this.filtrarEventos(this.filtrolista) :  this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleUpperCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleUpperCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleUpperCase().indexOf(filtrarPor) !== -1
    )
  }
  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): any {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = response;
      },
      error => console.log(error),
    );
  }

}
