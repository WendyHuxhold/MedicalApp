namespace MedicalApp {

    angular.module('MedicalApp', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: MedicalApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('add', {
                url: '/add',
                templateUrl: '/ngApp/views/addExpense.html',
                controller: MedicalApp.Controllers.AddExpenseController,
                controllerAs: 'controller'
            })
            .state('details', {
                url: '/details/:id',
                templateUrl: '/ngApp/views/listDetailExp.html',
                controller: MedicalApp.Controllers.DetailListController,
                controllerAs: 'controller'
            })
            .state('list', {
                url: '/list',
                templateUrl: '/ngApp/views/listExp.html',
                controller: MedicalApp.Controllers.BasicListController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    

}
