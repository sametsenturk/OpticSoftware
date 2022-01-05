import { BaseRequest } from '../../baseRequest';

export class LoginRequest extends BaseRequest {
  username: string;
  password: string;
}
