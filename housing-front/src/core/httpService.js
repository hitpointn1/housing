const baseUrl = 'https://localhost:44387/api/';

const get = (url = '') => fetch(baseUrl + url, { method: 'GET' }).then(r => r.json());
const post = (url = '', data = {}) => fetch(baseUrl + url, { method: 'POST', body: JSON.stringify(data) }).then(r => r.json());

export const httpService = {
  get,
  post
};
