import { useState } from "react";
import { createProcess } from "../services/api";

export default function CreateProcessForm({
  areaId,
  parentProcessId = null,
  onCreated,
}) {
  const [name, setName] = useState("");
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  async function handleSubmit(e) {
    e.preventDefault();
    setError(null);

    if (!name.trim()) {
      setError("O nome do processo é obrigatório.");
      return;
    }

    try {
      setLoading(true);

      await createProcess({
        name,
        areaId,
        parentProcessId,
      });

      setName("");
      onCreated();
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }

  return (
    <form onSubmit={handleSubmit} style={{ marginTop: 8 }}>
      <input
        type="text"
        placeholder={
          parentProcessId ? "Nome do subprocesso" : "Nome do processo"
        }
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <button type="submit" disabled={loading}>
        {loading ? "Salvando..." : "Adicionar"}
      </button>

      {error && <p style={{ color: "red" }}>{error}</p>}
    </form>
  );
}
