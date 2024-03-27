const btnModal = document.getElementById("btnModal");
const btnClose = document.getElementById("btnClose");
const overlay = document.querySelector(".overlay");
const modal = document.querySelector(".modal");

let w = window.innerWidth;
let h = window.innerHeight;
let positionInfo;

const openModal = () => {

    modal.classList.remove("hidden");
    overlay.classList.remove("hidden");

    atualizarTamanhoWindowModal();
    modal.style.transform = `translate(${(w - positionInfo.width) / 2}px, ${(h - positionInfo.height) / 2}px`;
}

const closeModal = () => {
    modal.classList.add("hidden");
    overlay.classList.add("hidden");
}

btnModal.addEventListener("click", openModal);
btnClose.addEventListener("click", closeModal);



let isDragging = false;
let startX, startY, modalX, modalY;

modal.addEventListener("mousedown", mouseDown);
modal.addEventListener("mousemove", mouseMove);
modal.addEventListener("mouseup", mouseUp);

function mouseDown(e) {

    atualizarTamanhoWindowModal();

    isDragging = true;
    modal.style.cursor = "move";

    startX = e.clientX;
    startY = e.clientY;

    modalX = parseFloat(positionInfo.left);
    modalY = parseFloat(positionInfo.top);
}


function mouseMove(e) {

    if (!isDragging) return;

    let x = e.clientX;
    let y = e.clientY;

    let newX = modalX + x - startX;
    let newY = modalY + y - startY;

    if (newX >= 0 && newX <= (w - 500) && newY >= 0 && newY <= (h - 200)) {
        this.style.transform = `translate(${newX}px, ${newY}px)`
    }
}


function mouseUp() {

    isDragging = false;
    modal.style.cursor = "unset";
}


function atualizarTamanhoWindowModal() {
    positionInfo = modal.getBoundingClientRect();
    w = window.innerWidth;
    h = window.innerHeight;
}