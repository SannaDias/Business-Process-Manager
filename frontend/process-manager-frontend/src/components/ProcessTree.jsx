import { useState } from "react";
import CreateProcessForm from "./CreateProcessForm";
import EditProcessModal from "./EditProcessModal";

export default function ProcessTree({
  processes,
  areaId,
  onRefresh,
  level = 0,
}) {
  
  const [editingProcess, setEditingProcess] = useState(null);

  if (!processes || processes.length === 0) {
    return null;
  }

  return (
    <>
      <ul style={{ marginLeft: level * 24 }}>
        {processes.map((process) => (
          <li key={process.id} style={{ marginBottom: 12 }}>
            <div
              style={{
                fontWeight: level === 0 ? "bold" : "normal",
                opacity: level === 0 ? 1 : 0.85,
              }}
            >
              {level > 0 && "↳ "}
              {process.name}

              {/* 🔹 BOTÃO EDITAR */}
              <button
                style={{ marginLeft: 8 }}
                onClick={() => setEditingProcess(process)}
              >
                Editar
              </button>
            </div>

            <CreateProcessForm
              areaId={areaId}
              parentProcessId={process.id}
              onCreated={onRefresh}
            />

            {process.children && process.children?.length > 0 && (
              <ProcessTree
                processes={process.children}
                areaId={areaId}
                onRefresh={onRefresh}
                level={level + 1}
              />
            )}
          </li>
        ))}
      </ul>

      {/* 🔹 MODAL */}
      {editingProcess && (
        <EditProcessModal
          process={editingProcess}
          onClose={() => setEditingProcess(null)}
          onUpdated={onRefresh}
        />
      )}
    </>
  );
}
