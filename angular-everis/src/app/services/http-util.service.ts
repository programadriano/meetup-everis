import { Injectable } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpUtilService {
  constructor() { }

  private API_URL = environment.API_URL + "/api/";

  url(path: string) {
    return this.API_URL + path;
  }

  headers() {
    const headersParams = new Headers({ 'Content-Type': 'application/json' });

    if (localStorage['token']) {
      const authToken = localStorage['token'];
      headersParams.append('Authorization', `Bearer ${authToken}`);
    }
    const options = new RequestOptions({ headers: headersParams });
    return options;
  }


}
