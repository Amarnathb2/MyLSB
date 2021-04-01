/// <binding AfterBuild='after-build' ProjectOpened='project-opened' />

'use strict';

var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var cleanCss = require('gulp-clean-css');
var sass = require('gulp-sass');
var filter = require('gulp-filter');
var autoprefixer = require('gulp-autoprefixer');
var sourcemaps = require('gulp-sourcemaps');

sass.compiler = require('node-sass');

var sassPaths = [
    'wwwroot/lib/bootstrap-sass/**/*.scss',
    'wwwroot/scss/**/*.scss'
];

var jsPaths = [
    'wwwroot/lib/jquery/jquery.js',
    'wwwroot/lib/popper.js/umd/popper.js',
    'wwwroot/lib/twitter-bootstrap/js/bootstrap.js',
    'wwwroot/lib/waypoints/jquery.waypoints.js',
    'wwwroot/lib/flickity/flickity.pkgd.js',
    'wwwroot/lib/odometer.js/odometer.js',
    'wwwroot/scripts/rotaterator.js',
    'wwwroot/scripts/ZAGFramework-plugins-before.js',
    'wwwroot/scripts/base.js',    
    'wwwroot/scripts/cookies.js',
    'wwwroot/scripts/components/*.js',
    'wwwroot/scripts/ZAGFramework-plugins-after.js',
];

gulp.task('watch', done => {
    gulp.watch(jsPaths, gulp.parallel('pack-js'));
    gulp.watch(sassPaths, gulp.parallel('sass'));
    done();
});

gulp.task('sass', done => {
    gulp.src(sassPaths)
        .pipe(filter(['**', '!**/_*.scss']))
        .pipe(sourcemaps.init())
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer({
            cascade: false
        }))
        .pipe(cleanCss())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/assets'));
    done();
});

gulp.task('pack-js', done => {
    gulp.src(jsPaths)
        .pipe(concat('base.js'))
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/assets'));
    done();
});

gulp.task('project-opened', gulp.series('watch'));
gulp.task('after-build', gulp.parallel('sass', 'pack-js'));