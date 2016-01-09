angular.module('bookEditApp').directive('customScroll', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs, ctrl) {
            
            function getNewHeight() {
                var newHeight = $(window).height() - heightDiff;
                if (newHeight < 100) newHeight = 100;
                return newHeight;
            }

            var heightDiff = attrs.customScroll;
            var inithght = getNewHeight();

            element.css({
                'overflow-y': 'auto',
                'max-height': inithght
            });

            $(window).resize(function () {
                
                var newhght = getNewHeight();

                element.css({
                    'max-height': newhght
                });
            });   
        }
    };
});