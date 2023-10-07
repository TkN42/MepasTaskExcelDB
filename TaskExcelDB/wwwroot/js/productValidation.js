// productValidation.js

function validateForm() {
    var name = document.getElementById('name').value;
    var category_id = document.getElementById('category_id').value;
    var price = document.getElementById('price').value;
    var unit = document.getElementById('unit').value;
    var stock = document.getElementById('stock').value;
    var color = document.getElementById('color').value;
    var weight = document.getElementById('weight').value;
    var width = document.getElementById('width').value;
    var height = document.getElementById('height').value;

    if (!name || !category_id || !price || !unit || !stock || !color || !weight || !width || !height) {
        alert('Tüm alanları doldurun.');
        return false; // Form gönderme işlemi durdurulacak.
    }

    return true; // Form gönderme işlemi devam edecek.
}
