$(document).ready(() => {
    
})


const getView = (viewname, target) => {
    let url = `/${viewname}`;
    let ajaxConfig = {
        url: url,
        dataType: 'html',
        success: (response) => {
            $(target).html(response);
        }
    }

    $.ajax(ajaxConfig);
}



