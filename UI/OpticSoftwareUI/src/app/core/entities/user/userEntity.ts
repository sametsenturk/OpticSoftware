import { LanguageEnum } from '../../enums/languageEnum';
import { BaseEntity } from '../baseEntity';

export class UserEntity extends BaseEntity {
  username: string;
  password: string;
  isActive: boolean;
  language: LanguageEnum;
}
