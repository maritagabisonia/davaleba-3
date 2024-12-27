let currentPage = 1;
let pageSize = 10;
let currentSearch = '';
let currentSort = 'FirstName';
let currentOrder = 'asc';

// Load Students via AJAX
async function loadStudents() {
    currentSearch = document.getElementById('searchInput').value;

    const response = await fetch(`/Student/GetStudents?search=${currentSearch}&sort=${currentSort}&order=${currentOrder}&page=${currentPage}&pageSize=${pageSize}`);
    const data = await response.json();

    const tableBody = document.querySelector('#studentsTable tbody');
    tableBody.innerHTML = '';

    data.Students.forEach(student => {
        tableBody.innerHTML += `
            <tr>
                <td>${student.FirstName}</td>
                <td>${student.LastName}</td>
                <td>${new Date(student.BirthDate).toLocaleDateString()}</td>
            </tr>
        `;
    });

    document.getElementById('pageInfo').innerText = `Page ${data.CurrentPage} of ${Math.ceil(data.TotalItems / pageSize)}`;
}

// Sorting Function
function sortTable(column) {
    if (currentSort === column) {
        currentOrder = currentOrder === 'asc' ? 'desc' : 'asc';
    } else {
        currentSort = column;
        currentOrder = 'asc';
    }
    loadStudents();
}

// Pagination Functions
function prevPage() {
    if (currentPage > 1) {
        currentPage--;
        loadStudents();
    }
}

function nextPage() {
    currentPage++;
    loadStudents();
}

// Initial Load
loadStudents();
