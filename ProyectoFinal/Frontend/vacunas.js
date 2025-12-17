const API_URL = "https://localhost:7098/api";

async function guardarVacuna() {

    const vacuna = {
        mascotaId: document.getElementById("mascotaId").value,
        nombreVacuna: document.getElementById("nombreVacuna").value.trim(),
        fechaAplicada: document.getElementById("fechaAplicada").value,
        proximaFecha: document.getElementById("proximaFecha").value,
        observaciones: document.getElementById("observaciones").value.trim()
    };

    
    // VALIDACIONES

    if (!vacuna.mascotaId || !vacuna.nombreVacuna || !vacuna.fechaAplicada) {
        mostrarMensaje("Complete los campos obligatorios", "warning");
        return;
    }

    try {
        const res = await fetch(`${API_URL}/Vacuna`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(vacuna)
        });

        if (res.ok) {
            mostrarMensaje("Vacuna registrada correctamente", "success");
            limpiarFormulario();
        } else {
            const error = await res.text();
            mostrarMensaje(error || "Error al registrar vacuna", "danger");
        }

    } catch (error) {
        mostrarMensaje("No se pudo conectar con la API", "danger");
        console.error(error);
    }
}


// HELPERS

function mostrarMensaje(texto, tipo) {
    document.getElementById("mensaje").innerHTML =
        `<div class="alert alert-${tipo} mt-3">${texto}</div>`;
}

function limpiarFormulario() {
    document.getElementById("nombreVacuna").value = "";
    document.getElementById("fechaAplicada").value = "";
    document.getElementById("proximaFecha").value = "";
    document.getElementById("observaciones").value = "";
}
