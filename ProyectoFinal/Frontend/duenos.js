
// CONFIG

const tabla = document.getElementById("tablaDuenos");
const mensaje = document.getElementById("mensaje");
const btnGuardar = document.getElementById("btnGuardar");


// INIT

document.addEventListener("DOMContentLoaded", () => {
    btnGuardar.addEventListener("click", guardarDueno);
    cargarDuenos();
});


// CARGAR DUEÑOS

async function cargarDuenos() {
    try {
        const duenos = await apiGet("/Dueno");
        pintarDuenos(duenos);
    } catch (error) {
        mostrarMensaje("Error al cargar dueños", true);
        console.error(error);
    }
}

// PINTAR TABLA

function pintarDuenos(duenos) {
    tabla.innerHTML = "";

    duenos.forEach(d => {
        tabla.innerHTML += `
            <tr>
                <td>${d.nombre}</td>
                <td>${d.telefono}</td>
                <td>${d.correo}</td>
                <td>
                    <button class="btn btn-warning btn-sm"
                        onclick='editarDueno(${JSON.stringify(d)})'>
                        Editar
                    </button>
                </td>
            </tr>
        `;
    });
}


// GUARDAR / ACTUALIZAR

async function guardarDueno() {
    const duenoId = document.getElementById("duenoId").value;
    const nombre = document.getElementById("nombre").value.trim();
    const telefono = document.getElementById("telefono").value.trim();
    const correo = document.getElementById("correo").value.trim();

    // VALIDACIONES
    if (!nombre || !telefono || !correo) {
        mostrarMensaje("Todos los campos son obligatorios", true);
        return;
    }

    try {
        if (duenoId) {
            // 🔄 UPDATE
            await apiPut(`/Dueno/${duenoId}`, {
                duenoId,
                nombre,
                telefono,
                correo
            });
            mostrarMensaje("Dueño actualizado correctamente");
        } else {
            // ➕ INSERT
            await apiPost("/Dueno", {
                nombre,
                telefono,
                correo
            });
            mostrarMensaje("Dueño registrado correctamente");
        }

        limpiarFormulario();
        cargarDuenos();

    } catch (error) {
        mostrarMensaje("Error al guardar dueño", true);
        console.error(error);
    }
}


// EDITAR

function editarDueno(dueno) {
    document.getElementById("duenoId").value = dueno.duenoId;
    document.getElementById("nombre").value = dueno.nombre;
    document.getElementById("telefono").value = dueno.telefono;
    document.getElementById("correo").value = dueno.correo;

    btnGuardar.textContent = "Actualizar";
}


// HELPERS

function limpiarFormulario() {
    document.getElementById("duenoId").value = "";
    document.getElementById("nombre").value = "";
    document.getElementById("telefono").value = "";
    document.getElementById("correo").value = "";

    btnGuardar.textContent = "Guardar";
}

function mostrarMensaje(texto, error = false) {
    mensaje.textContent = texto;
    mensaje.className = error ? "alert alert-danger mt-3" : "alert alert-success mt-3";
}
