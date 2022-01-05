import { ProductEntity } from 'src/app/core/entities/product/productEntity';
import { BaseResponse } from '../../baseResponse';

export class GetProductsByCategoryResponse extends BaseResponse {
  products: ProductEntity[];
}
