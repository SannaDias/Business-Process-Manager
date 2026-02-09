const API_BASE_URL = "https://localhost:64612/api";

export async function getProcessesByArea(areaId) {
  const response = await fetch(`${API_BASE_URL}/areas/${areaId}/processes`);

  if (!response.ok) {
    throw new Error("Erro ao buscar processos da área");
  }

  return response.json();
}

export async function createArea(name) {
  const response = await fetch(`${API_BASE_URL}/areas`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ name }),
  });

  if (!response.ok) {
    throw new Error("Erro ao criar área");
  }

  return response.json();
}

export async function createProcess({ name, areaId, parentProcessId }) {
  const response = await fetch("https://localhost:64612/api/processes", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      name,
      areaId,
      parentProcessId: parentProcessId || null,
    }),
  });

  if (!response.ok) {
    throw new Error("Erro ao criar processo");
  }

  return ;
}

export async function updateProcess(id, data) {
  const response = await fetch(`https://localhost:64612/api/processes/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Erro ao atualizar processo");
  }
}
