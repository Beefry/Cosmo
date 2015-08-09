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
		.pipe(cssmin())
		.pipe(rename("style.min.css"))
		.pipe(gulp.dest('Content'));
});

gulp.task('default', function() {
	gulp.watch('Content/scss/**/*.scss',['sass']);
});