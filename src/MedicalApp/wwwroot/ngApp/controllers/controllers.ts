namespace MedicalApp.Controllers {

    export class BasicListController {
        public daysOfExpense;
        public totalCategories;
        public totalExpenses;

        constructor(private expense: MedicalApp.Services.ExpenseService) {
            expense.expenses.then((response) => {
                this.daysOfExpense = response.data;
            });
            console.log(this.daysOfExpense);
        }
    };

    export class HomeController {
        public message = 'Hello from the home page!';
    }

    export class AddExpenseController {
        public categories;
        public newExpense: any;
        public errors;

        constructor(private expense: MedicalApp.Services.ExpenseService,
            private $http: ng.IHttpService,
            private $state: ng.ui.IStateService,
            private $filter: ng.IFilterService) {
            this.newExpense = { apptDate: new Date() };
            //this.newExpense = { apptDate: $filter('date')(new Date(), 'MM/dd/yyyy') };
            $http.get('/api/categories')
                .then((response) => {
                    this.categories = response.data;
                });
        }


        public addExpense() {
            this.expense.addExpense(this.newExpense)
                .then((response) => {
                    this.$state.go("list");
                })
                .catch((reason) => {
                    this.errors = reason.data;
                });
            //this.$state.go("list");
            console.log(this.newExpense);
        }
    }

    export class DetailListController {
        public theExpense;
        constructor(private expense: MedicalApp.Services.ExpenseService, private $stateParams) {
            expense.getSingleExpense($stateParams['id']).then((response) => {
                this.theExpense = response.data;
            });

            console.log(this.theExpense);
        }
    }

}
