const updateAuthorModal = document.getElementById("updateAuthorModal");
const deleteAuthorButton = document.getElementById("deleteAuthorButton");
const closeUpdateAuthorButton = document.getElementById("closeUpdateButton");
const createAuthorModal = document.getElementById("createAuthorModal");
const openCreateAuthorModal = document.getElementById("openCreateAuthorModal");
const createAuthorForm = document.getElementById("createAuthorForm");
const closeCreateAuthorButton = document.getElementById("closeCreateButton");

let selectedAuthorId = null;

closeUpdateAuthorButton.addEventListener("click", () => {
    updateAuthorModal.close();
});

openCreateAuthorModal.addEventListener("click", () => {
    createAuthorModal.showModal();
});

createAuthorForm.addEventListener("submit", () => {
    document.getElementsByClassName("form__input").forEach((item) => item.value = "")
});

closeCreateAuthorButton.addEventListener("click", () => {
    createAuthorModal.close();
});

deleteAuthorButton.addEventListener("click", () => {
    deleteAuthor();
});

function openUpdateModal(modalId, authorId) {

    selectedAuthorId = authorId;

    loadAuthorData(authorId);

    document.getElementById('deleteAuthorId').value = selectedAuthorId;
    document.getElementById(modalId).showModal();
}

function deleteAuthor() {
    document.getElementById('deleteForm').submit();
}

function loadAuthorData(authorId) {
    fetch(`/Author/${authorId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log(data);
            document.getElementById('updateAuthorId').value = data.id;
            document.getElementById('updateAuthorName').value = data.name || "";
            document.getElementById('updateAuthorDescription').value = data.description || "";

            const booksSelect = document.getElementById('updateAuthorBooks');
            if (booksSelect && data.booksId && Array.isArray(data.booksId)) {
                Array.from(booksSelect.options).forEach(option => {
                    option.selected = false;
                });
                console.log("Yes");
                data.booksId.forEach(bookId => {
                    console.log("sa");
                    const option = booksSelect.querySelector(`option[value="${bookId}"]`);
                    if (option) {
                        option.selected = true;
                    }
                });
            }
        })
}