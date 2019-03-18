import http from 'Support/Http';

function save(payload) {
  return http.post('/livro', payload);
}

function remove({ id }) {
  return http.delete(`/livro/${id}`);
}

function update(id, payload) {
  return http.put(`/livro/${id}`, payload);
}

function findAll() {
  return http.get('/livros');
}

function get(id) {
  return http.get(`/livro/${id}`);
}

export {
  save,
  findAll,
  remove,
  update,
  get,
};
