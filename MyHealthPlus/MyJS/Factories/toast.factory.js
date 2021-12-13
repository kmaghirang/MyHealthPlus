function toastFactory() {
    var toast = {};

    toast.info = function (title, message) {
        iziToast.info({
            id: 'info',
            title: title,
            message: message,
            position: 'topRight',
            close: false,
            transitionIn: 'flipInX',
            transitionOut: 'flipOutX',
            titleSize: 30,
            messageSize: 20
        });
    };

    toast.error = function (title, message) {
        iziToast.error({
            id: 'error',
            title: title,
            message: message,
            position: 'topRight',
            close: false,
            transitionIn: 'flipInX',
            transitionOut: 'flipOutX',
            titleSize: 30,
            messageSize: 20
        });
    };

    toast.success = function (title, message) {
        iziToast.success({
            id: 'success',
            title: title,
            message: message,
            position: 'topRight',
            close: false,
            transitionIn: 'flipInX',
            transitionOut: 'flipOutX',
            titleSize: 30,
            messageSize: 20
        });
    };

    toast.warning = function (title, message) {
        iziToast.warning({
            id: 'warning',
            title: title,
            message: message,
            position: 'topRight',
            close: false,
            transitionIn: 'flipInX',
            transitionOut: 'flipOutX',
            titleSize: 30,
            messageSize: 20
        });
    };

    return toast;
}