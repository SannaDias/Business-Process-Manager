import { useState } from "react";
import { updateProcess } from "../services/api";

export default function EditProcessModal({
  process,
  onClose,
  onUpdated,
}) {
  const [name, setName] = useState(process.name);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  async function handleSubmit(e) {
    e.preventDefault();
    setError(null);

    if (!name.trim()) {
      setError("O nome é obrigatório.");
      return;
    }

    try {
      setLoading(true);

      await updateProcess(process.id, {
        name,
        parentProcessId: process.parentProcessId ?? null,
      });

      onUpdated();
      onClose();
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }

  return (
    <div style={overlayStyle}>
      <div style={modalStyle}>
        <h3>Editar processo</h3>

        <form onSubmit={handleSubmit}>
          <input
            value={name}
            onChange={(e) => setName(e.target.value)}
            style={{ width: "100%", marginBottom: 8 }}
          />

          {error && <p style={{ color: "red" }}>{error}</p>}

          <div style={{ display: "flex", gap: 8 }}>
            <button type="submit" disabled={loading}>
              {loading ? "Salvando..." : "Salvar"}
            </button>
            <button type="button" onClick={onClose}>
              Cancelar
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

/* estilos simples do modal */
const overlayStyle = {
  position: "fixed",
  inset: 0,
  background: "rgba(0,0,0,0.4)",
  display: "flex",
  justifyContent: "center",
  alignItems: "center",
  zIndex: 1000,
};

const modalStyle = {
  background: "#fff",
  padding: 20,
  borderRadius: 4,
  width: 320,
};
