import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


export abstract class DataService {

  protected urlServiceV1: string = 'http://localhost:50621/v1/'; 

  protected httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor(
      protected http: HttpClient,
      public url: string) {
  }

  getAll() {
    const urlApi = this.urlServiceV1 + this.url;
    return this.http.get(urlApi, this.httpOptions)
    .pipe(  
        catchError((error: Response) => {
        return this.processError(error);
      }));
  }

  getById(id) {
    const urlApi = this.urlServiceV1 + this.url;
    return this.http.get(urlApi + '/' + id, this.httpOptions)
    .pipe(  
      catchError((error: Response) => {
        return this.processError(error);
      }));
  }

  create(resource) {
    const urlApi = this.urlServiceV1 + this.url;
    return this.http.post(urlApi, JSON.stringify(resource), this.httpOptions)
    .pipe(  
      catchError((error: Response) => {
        return this.processError(error);
      }));
  }

  update(resource) {    
    const urlApi = this.urlServiceV1 + this.url;
    return this.http.put(urlApi, JSON.stringify(resource), this.httpOptions)
    .pipe(  
      catchError((error: Response) => {
        return this.processError(error);
      }));
  }

  delete(id) {
    const urlApi = this.urlServiceV1 + this.url;
    return this.http.delete(urlApi + '/' + id, this.httpOptions)
    .pipe(  
        catchError((error: Response) => {
        return this.processError(error);
      }));
  }

  protected processError(error) {
    switch (error.status) {
      case 400:
        return throwError(error);
      case 404:
        return throwError(error);
      case 500:
        return throwError(error);
      default:
        return throwError(error);
    }
  }

}