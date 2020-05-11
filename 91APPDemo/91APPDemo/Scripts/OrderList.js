'use strict'

document.addEventListener("DOMContentLoaded", function (event) {
    document.getElementById('Confirmbtn').addEventListener('click', Confirm)
});

function Confirm() {
    let isNeedChangeId = [];
    const orderLists = document.getElementsByClassName('ordercol');
    for (const orderList of orderLists) {
        const isNeedChange = orderList.getElementsByClassName('orderNeedChange')[0].checked
        if (isNeedChange) {
            let orderId = orderList.getElementsByClassName('orderId')[0].textContent
            isNeedChangeId.push({ Id: orderId });
        }
    }

    let promises = [];
    isNeedChangeId.forEach(function (orderId) {
        promises.push(UpdateOrderList(orderId));
    })

    Promise.all(promises).then(function (res) {
        alert('OK');
    }).catch(function (err) {
        alert('Try Again')
    })
}

function UpdateOrderList(orderId) {
    return new Promise(function (resolve, reject) {
        fetch('/api/OrderList', {
            method: 'POST',
            body: JSON.stringify(orderId),
            headers: {
                'content-type': 'application/json'
            }
        }).then(function (res) {
            if (res.ok) {
                resolve('Ok')
            }
        }).catch(function (err) {
            reject(err);
        });
    })
}