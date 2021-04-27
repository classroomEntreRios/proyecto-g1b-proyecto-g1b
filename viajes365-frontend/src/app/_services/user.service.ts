import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@app/_models';
import { PaginatedResponse } from '@app/_rest/paginated.response';
import { async, Observable } from 'rxjs';
import { SingleObjectResponse } from '@app/_rest/singleobject.response';

const baseUrl = `${environment.apiUrl}/users`;

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  getAll(): Observable<PaginatedResponse<User>> {
    return this.http.get<PaginatedResponse<User>>(`${baseUrl}`);

  }

  getById(id: number): Observable<SingleObjectResponse<User>> {
    return this.http.get<SingleObjectResponse<User>>(`${baseUrl}/${id}`);
  }

  create(params: any) {
    return this.http.post(baseUrl, params);
  }

  update(id: number, params: any) {
    return this.http.put(`${baseUrl}/${id}`, params);
  }

  delete(id: number) {
    return this.http.delete(`${baseUrl}/${id}`);
  }
}
