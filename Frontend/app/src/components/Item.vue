<template>

<div v-bind:class="[item.isDone ? 'done' : '' ]" class="item"><p>{{item.context}}</p>
    <div class="buttons" v-if="!item.isDone">
        <div @click="deleteItem">Delete</div>
        <div @click="finishItem">Done</div>
    </div>
</div>

</template>

<script>
import{updateItem,deleteItem} from "@/apis/" 
export default{
    name:"ItemComponent",
    props:{
        item:{}
    },
    methods:{
        deleteItem:function(){
            deleteItem(this.item).then(res=>{
                if(res.status == 200){
                    res.json().then(val=>{
                        this.$emit("updateView",val)
                    })
                }
            })
        },
        finishItem:function(){
            var newItem = Object.assign({}, this.item);
            
            newItem.isDone = true
            updateItem(newItem).then(res=>{
                if(res.status == 200){
                    res.json().then(val=>{
                       
                        this.$emit("updateView",val)
                    })
                }
            })
        }
    }
}
</script>

<style scoped>
.done{
    background-color:#cdcdcd;
}
.item{
    max-width:300px;
    margin: 5px auto;
    padding:5px;
    border:1px solid #696969;
    border-radius: 5px;
}
.buttons{
    display:flex;
}
.buttons > div{
    flex-grow: 1;
    cursor:pointer;
    margin:0 2px;
    background-color: #33b5e5;
    border-radius: 5px;
    color:#fff;
    padding:5px;
}
</style>


