import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@app/_models';
import { PaginatedResponse } from '@app/_rest/paginated.response';

const baseUrl = `${environment.apiUrl}/users`;

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  getAll(): Promise<PaginatedResponse<User[]>> {
    let response: any;
    try {
      this.http.get<PaginatedResponse<User[]>>(
        baseUrl).subscribe(r => response = r);
      if (response.totalElements > 0) {
        const pagedResponse = toPaginatedResponseModel<UserDTO, UserModel>(response);
        pagedResponse.listElements = toUserModelCollection(response.listElements);
        return Promise.resolve(pagedResponse);
      }
      // return Promise.resolve(null);
    } catch (error) {
      return Promise.reject(this.getError(error));
    }
  }

  getById(id: number) {
    return this.http.get<User>(`${baseUrl}/${id}`);
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
