import axios from 'axios';
import { baseUrl } from '../constants.json';


const getAllProducts = () => new Promise((resolve, reject) => {
  axios.get(`${baseUrl}/products`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const getTwentyProducts = () => new Promise((resolve, reject) => {
  axios.get(`${baseUrl}/products/Top`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const getThreeProducts = () => new Promise((resolve, reject) => {
  axios.get(`${baseUrl}/products/TopThree`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

export default { getAllProducts, getThreeProducts, getTwentyProducts };

const getSingleProduct = (id) => axios.get(`${baseUrl}/products/${id}`);

export default { getSingleProduct };

