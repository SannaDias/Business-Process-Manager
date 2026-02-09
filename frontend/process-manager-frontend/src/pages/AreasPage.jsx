import { useEffect, useState } from "react";
import { getProcessesByArea } from "../services/api";
import CreateAreaForm from "../components/CreateAreaForm";
import ProcessTree from "../components/ProcessTree";


export default function AreasPage() {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);

  const AREA_ID = "365bdc8b-2802-42fd-82db-28ec67468691";

  async function loadData() {
    try {
      const result = await getProcessesByArea(AREA_ID);
      setData(result);
    } catch (err) {
      setError(err.message);
    }
  }

  useEffect(() => {
    loadData();
  }, []);

  return (
    <div style={{ padding: 20 }}>
      <CreateAreaForm onAreaCreated={loadData} />

      <hr />

      {error && <p style={{ color: "red" }}>{error}</p>}
      {!data && <p>Carregando...</p>}

      {data && (
        <>
          <h1>{data.areaName}</h1>

         <ProcessTree
            processes={data.processes}
            areaId={data.areaId}
            onRefresh={loadData}
            />
        </>
      )}
    </div>
  );
}
