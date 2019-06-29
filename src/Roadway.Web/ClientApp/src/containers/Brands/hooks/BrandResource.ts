import { Resource } from "rest-hooks";

class BrandResource extends Resource {
  readonly id: number | null = null;
  readonly name: string = "";

  pk() {
    return this.id;
  }

  static urlRoot = `${process.env.REACT_APP_BASE_URL}/brands`;
}

export default BrandResource;
