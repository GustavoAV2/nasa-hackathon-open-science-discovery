import axios from 'axios'

export const http = axios.create({
    baseURL: 'http:///localhost:6001/api',

})
