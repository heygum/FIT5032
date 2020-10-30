var events = [];
$(".events").each(function () {
    var name = $(".name", this).text().trim();
    var round = $(".round", this).text().trim();
    var time = $(".time", this).text().trim();
    var date = $(".date", this).text().trim();
    var event = {
        title: name,
        date: date
    };
    events.push(event);
});
$("#calendar").fullCalendar({
    eventOverlap: false,
    selectOverlap: false,
    defaultTimedEventDuration: "00:30:00",
    timezone: "local",
    allDaySlot: false,
    defaultView: 'agendaWeek',
    locale: 'au',
    events: events,
    dayClick: function (date, allDay, jsEvent, view) {
        var d = new Date(date);
        var m = moment(d).format("DD-MMM-YYYY,hh:mma");
        m = encodeURIComponent(m);
        var uri = "/MovePlans/Create?date=" + m;
        $(location).attr('href', uri);
    }
});