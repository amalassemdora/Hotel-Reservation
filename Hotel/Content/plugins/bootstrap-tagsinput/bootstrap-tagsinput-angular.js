angular.module('bootstrap-tagsinput', [])
.directive('bootstrapTagsinput', [function() {

  function getItemProperty(scope, property) {
    if (!property)
      return undefined;

    if (angular.isFunction(scope.$parent[property]))
      return scope.$parent[property];

    return function(item) {
      return item[property];
    };
  }

  return {
    restrict: 'EA',
    scope: {
      Model: '=ngModel'
    },
    template: '<select multiple></select>',
    replace: false,
    link: function(scope, element, attrs) {
      $(function() {
        if (!angular.isArray(scope.Model))
          scope.Model = [];

        var select = $('select', element);
        var typeaheadSourceArray = attrs.typeaheadSource ? attrs.typeaheadSource.split('.') : null;
        var typeaheadSource = typeaheadSourceArray ?
            (typeaheadSourceArray.length > 1 ?
                scope.$parent[typeaheadSourceArray[0]][typeaheadSourceArray[1]]
                : scope.$parent[typeaheadSourceArray[0]])
            : null;

        select.tagsinput(scope.$parent[attrs.options || ''] || {
          typeahead : {
            source   : angular.isFunction(typeaheadSource) ? typeaheadSource : null
          },
          itemValue: getItemProperty(scope, attrs.itemvalue),
          itemText : getItemProperty(scope, attrs.itemtext),
          confirmKeys : getItemProperty(scope, attrs.confirmkeys) ? JSON.parse(attrs.confirmkeys) : [13],
          tagClass : angular.isFunction(scope.$parent[attrs.tagclass]) ? scope.$parent[attrs.tagclass] : function(item) { return attrs.tagclass; }
        });

        for (var i = 0; i < scope.Model.length; i++) {
          select.tagsinput('add', scope.Model[i]);
        }

        select.on('itemAdded', function(event) {
          if (scope.Model.indexOf(event.item) === -1)
            scope.Model.push(event.item);
        });

        select.on('itemRemoved', function(event) {
          var idx = scope.Model.indexOf(event.item);
          if (idx !== -1)
            scope.Model.splice(idx, 1);
        });

        // create a shallow copy of Model's current state, needed to determine
        // diff when Model changes
        var prev = scope.Model.slice();
        scope.$watch("Model", function() {
          var added = scope.Model.filter(function(i) {return prev.indexOf(i) === -1;}),
              removed = prev.filter(function(i) {return scope.Model.indexOf(i) === -1;}),
              i;

          prev = scope.Model.slice();

          // Remove tags no longer in binded Model
          for (i = 0; i < removed.length; i++) {
            select.tagsinput('remove', removed[i]);
          }

          // Refresh remaining tags
          select.tagsinput('refresh');

          // Add new items in Model as tags
          for (i = 0; i < added.length; i++) {
            select.tagsinput('add', added[i]);
          }
        }, true);
      });
    }
  };
}]);
