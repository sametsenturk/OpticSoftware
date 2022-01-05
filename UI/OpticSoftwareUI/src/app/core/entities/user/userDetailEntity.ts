import { UserTypeEnum } from '../../enums/userTypeEnum';
import { BaseEntity } from '../baseEntity';
import { CompanyEntity } from '../company/companyEntity';
import { UserEntity } from './userEntity';

export class UserDetailEntity extends BaseEntity {
  name: string;
  surname: string;
  phoneNumber: string;
  roles: string;
  userType: UserTypeEnum;
  userId: number;
  companyId: number;
  user: UserEntity;
  company: CompanyEntity;
}
