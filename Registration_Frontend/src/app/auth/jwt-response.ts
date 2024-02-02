
export class JwtResponse {
  token: string;
  type: string;

  constructor(token: string, type: string) {
    this.token = token;
    this.type = type;
  }
}
