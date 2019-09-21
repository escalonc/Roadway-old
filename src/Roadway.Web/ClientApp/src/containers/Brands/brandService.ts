const brandsUrl = `${process.env.REACT_APP_BASE_URL}/brands`;
import BrandModel from "./brandModel";

export interface DataPagination<T> {
  totalCount: number;
  data: T[];
}

export async function listBrands() {}
