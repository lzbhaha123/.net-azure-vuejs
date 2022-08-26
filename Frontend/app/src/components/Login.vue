<template>
  <div class="item">
    <h1>Login</h1>
    <div>Username</div>
    <input class="input_bar" v-model="username" />
    <div>Full name</div>
    <input class="input_bar" v-model="fullName" />
    <div class="button" @click="loginAccount">Login</div>
  </div>
</template>

<script>
import {getAccount} from '@/apis/'

export default {
  name: 'LoginComponent',
  data(){
    return{
      username:"",
      fullName:""
    }
    
  },
  methods:{
    loginAccount:function(){
      getAccount(this.username,this.fullName)
      .then(res=>{
        if(res.status == 200){
          res.json().then( val =>{
            if(val.username!=null){
              this.$emit("login",val)
            }
          })
        }else{
          alert("Login failed.")
        }
         
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

