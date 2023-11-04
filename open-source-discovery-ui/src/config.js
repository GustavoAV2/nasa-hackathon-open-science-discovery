import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://openscience-api.azurewebsites.net/api',

})
