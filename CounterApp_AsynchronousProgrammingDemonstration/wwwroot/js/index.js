$(document).ready(function () {
    OnClickAsyncIncrement();
    OnClickSyncIncrement();
    OnClickDisplaySomething();
});

function OnClickAsyncIncrement() {
    $('#btnAsyncIncrement').on('click', function () {
        var requestUrl = '/Home/AsynchronousIncrement';
        fetch(requestUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(responsePromise => {
                if (!responsePromise.ok) {
                    console.error('/Home/AsynchronousIncrement http endpoint returned unsuccessful response');
                } else {
                    return responsePromise.json();
                }
            })
            .then(response => {
                $('#textCounterValue').html(response.counterValue);
            })
            .catch(error => {
                console.error(`Error occured: ${error}`);
            })
    });
}

function OnClickSyncIncrement() {
    $('#btnSyncIncrement').on('click', function () {
        var requestUrl = '/Home/SynchronousIncrement';
        fetch(requestUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(responsePromise => {
                if (!responsePromise.ok) {
                    console.error('Home/SynchronousIncrement http endpoint returned unsuccessful response');
                } else {
                    return responsePromise.json();
                }
            })
            .then(response => {
                $('#textCounterValue').html(response.counterValue);
            })
            .catch(error => {
                console.error(`Error occured: ${error}`);
            })
    });
}

function OnClickDisplaySomething() {
    $('#btnDisplaySomething').on('click', function () {
        var requestUrl = '/Home/DisplaySomething';
        fetch(requestUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(responsePromise => {
                if (!responsePromise.ok) {
                    console.error('/Home/DisplaySomething http endpoint returned unsuccessful response');
                } else {
                    return responsePromise.json();
                }
            })
            .then(response => {
                $('#textSomething').html(`${response.displaySomethingText}`);
            })
            .catch(error => {
                console.error(`Error occured: ${error}`)
            });
    });
}