function addAccount(data){
    return fetch("https://localhost:7121/api/Account",{
        method:"post",
        headers:{
            "Content-Type":"application/json"
        },
        body:JSON.stringify(data)
    })

}

function getAccount(username,fullname){
    return fetch("https://localhost:7121/api/Account/"+username+"/"+fullname)
}

function addItem(data){
    return fetch("https://localhost:7121/api/ToDoItem",{
        method:"post",
        headers:{
            "Content-Type":"application/json"
        },
        body:JSON.stringify(data)
    })

}

function getItems(username){
    return fetch("https://localhost:7121/api/ToDoItem/"+username)
}

function updateItem(data){
    return fetch("https://localhost:7121/api/ToDoItem",{
        method:"put",
        headers:{
            "Content-Type":"application/json"
        },
        body:JSON.stringify(data)
    })

}

function deleteItem(data){
    return fetch("https://localhost:7121/api/ToDoItem",{
        method:"delete",
        headers:{
            "Content-Type":"application/json"
        },
        body:JSON.stringify(data)
    })

}


export {addAccount,getAccount,addItem ,getItems,deleteItem,updateItem}