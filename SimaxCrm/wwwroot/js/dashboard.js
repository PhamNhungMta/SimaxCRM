function openLeadPage(page) {
    window.location.href = "/admin/view/leads/" + page.toLowerCase()
}

function openInvoicePage(status) {
    window.location.href = "/admin/invoice/index?leadid=0&orderstatus=" + status.toLowerCase()
}

function openProductPage(page) {
    window.location.href = "/admin/view/products/" + page.toLowerCase()
}

//var lineChart = new Chart($('#canvas-1'), {
//    type: 'line',
//    data: {
//        labels: canvas_label_1,
//        datasets: [{
//            label: 'Invoices Revenue',
//            backgroundColor: 'rgba(220, 220, 220, 0.2)',
//            borderColor: 'rgba(220, 220, 220, 1)',
//            pointBackgroundColor: 'rgba(220, 220, 220, 1)',
//            pointBorderColor: '#fff',
//            data: canvas_data_1
//        }]
//    },
//    options: {
//        responsive: true
//    }
//}); // eslint-disable-next-line no-unused-vars

var pieChart = new Chart($('#canvas-5'), {
    type: 'pie',
    data: {
        labels: canvas_label_2,
        datasets: [{
            data: canvas_data_2,
            backgroundColor: ['#c40062', '#f8cb00', '#c8ced3', '#6f42c1', '#4dbd74', '#0dd9d9'],
            hoverBackgroundColor: ['#c40062', '#f8cb00', '#c8ced3', '#6f42c1', '#4dbd74', '#0dd9d9']
        }]
    },
    options: {
        responsive: true
    }
}); // eslint-disable-next-line no-unused-vars

var pieChart_product = new Chart($('#canvas-5-product'), {
    type: 'pie',
    data: {
        labels: canvas_label_3,
        datasets: [{
            data: canvas_data_3,
            backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#c40062', '#379457', '#0dd9d9'],
            hoverBackgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#c40062', '#379457', '#0dd9d9']
        }]
    },
    options: {
        responsive: true
    }
}); // eslint-disable-next-line no-unused-vars


function generateCalender(cal_data, div) {
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();


    $('#external-events div.external-event').each(function () {
        var eventObject = {
            title: $.trim($(this).text()) // use the element's text as the event title
        };

        $(this).data('eventObject', eventObject);

        $(this).draggable({
            zIndex: 999,
            revert: true,      // will cause the event to go back to its
            revertDuration: 0  //  original position after the drag
        });

    });


    /* initialize the calendar
    -----------------------------------------------------------------*/

    var calendar = $(div).fullCalendar({
        header: {
            //left: 'title',
            //center: '',
            //right: 'prev,next today'

            left: 'prev,next today',
            center: '',
            right: 'month,agendaWeek,agendaDay,list'

        },
        allDayDefault: false,

        editable: false,
        firstDay: 1, //  1(Monday) this can be changed to 0(Sunday) for the USA system
        selectable: true,
        defaultView: 'month',
        //contentHeight: 1300,

        axisFormat: 'h:mm',
        columnFormat: {
            month: 'ddd',    // Mon
            week: 'ddd d', // Mon 7
            day: 'dddd M/d',  // Monday 9/7
            agendaDay: 'dddd d'
        },
        titleFormat: {
            month: 'MMMM yyyy', // September 2009
            week: "MMMM yyyy", // September 2009
            day: 'MMMM yyyy'                  // Tuesday, Sep 8, 2009
        },
        allDaySlot: false,
        selectHelper: true,
        select: function (start, end, allDay) {
            //debugger;
            //var title = prompt('Event Title:');
            //if (title) {
            //    calendar.fullCalendar('renderEvent',
            //        {
            //            title: title,
            //            start: start,
            //            end: end,
            //            allDay: allDay
            //        },
            //        true // make the event "stick"
            //    );
            //}
            //calendar.fullCalendar('unselect');
        },
        eventClick: function (info) {
            //if (confirm("Do you want to open this?")) {
                if (info.title.indexOf("Lead") != -1) {
                    window.location.href = "/admin/view/lead/" + info.id;
                }
                else if (info.title.indexOf("Inventory") != -1) {
                    window.location.href = "/admin/view/product/" + info.id;
                }
            //}


            //alert('Event: ' + info.event.title);
            //alert('Coordinates: ' + info.jsEvent.pageX + ',' + info.jsEvent.pageY);
            //alert('View: ' + info.view.type);

            // change the border color just for fun
            //info.el.style.borderColor = 'red';
        },
        droppable: false, // this allows things to be dropped onto the calendar !!!
        drop: function (date, allDay) { // this function is called when something is dropped

            // retrieve the dropped element's stored Event Object
            var originalEventObject = $(this).data('eventObject');

            // we need to copy it, so that multiple events don't have a reference to the same object
            var copiedEventObject = $.extend({}, originalEventObject);

            // assign it the date that was reported
            copiedEventObject.start = date;
            copiedEventObject.allDay = allDay;

            // render the event on the calendar
            // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
            $(div).fullCalendar('renderEvent', copiedEventObject, true);

            // is the "remove after drop" checkbox checked?
            if ($('#drop-remove').is(':checked')) {
                // if so, remove the element from the "Draggable Events" list
                $(this).remove();
            }

        },

        events: cal_data,
    });

}