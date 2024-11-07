
function setStoreValue(keyName, keyValue){
    localStorage.setItem(keyName, keyValue);
}

function getStoreValue(keyName) {
    return localStorage.getItem(keyName);
}

function removeStoreValue(keyName){
    localStorage.removeItem(keyName);
}
