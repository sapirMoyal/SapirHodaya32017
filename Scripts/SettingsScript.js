function save() {
    var idR = $('#rows').val();
    
    var idC = $('#cols').val();
    // Store
    localStorage.rows = idR;    localStorage.cols = idC;    idA = $("#selectAlg").val()    localStorage.alg = idA;
}