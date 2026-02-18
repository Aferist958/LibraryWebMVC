const updateBookModal = document.getElementById("updateBookModal");
const deleteBookButton = document.getElementById("deleteBookButton");
const issueBookButton = document.getElementById("issueBookButton");
const returnBookButton = document.getElementById("returnBookButton");
const closeUpdateBookButton = document.getElementById("closeUpdateButton");
const createBookModal = document.getElementById("createBookModal");
const openCreateBookModal = document.getElementById("openCreateBookModal");
const createBookForm = document.getElementById("createBookForm");
const closeCreateBookButton = document.getElementById("closeCreateButton");

let selectedBookId = null;

closeUpdateBookButton.addEventListener("click", () => {
    updateBookModal.close();
});

openCreateBookModal.addEventListener("click", () => {
    createBookModal.showModal();
});

createBookForm.addEventListener("submit", () => {
    document.getElementsByClassName("form__input").forEach((item) => item.value = "")
});

closeCreateBookButton.addEventListener("click", () => {
    createBookModal.close();
});

deleteBookButton.addEventListener("click", () => {
    document.getElementById('deleteForm').submit();
});

issueBookButton.addEventListener("click", () => {
    document.getElementById('issueForm').submit();
})

returnBookButton.addEventListener("click", () => {
    document.getElementById('returnForm').submit();
})

function openUpdateModal(modalId, bookId) {

    selectedBookId = bookId;

    loadBookData(bookId);

    document.getElementById('deleteBookId').value = selectedBookId;
    document.getElementById('issueBookId').value = selectedBookId;
    document.getElementById('returnBookId').value = selectedBookId;
    document.getElementById(modalId).showModal();
}

function loadBookData(bookId) {
    fetch(`/Book/${bookId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {

            document.getElementById('updateBookId').value = data.id;
            document.getElementById('updateBookTitle').value = data.title || "";
            document.getElementById('updateBookYear').value = data.yearOfPublication || "";
            document.getElementById('updateBookQuantity').value = data.quantity || "";

            const authorsSelect = document.getElementById('updateBookAuthors');
            if (authorsSelect && data.authorsId && Array.isArray(data.authorsId)) {
                Array.from(authorsSelect.options).forEach(option => {
                    option.selected = false;
                });
                data.authorsId.forEach(authorId => {
                    const option = authorsSelect.querySelector(`option[value="${authorId}"]`);
                    if (option) {
                        option.selected = true;
                    }
                });
            }
        })
}