import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Photo, User } from '@app/_models';
import { PaginatedResponse } from '@app/_rest/paginated.response';
import { async, Observable } from 'rxjs';
import { SingleObjectResponse } from '@app/_rest/singleobject.response';
import { PhotoService } from './photo.service';

const baseUrl = `${environment.apiUrl}/users`;

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(
    private http: HttpClient,
    private photoService: PhotoService
  ) { }

  getAll(): Observable<PaginatedResponse<User>> {
    return this.http.get<PaginatedResponse<User>>(`${baseUrl}`);

  }

  getById(id: number): Observable<SingleObjectResponse<User>> {
    return this.http.get<SingleObjectResponse<User>>(`${baseUrl}/${id}`);
  }

  create(params: any): Observable<any> {
    if (params.fileName != null) {
      let photo = new Photo();
      photo.path = params.fileName;
      photo.name = params.fileName;
      let par = { "photo": photo, "file": params.fileName, "category": "avatars" };
      params.fileName = this.photoService.create(par);
    }

    return this.http.post(baseUrl, params);
  }

  update(id: number, params: any) {
    return this.http.put(`${baseUrl}/${id}`, params);
  }

  delete(id: number) {
    return this.http.delete(`${baseUrl}/${id}`);
  }
}
