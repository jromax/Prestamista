jQuery(document).ready(function () {
    //alert("xxx");
    //// Delete row in a table
    //jQuery('.delete-row').click(function () {
    //    var c = confirm("Continue delete?");
    //    if (c)
    //        jQuery(this).closest('tr').fadeOut(function () {
    //            jQuery(this).remove();
    //        });
    //    return false;
    //});
    //// Show aciton upon row hover
    //jQuery('.table tbody tr').hover(function () {
    //    jQuery(this).find('.table-action-hide a').animate({ opacity: 1 }, 100);
    //}, function () {
    //    jQuery(this).find('.table-action-hide a').animate({ opacity: 0 }, 100);
    //});

    $('#NavBar ul li a.selected').parent().addClass('selected');
    $('#NavBar ul li a.selected').removeClass('selected');
});

//$(function () {
//    var menu = $('#NavBar');

//    // Fixes for the aspMenu so that it will work with our bootstrap implementation
//    menu.find('ul')[0].style = ''; // clear the asp menu's inline styling
//    menu.find('ul')[0].className = menu[0].className; // The class name needs to be on the first ul element not the container div
//    menu.find('li.static').removeClass('static'); // remove the extraneous class


//    menu.find('li.has-popup').addClass('dropdown') //  add the dropdown class to the popup menus
//        .find('> ul').addClass('dropdown-menu').attr('style', 'display: none');  // add the appropriate class, and overwrite the extraneous inline styling

//    // No styling is required on the container div
//    menu[0].style = '';
//    menu[0].className = '';
//});