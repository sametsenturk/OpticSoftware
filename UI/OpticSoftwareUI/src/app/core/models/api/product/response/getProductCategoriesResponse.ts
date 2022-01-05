import { ProductCategoryEntity } from 'src/app/core/entities/product/productCategoryEntity';
import { BaseResponse } from '../../baseResponse';

export class GetProductCategoriesResponse extends BaseResponse {
  productCategories: ProductCategoryEntity[];
}
