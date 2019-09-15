import { useState, useEffect } from "react"

export function useFetch<T>(url: string): T | undefined {
    const [data, updateData] = useState<T | undefined>(undefined);
    
    async function fetchServer() {
        try {
            const resp = await fetch(url);
            const json = await resp.json() as T;
            updateData(json)
        }
        catch (e) {
            console.error(e);
        }
    }

    useEffect( () => {
       fetchServer();
    }, [url]);

    return data
}