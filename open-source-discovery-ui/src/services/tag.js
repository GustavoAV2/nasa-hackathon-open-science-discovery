import {http} from '@/config'

export default{
    getTags(){
        return http.get('/tags')
    },
    getTagsByUserId(userId){
        return http.get('/users/' + userId + '/tags/')
    },
}