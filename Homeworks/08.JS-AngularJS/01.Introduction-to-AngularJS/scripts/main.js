require.config({
    baseUrl: 'scripts/',
    paths: {
        'angular': 'libs/angular.min',
        'jquery': 'libs/jquery-2.1.1.min',
        'bootstrap': 'libs/bootstrap.min'
    },
    shim: {
        'bootstrap': ['jquery']
    }
});

require(['angular'], function () {

    var app = angular.module('app', [])
        .controller('Students', function ($scope) {
            var students = [
                {
                    'name': 'Pesho',
                    'photo': 'http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png',
                    'grade': 5,
                    'school': 'High School of Mathematics',
                    'teacher': 'Gichka Pesheva'
                },
                {
                    'name': 'Gosho',
                    'photo': 'http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png',
                    'grade': 6,
                    'school': 'High School of Biology',
                    'teacher': 'Bocho Bochev'
                }
            ];
            students.data = ['Name', 'Photo', 'Grade', 'School', 'Teacher'];

            $scope.students = students;
        })
        .controller('Tigers', ['$scope', function ($scope) {
            var tigers = [
                {
                    'Name': 'Pesho',
                    'Born': 'Asia',
                    'BirthDate': 2006,
                    'Live': 'Sofia Zoo',
                    'PictureUrl': 'images/tiger.jpg'
                },
                {
                    'Name': 'Gosho',
                    'Born': 'Africa',
                    'BirthDate': 2012,
                    'Live': 'Lovech Zoo',
                    'PictureUrl': 'images/tiger-2.jpg'
                }
            ];

            tigers.sectionStyles = {
                backgroundColor: '#cacaca',
                margin: '20px',
                padding: '30px',
                width: '700px',
                height: '260px'
            };

            tigers.headerStyles = {
                textAlign: 'center',
                fontSize: '1.5em',
                fontWeight: 'bold'
            };

            tigers.divStyles = {
                width: '50%',
                float: 'left',
                fontSize: '1.5em'
            };

            tigers.imgStyles = {
                width: '250px',
                float: 'right'
            };

            $scope.tigers = tigers;
        }]);
});

require(['bootstrap'], function () {
    $(function () {
        $('#test').click(function () {
            $(this).focus();
            $(this).select();
        });
    });
});