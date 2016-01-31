angular.module('bookEditApp').directive('customDropdown', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs, ctrl) {
            element.find('#' + attrs.customDropdownButton).click(function (ev) {
                element.find(".dropdown-menu").show();
                    return false;
                });
            element.find("." + attrs.dropdownThemeItem).click(function (ev) {
                var listItem = $(ev.target).attr("item-category");
                scope[attrs.dropdownAction](listItem);
                element.find(".dropdown-menu").hide();
                    return false;
            });

            $(document).mouseup(function (e) {
                var container = element.find(".dropdown-menu");
                if (!container.is(e.target) && container.has(e.target).length === 0) {
                    container.hide();
                }
            })
        }
    };
});