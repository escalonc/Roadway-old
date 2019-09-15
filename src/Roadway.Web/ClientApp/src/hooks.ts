import { useState, useEffect } from "react";
import axios from "axios";

export function useFetch<T>(url: string): T | undefined {
  const [data, updateData] = useState<T | undefined>(undefined);

  async function fetchServer() {
    try {
      const resp = await axios(url);
      const json = (await resp.data) as T;
      updateData(json);
    } catch (e) {
      console.error(e);
    }
  }

  useEffect(() => {
    fetchServer();
  }, [url]);

  return data;
}
