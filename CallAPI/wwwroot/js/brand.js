console.log("brand.js LOADED");

const API_URL = 'https://localhost:7113/api/brands';

$(document).ready(function () {
    loadBrands();

    // Xử lý submit form tạo brand
    $('#addBrandForm').on('submit', function (e) {
        e.preventDefault();
        saveBrand();
    });
});

// ==================== LOAD BRANDS ====================
function loadBrands() {
    $('#brandList').html('<p>Đang tải dữ liệu...</p>');

    $.ajax({
        url: API_URL,
        type: 'GET',
        dataType: 'json',
        success: function (brands) {
            displayBrands(brands);
        },
        error: function () {
            $('#brandList').html('<p>Lỗi khi tải dữ liệu</p>');
        }
    });
}

// ==================== DISPLAY BRANDS ====================
function displayBrands(brands) {
    if (!brands || brands.length === 0) {
        $('#brandList').html('<p>Chưa có hãng xe nào</p>');
        return;
    }

    let html = '<h2>Danh sách hãng xe</h2>';

    brands.forEach(brand => {
        html += `
            <div class="brand-card" id="brand-${brand.id}">
                <h3>${brand.name}</h3>
                ${renderCars(brand.cars)}
                <button class="btn btn-primary" onclick="editBrand(${brand.id})">Sửa</button>
                <button class="btn btn-danger" onclick="deleteBrand(${brand.id})">Xóa</button>
            </div>
        `;
    });

    $('#brandList').html(html);
}

// ==================== RENDER CARS ====================
function renderCars(cars) {
    if (!cars || cars.length === 0) {
        return '<p>Không có xe</p>';
    }

    let html = '<ul>';
    cars.forEach(car => {
        html += `<li><strong>${car.name}</strong> - Giá: ${formatPrice(car.price)}</li>`;
    });
    html += '</ul>';

    return html;
}

// ==================== SAVE BRAND ====================
function saveBrand() {
    const brandId = $('#brandId').val();
    const brandData = {
        name: $('#brandName').val()
    };

    if (!brandData.name) {
        showNotification('Vui lòng nhập tên hãng', 'error');
        return;
    }

    if (brandId) {
        updateBrand(brandId, brandData);
    } else {
        createBrand(brandData);
    }
}

// ==================== CREATE BRAND ====================
function createBrand(brandData) {
    $.ajax({
        url: API_URL,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(brandData),
        success: function (response, status, xhr) {
            if (xhr.status === 201) {
                showNotification('Tạo hãng xe thành công!', 'success');
                resetForm();
                loadBrands();
            }
        },
        error: function (xhr) {
            handleAjaxError(xhr, 'Lỗi khi tạo hãng xe');
        }
    });
}

// ==================== EDIT BRAND ====================
function editBrand(id) {
    $.ajax({
        url: `${API_URL}/${id}`,
        type: 'GET',
        dataType: 'json',
        success: function (brand) {
            $('#brandId').val(brand.id);
            $('#brandName').val(brand.name);
            $('#brandForm h2').text('Cập nhật hãng xe');
            $('html, body').animate({ scrollTop: $('#brandForm').offset().top }, 500);
        },
        error: function (xhr) {
            handleAjaxError(xhr, 'Lỗi khi tải thông tin hãng xe');
        }
    });
}

// ==================== UPDATE BRAND ====================
function updateBrand(id, brandData) {
    $.ajax({
        url: `${API_URL}/${id}`,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(brandData),
        success: function (response, status, xhr) {
            if (xhr.status === 200 || xhr.status === 204) {
                showNotification('Cập nhật hãng xe thành công!', 'success');
                resetForm();
                loadBrands();
            }
        },
        error: function (xhr) {
            handleAjaxError(xhr, 'Lỗi khi cập nhật hãng xe');
        }
    });
}

// ==================== DELETE BRAND ====================
function deleteBrand(id) {
    if (!confirm('Bạn có chắc chắn muốn xóa hãng xe này?')) return;

    $.ajax({
        url: `${API_URL}/${id}`,
        type: 'DELETE',
        success: function (response, status, xhr) {
            if (xhr.status === 204) {
                showNotification('Xóa hãng xe thành công!', 'success');
                $(`#brand-${id}`).fadeOut(400, function () { $(this).remove(); });
            }
        },
        error: function (xhr) {
            handleAjaxError(xhr, 'Lỗi khi xóa hãng xe');
        }
    });
}

// ==================== HELPER FUNCTIONS ====================
function handleAjaxError(xhr, defaultMessage) {
    let message = defaultMessage;

    if (xhr.responseJSON && xhr.responseJSON.message) {
        message = xhr.responseJSON.message;
    } else if (xhr.status === 0) {
        message = 'Không thể kết nối đến server';
    }

    showNotification(message, 'error');
    console.error('Ajax Error:', xhr);
}

function showNotification(message, type) {
    const className = type === 'error' ? 'error' : 'success';
    $('#notification').html(`<div class="${className}">${message}</div>`);

    setTimeout(() => {
        $('#notification').fadeOut(400, function () { $(this).html('').show(); });
    }, 3000);
}

function resetForm() {
    $('#addBrandForm')[0].reset();
    $('#brandId').val('');
    $('#brandForm h2').text('Thêm hãng xe mới');
}

function formatPrice(price) {
    return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(price);
}
