import { useFetch } from "../../hooks";
import BrandModel from "./brandModel";
import { useState, useEffect } from "react";
import axios from "axios";

const brandsUrl = `${process.env.REACT_APP_BASE_URL}/brands`;

export function FetchBrands() {
  return useFetch<BrandModel[]>(brandsUrl) || [];
}

export function SearchBrands(searchTerm: string) {
  const [data, updateData] = useState<BrandModel[]>([]);

  async function fetchServer() {
    try {
      let url: string;

      if (searchTerm.trim() === "") {
        url = brandsUrl;
      } else {
        url = `${brandsUrl}/search`;
      }

      const resp = await axios(url, { params: { searchTerm } });
      const data = (await resp.data) as BrandModel[];
      updateData(data);
    } catch (e) {
      console.error(e);
    }
  }

  useEffect(() => {
    fetchServer();
  }, [searchTerm]);

  return data;
}
