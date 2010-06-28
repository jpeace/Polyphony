(function($) {
    $.widget("ui.keypad", {
        _init: function() {
            var self = this;
            var ele = $(this.element);
            var options = this.options;

            // add keys to dom
            ele.html('<table class="ui-timepicker">' +
                '<tbody>' +
                    '<tr>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">7</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">8</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">9</a></td>' +
                    '</tr>' +
                    '<tr>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">4</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">5</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">6</a></td>' +
                    '</tr>' +
                    '<tr>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">1</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">2</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">3</a></td>' +
                    '</tr>' +
                    '<tr>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">C</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">0</a></td>' +
                        '<td><a class="ui-state-default ui-state-active" href="#">R</a></td>' +
                    '</tr>' +
                '</tbody>' +
            '</table>');

            // set up events
            ele.find('a.ui-state-default').click(function() {
                var field = options.field;
                var value = $(this).text();
                if (options.debug) { console.log(value + " " + field.val()); }
                if (value == 'C') {
                    field.val('');
                } else if (value == 'R') {
                    field.val(options.resetValue);
                } else {
                    var currentValue = field.val();
                    if (currentValue.length > 4 || (currentValue.length == 0 && value != 0 && value != 1 && value != 2)) {
                        return false;
                    } else if (currentValue.length == 2) {
                        if (value > 5) {
                            return false;
                        }
                        currentValue += ':';
                    }
                    field.val(currentValue + value);
                }
                return;
            });
        },
        refresh: function() {
            this._checkForUpdates();
        }
    });
    $.extend($.ui.keypad, {
        version: "0.1",
        defaults: {
            field: '',
            resetValue: '',
            debug: false
        }
    });
})(jQuery);