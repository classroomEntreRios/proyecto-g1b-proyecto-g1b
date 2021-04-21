export class PaginatedResponse<T> {
  public totalElements: number;
  public totalPages: number;
  public pageNumber: number;
  public pageSize: number;
  public listElements: T[];

  constructor() {
    this.totalElements = 0;
    this.totalPages = 0;
    this.pageNumber = 0;
    this.pageSize = 0;
    this.listElements = new Array<T>();
  }
}
