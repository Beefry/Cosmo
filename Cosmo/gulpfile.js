var gulp = require('gulp');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
//var ugly = require('gulp-uglify');
var cssmin = require('gulp-cssmin');
var sourcemaps = require('gulp-sourcemaps');
var rename = require('gulp-rename');

gulp.task('sass', function() {
	return gulp.src('Content/scss/style.scss')
		.pipe(sourcemaps.init())
		.pipe(sass())
		.pipe(sourcemaps.write("maps"))
		.pipe(gulp.dest('Content'))
		.pipe(rename(function(path) {
			path.extname = ".min.css";
		}))
		.pipe(cssmin())
		.pipe(gulp.dest('Content/min'));
});

gulp.task('concat', function(){
	gulp.src([
		'App/js/angular.min.js',
		'App/js/angular-resource.min.js',
		'App/angularjs/sortable.js',
		'App/angularjs/main.js',
		'App/angularjs/Components/Models.js',
		'App/angularjs/GlobalFunctions.js',
		'App/angularjs/**/*Module.js',
		'App/angularjs/**/*Models.js',
		'App/angularjs/**/*Routes.js',
		'App/angularjs/**/*Services.js',
		'App/angularjs/**/*Directives.js',
		'App/angularjs/**/*Controllers.js',
	])
	.pipe(concat('app.js'))
	.pipe(gulp.dest('Scripts/'));
});

gulp.task('default', function() {
	gulp.watch('Content/scss/**/*.scss',['sass']);
	gulp.watch('App/angularjs/**/*.js',['concat']);
});