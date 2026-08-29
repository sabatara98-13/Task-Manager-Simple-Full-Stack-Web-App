const BASE_URL = "http://localhost:5000/api/tasks";

async function loadTasks() {
    const res = await fetch(BASE_URL);
    const tasks = await res.json();
    const list = document.getElementById("task-list");
    list.innerHTML = "";

    tasks.forEach(task => {
        const li = document.createElement("li");
        li.className = task.isDone ? "task-item done" : "task-item";

        const checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        checkbox.checked = task.isDone;
        checkbox.addEventListener("change", () => toggleTask(task));

        const span = document.createElement("span");
        span.className = "task-title";
        span.textContent = `${task.title} (${task.priority})`;

        const btn = document.createElement("button");
        btn.textContent = "Delete";
        btn.className = "delete-btn";
        btn.addEventListener("click", () => deleteTask(task.id));

        li.appendChild(checkbox);
        li.appendChild(span);
        li.appendChild(btn);
        list.appendChild(li);
    });
}

const form = document.getElementById("add-form");
form.addEventListener("submit", async (event) => {
    event.preventDefault();

    const titleInput = document.getElementById("title");
    const prioritySelect = document.getElementById("priority");

    const newTask = {
        title: titleInput.value.trim(),
        priority: prioritySelect.value,
        isDone: false
    };

    await fetch(BASE_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(newTask)
    });

    form.reset();
    prioritySelect.value = "Medium";
    loadTasks();
});

async function toggleTask(task) {
    const updated = {
        id: task.id,
        title: task.title,
        priority: task.priority,
        isDone: !task.isDone
    };

    await fetch(`${BASE_URL}/${task.id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updated)
    });

    loadTasks();
}

async function deleteTask(id) {
    await fetch(`${BASE_URL}/${id}`, {
        method: "DELETE"
    });

    loadTasks();
}

loadTasks();
