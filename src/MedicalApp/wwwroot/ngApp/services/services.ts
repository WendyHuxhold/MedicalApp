namespace MedicalApp.Services {
    export class ExpenseService {

        public get expenses() {
            return this.$http.get('/api/expenses');
        }

        // private is an access modifier, and it is dependency injected
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
        }

        public getSingleExpense(id) {
            return this.$http.get(`/api/expenses/${id}`);
        }



        // inject http
        // $http.get....
        // this.expenses = reponse.data;

        //this.expenses = [
        //    {
        //        id: 1,
        //        firstName: "Wendy",
        //        lastName: "Huxhold",
        //        date: "1/12/2016",
        //        category: 'Medical',
        //        expense: 300.00,
        //        physician: "Dr. Smith",
        //        description: "knee x-rays"
        //    },
        //    {
        //        id: 2,
        //        firstName: "Wendy",
        //        lastName: "Huxhold",
        //        date: "2/20/2016",
        //        category: 'Chiropractic',
        //        expense: 30.00,
        //        physician: "Dr. Skidmmore",
        //        description: ""
        //    },
        //    {
        //        id: 3,
        //        firstName: "Wendy",
        //        lastName: "Huxhold",
        //        date: "3/10/2016",
        //        category: 'Chiropractic',
        //        expense: 30.00,
        //        physician: "Dr. Skidmmore",
        //        description: ""
        //    },

        //    {
        //        id: 4,
        //        firstName: "Larry",
        //        lastName: "Rameriz",
        //        date: "3/30/2016",
        //        category: 'Dental',
        //        expense: 188.00,
        //        physician: "Dr. Flanagan",
        //        description: "Annual Teeth Clean"
        //    },
        //    {
        //        id: 5,
        //        firstName: "Larry",
        //        lastName: "Rameriz",
        //        date: "4/15/2016",
        //        category: 'Optometry',
        //        expense: 75.00,
        //        physician: "Dr. Robinson",
        //        description: "Eye exam"
        //    },
        //    {
        //        id: 6,
        //        firstName: "Cindy",
        //        lastName: "Pilch",
        //        date: "4/28/2016",
        //        category: 'Physical Therapy',
        //        expense: 50.00,
        //        physician: "",
        //        description: ""
        //    },
        //];

        public addExpense(newExpense) {
            return this.$http.post('/api/expenses', newExpense);
                

            //this.expenses.push(newExpense);
            //newExpense.id = this.expenses.length;
            //console.log(this.expenses);
        }
    }

    angular.module('MedicalApp').service('expense', ExpenseService);
}

