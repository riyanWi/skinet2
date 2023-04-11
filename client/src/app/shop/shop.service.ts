import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { ShopParams } from '../shared/models/shopParams';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseurl = "https://localhost:5001/api/"

  constructor(private http: HttpClient) { }

  getProducts(ShopParams: ShopParams){
    let params = new HttpParams();

    if(ShopParams.brandId > 0) params = params.append('brandId', ShopParams.brandId);
    if(ShopParams.typeId > 0) params = params.append('typeId', ShopParams.typeId);
    params = params.append('sort', ShopParams.sort);
    params = params.append('pageIndex', ShopParams.pageNumber);
    params = params.append('pageSize', ShopParams.pageSize);
    if (ShopParams.search) params = params.append('search', ShopParams.search)


    return this.http.get<Pagination<Product[]>>(this.baseurl + 'products', {params});
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseurl + 'products/brands');
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseurl + 'products/types');
  }
}
