import { BaseEntity } from '../baseEntity';
import { ProductCategoryEntity } from './productCategoryEntity';

export class ProductEntity extends BaseEntity {
  imageUrl: string;
  name: string;
  model: string;
  description: string;
  price: number;
  stockCount: number;
  isDeleted: boolean;
  productCategoryId: number;
  productCategory: ProductCategoryEntity;
}
