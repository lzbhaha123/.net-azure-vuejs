<template>
<div class="item">
    <div>Context</div>
    <input class="input_bar" v-model="context" />
    <div class="button" @click="createItem">Create new item</div>
    
    
</div>
</template>

<script>
import{addItem} from "@/apis/"
export default{
    name:"NewItemComponent",
    props:{
        user:{}
    },
    data(){
        return{
           context:"" 
        }
    },
    methods:{
        createItem:function(){
            addItem({partitionKey:this.user.partitionKey,rowKey:this.context,timestamp:Date.now,isDone:false,context:this.context}).
            then(res => {              
                if(res.status == 200){
                    res.json().then(val=>{
                        this.context = ""
                        this.$emit("updateView",val)
                    })
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


