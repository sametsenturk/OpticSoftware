import { BaseEntity } from '../baseEntity';
import { CompanyEntity } from './companyEntity';

export class CompanyParameterEntity extends BaseEntity {
  parameterName: string;
  parameterValue: string;
  companyId: number;
  company: CompanyEntity;
}
