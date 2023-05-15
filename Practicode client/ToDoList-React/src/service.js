import axios from 'axios';

const apiUrl = "http://localhost:5196"

export default {
  getTasks: async () => {
    console.log("in getall");
    const result = await axios.get(`${apiUrl}/getAll`)    
    return result.data;
  },

  addTask: async(name1)=>{
    console.log('addTask', name1)
    //const result = await axios.post(`${apiUrl}/post`,{id:11,name:name1,isComplete:false});
   // return result.data;
     return {};
  },

  setCompleted: async(id, isComplete)=>{
    console.log('setCompleted', {id, isComplete})
   // const result = await axios.put(`${apiUrl}/update/${id}`,{id:id,name:"",isComplete:isComplete});
    return {};
  },

  deleteTask:async()=>{
    console.log('deleteTask')
  }
};
