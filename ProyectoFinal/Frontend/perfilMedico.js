
const API_URL = "https://localhost:7098/api/PerfilMedico/";

async function buscarPerfil() {
    const id = document.getElementById("mascotaId").value;
    const mensaje = document.getElementById("mensaje");
    mensaje.innerHTML = "";

    if (!id) {
        mensaje.innerHTML = `<div class="alert alert-warning">Ingrese un ID válido</div>`;
        return;
    }

    try {
        const response = await fetch(API_URL + id);

        if (!response.ok) {
            throw new Error("Mascota no encontrada");
        }

        const data = await response.json();
        mostrarPerfil(data);

    } catch (error) {
        document.getElementById("perfil").style.display = "none";
        mensaje.innerHTML = `<div class="alert alert-danger">${error.message}</div>`;
    }
}

function mostrarPerfil(data) {
    document.getElementById("perfil").style.display = "block";

    const m = data.mascota;

    document.getElementById("datosMascota").innerHTML = `
        <p><strong>Nombre:</strong> ${m.mascota}</p>
        <p><strong>Especie:</strong> ${m.especie}</p>
        <p><strong>Raza:</strong> ${m.raza}</p>
        <p><strong>Sexo:</strong> ${m.sexo}</p>
        <hr>
        <p><strong>Dueño:</strong> ${m.dueno}</p>
        <p><strong>Teléfono:</strong> ${m.telefono}</p>
        <p><strong>Correo:</strong> ${m.correo}</p>
    `;

    const tabla = document.getElementById("tablaVacunas");
    tabla.innerHTML = "";

    data.vacunas.forEach(v => {
        tabla.innerHTML += `
            <tr>
                <td>${v.nombreVacuna}</td>
                <td>${v.fechaAplicada.split("T")[0]}</td>
                <td>${v.proximaFecha.split("T")[0]}</td>
                <td>${v.observaciones}</td>
            </tr>
        `;
    });
}

document.addEventListener("DOMContentLoaded", () => {
    const params = new URLSearchParams(window.location.search);
    const mascotaId = params.get("mascotaId");

    if (mascotaId) {
        document.getElementById("mascotaId").value = mascotaId;
        buscarPerfil();
    }
});
