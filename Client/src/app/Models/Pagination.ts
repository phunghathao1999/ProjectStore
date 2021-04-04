export class Pagination {
    searchValue: string;
    currentPage: number;
    pageSize: number;
    sort: string;
    sortKey: string;
    idEmployee: number;
    constructor(searchValue: string, currentPage: number, pageSize: number, sort: string, sortKey: string, idEmployee: number)
    {
        this.searchValue = searchValue;
        this.currentPage = currentPage;
        this.pageSize = pageSize;
        this.sort = sort;
        this.sortKey = sortKey;
        this.idEmployee = idEmployee;
    }
}