import { useState } from "react";
import { createArea } from "../services/api";

export default function CreateAreaForm({ onAreaCreated }) {
  const [name, setName] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  async function handleSubmit(e) {
    e.preventDefault();
    setError(null);

    if (!name.trim()) {
      setError("O nome da área é obrigatório.");
      return;
    }

    try {
      setLoading(true);
      await createArea(name);
      setName("");

      if (onAreaCreated) {
        onAreaCreated();
      }
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Criar nova área</h2>

      <input
        type="text"
        placeholder="Nome da área"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <button type="submit" disabled={loading}>
        {loading ? "Salvando..." : "Criar área"}
      </button>

      {error && <p style={{ color: "red" }}>{error}</p>}
    </form>
  );
}
