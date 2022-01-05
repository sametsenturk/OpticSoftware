import { UserTypeEnum } from 'src/app/core/enums/userTypeEnum';
import { BaseRequest } from '../../baseRequest';

export class RegisterRequest extends BaseRequest {
  username: string;
  password: string;
  name: string;
  surname: string;
  phoneNumber: string;
  roles: string;
  userType: UserTypeEnum;
}
