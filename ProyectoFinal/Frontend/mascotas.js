
// CONFIG

const API_URL = "https://localhost:7098/api";
let mascotaEditandoId = null;


// INIT

document.addEventListener("DOMContentLoaded", () => {
    cargarDuenos();
    cargarMascotas();
});


// CARGAR DUEÑOS

async function cargarDuenos() {
    const res = await fetch(`${API_URL}/Dueno`);
    const duenos = await res.json();

    const select = document.getElementById("duenoId");
    select.innerHTML = `<option value="">Seleccione un dueño</option>`;

    duenos.forEach(d => {
        select.innerHTML += `<option value="${d.duenoId}">${d.nombre}</option>`;
    });
}
// LISTAR MASCOTAS 
async function cargarMascotas() {
    const res = await fetch(`${API_URL}/Mascota`);
    const mascotas = await res.json();

    const tbody = document.getElementById("tablaMascotas");
    tbody.innerHTML = "";

   mascotas.forEach(m => {
    tbody.innerHTML += `
        <tr>
            <td>${m.nombre}</td>
            <td>${m.dueno}</td>
            <td>${m.especie}</td>
            <td>${m.raza || "-"}</td>
            <td>${m.sexo || "-"}</td>
            <td>
                <button class="btn btn-info btn-sm"
                    onclick="verPerfil(${m.mascotaId})">
                    Ver Perfil
                </button>

                <button class="btn btn-warning btn-sm ms-1"
                    onclick='editarMascota(${JSON.stringify(m)})'>
                    Editar
                </button>

                <button class="btn btn-danger btn-sm ms-1"
                    onclick="eliminarMascota(${m.mascotaId})">
                    🗑
                </button>
            </td>
        </tr>
    `;
});

}




// CARGAR PARA EDICIÓN

async function cargarMascotaParaEditar(id) {
    const res = await fetch(`${API_URL}/Mascota/${id}`);
    const m = await res.json();

    mascotaEditandoId = m.mascotaId;

    document.getElementById("duenoId").value = m.duenoId;
    document.getElementById("nombre").value = m.nombre;
    document.getElementById("especie").value = m.especie;
    document.getElementById("raza").value = m.raza || "";
    document.getElementById("sexo").value = m.sexo;
    document.getElementById("fechaNacimiento").value =
        m.fechaNacimiento?.split("T")[0];

    document.getElementById("btnGuardar").textContent = "Actualizar";
}


// GUARDAR / ACTUALIZAR

async function guardarMascota() {

    const mascota = {
        duenoId: document.getElementById("duenoId").value,
        nombre: document.getElementById("nombre").value.trim(),
        especie: document.getElementById("especie").value,
        raza: document.getElementById("raza").value.trim(),
        sexo: document.getElementById("sexo").value,
        fechaNacimiento: document.getElementById("fechaNacimiento").value
    };

    if (!mascota.duenoId || !mascota.nombre || !mascota.especie || !mascota.sexo) {
        mostrarMensaje("Complete los campos obligatorios", "warning");
        return;
    }

    if (mascotaEditandoId) {
        await fetch(`${API_URL}/Mascota/${mascotaEditandoId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ ...mascota, mascotaId: mascotaEditandoId })
        });

        mostrarMensaje("Mascota actualizada correctamente", "success");
    } else {
        const res = await fetch(`${API_URL}/Mascota`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(mascota)
        });

        const nueva = await res.json();
        mostrarMensaje(`Mascota registrada. ID: ${nueva.mascotaId}`, "success");
    }

    limpiarFormulario();
    mascotaEditandoId = null;
    document.getElementById("btnGuardar").textContent = "Guardar";
    cargarMascotas();
}

async function eliminarMascota(id) {
    if (!confirm("¿Seguro que deseas eliminar esta mascota?")) return;

    try {
        await fetch(`${API_URL}/Mascota/${id}`, {
            method: "DELETE"
        });

        mostrarMensaje("Mascota eliminada correctamente", "success");
        cargarMascotas();
    } catch {
        mostrarMensaje("Error al eliminar mascota", "danger");
    }
}


// HELPERS

function mostrarMensaje(texto, tipo) {
    document.getElementById("mensaje").innerHTML =
        `<div class="alert alert-${tipo} mt-3">${texto}</div>`;
}

function limpiarFormulario() {
    ["nombre", "raza", "sexo", "fechaNacimiento"].forEach(id => {
        document.getElementById(id).value = "";
    });
    document.getElementById("especie").value = "";
    document.getElementById("duenoId").value = "";
}

function verPerfil(mascotaId) {
    window.location.href = `index.html?mascotaId=${mascotaId}`;
}
