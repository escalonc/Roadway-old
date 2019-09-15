import { useFetch } from "../../hooks"
import BrandModel from "./brandModel";

const brandsUrl = `${process.env.REACT_APP_BASE_URL}/brands`;

export function FetchBrands() {
    return useFetch<BrandModel[]>(brandsUrl) || [];
}