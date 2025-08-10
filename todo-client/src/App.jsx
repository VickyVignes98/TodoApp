import { useState, useEffect } from "react";
import "./App.css";

const API_URL = "https://localhost:7068/api/todo";

function App() {
  const [todos, setTodos] = useState([]);
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [editingId, setEditingId] = useState(null);

  useEffect(() => {
    fetchTodos();
  }, []);

  const fetchTodos = async () => {
    const res = await fetch(API_URL);
    const data = await res.json();
    setTodos(data);
  };

  const addTodo = async () => {
    if (!title.trim()) return;
    const newTodo = { title, description, isCompleted: false };
    await fetch(API_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newTodo),
    });
    setTitle("");
    setDescription("");
    fetchTodos();
  };

  const updateTodo = async (id) => {
    const todo = todos.find((t) => t.id === id);
    const updatedTodo = { ...todo, title, description };
    await fetch(`${API_URL}/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(updatedTodo),
    });
    setEditingId(null);
    setTitle("");
    setDescription("");
    fetchTodos();
  };

  const deleteTodo = async (id) => {
    await fetch(`${API_URL}/${id}`, { method: "DELETE" });
    fetchTodos();
  };

  return (
    <div className="app">
      <div className="container">
        <h1>Todo List</h1>

        <div className="input-group">
          <input
            type="text"
            placeholder="Title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />
          <input
            type="text"
            placeholder="Description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
          {editingId ? (
            <button className="btn update" onClick={() => updateTodo(editingId)}>
              Update
            </button>
          ) : (
            <button className="btn add" onClick={addTodo}>
              Add
            </button>
          )}
        </div>

        <ul className="todo-list">
          {todos.map((todo) => (
            <li key={todo.id} className="todo-item">
              <span>
                <strong>{todo.title}</strong> - {todo.description}
              </span>
              <div className="todo-actions">
                <button
                  className="btn edit"
                  onClick={() => {
                    setEditingId(todo.id);
                    setTitle(todo.title);
                    setDescription(todo.description);
                  }}
                >
                  Edit
                </button>
                <button
                  className="btn delete"
                  onClick={() => deleteTodo(todo.id)}
                >
                  Delete
                </button>
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default App;
