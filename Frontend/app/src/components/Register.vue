<template>
  <div class="item">
    <h1>New account</h1>
    <div>Username</div>
    <input class="input_bar" v-model="username" />
    <div>Full name</div>
    <input class="input_bar" v-model="fullName" />
    <div class="button" @click="setAccount">Submit</div>
  </div>
</template>

<script>
import {addAccount} from '@/apis/'

export default {
  name: 'RegisterComponent',
  data(){
    return{
      username:"",
      fullName:""
    }
    
  },
  methods:{
    setAccount:function(){
      addAccount({partitionKey:this.username,rowKey:this.fullName,timestamp:Date.now,username:this.username,fullName:this.fullName})
      .then(res=>{
        console.log(res)
      })
    }
  }


}
</script>

<style scoped>
.item{
    max-width:300px;
    margin: 5px auto;
    padding:5px;
    border:1px solid #696969;
    border-radius: 5px;
}
.input_bar{
    width:90%;
    margin:5px auto;
}

.button{
    width:90%;
    cursor:pointer;
    margin:5px auto;
    background-color: #33b5e5;
    border-radius: 5px;
    color:#fff;
    padding:5px;
}
</style>
