import { BaseEntity } from '../baseEntity';
import { CompanyEntity } from '../company/companyEntity';
import { ProductEntity } from './productEntity';

export class ProductCategoryEntity extends BaseEntity {
  name: string;
  isDeleted: boolean;
  companyId: number;
  company: CompanyEntity;
  products: ProductEntity[];
}
