import { BaseEntity } from '../baseEntity';
import { UserDetailEntity } from '../user/userDetailEntity';
import { CompanyParameterEntity } from './companyParameterEntity';

export class CompanyEntity extends BaseEntity {
  name: string;
  expireDate: Date;
  isActive: boolean;
  smsCount: number;
  userDetails: UserDetailEntity[];
  companyParameters: CompanyParameterEntity[];
}
