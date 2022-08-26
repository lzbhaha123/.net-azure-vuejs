<template>
  <div v-if="!isLogin">
    <RegisterComponent v-if="!toLogin"/>
    <LoginComponent @login="getInfo" v-else/>
    <div class="long_button" @click="toLogin = !toLogin">{{showButtonText}}</div>
  </div>
  <div  v-else>
    <h3>{{info.fullName}}'s List</h3>
    <div v-for="(v,i) in list" v-bind:key="i">
      <ItemComponent @updateView="updateList" :item="v" />
    </div>
    <NewItemComponent @updateView="updateList" :user="info"></NewItemComponent>
  </div>
  
</template>

<script>
import RegisterComponent from './components/Register.vue'
import LoginComponent from './components/Login.vue'
import NewItemComponent from './components/NewItem.vue'
import ItemComponent from './components/Item.vue'
import {getItems} from '@/apis/'
export default {
  name: 'App',
  components: {
    RegisterComponent,LoginComponent,NewItemComponent,ItemComponent
  },
  data(){
    return{
      toLogin:true,
      isLogin:false,
      info:{},
      list:[]
    }
  },
  computed:{
    showButtonText(){
      return this.toLogin ? "To create account" : "To login"
    },
  },
  methods:{
    getInfo(val){
      this.info = val
      this.isLogin = true
      this.showList()
    },
    updateList:function(val){
      this.list = val
      this.$forceUpdate()
    },
    showList:function(){
      
      getItems(this.info.username).then(
        res => {
          res.json().then(val => {
            this.list = val
            this.$forceUpdate()
          })
          
        }
      )
    },
  }

}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.long_button{
    width:90%;
    cursor:pointer;
    margin:5px auto;
    background-color: #33b5e5;
    border-radius: 5px;
    color:#fff;
    padding:5px;
    max-width: 312px;
}
</style>
