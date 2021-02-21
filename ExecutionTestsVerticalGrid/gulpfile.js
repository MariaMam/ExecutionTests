/// <binding ProjectOpened='scss:watch' />
let gulp = require('gulp'),
    sass = require('gulp-sass'),
    sourcemaps = require('gulp-sourcemaps');

let scssSourcePath = 'Content/**/*.scss';
let cssTargetPath = 'Content';

let sassCompilerOptions = {
    outputStyle : "expanded",
}

gulp.task('scss', function() {
    gulp.src(scssSourcePath)
        .pipe(sourcemaps.init())
        .pipe(sass(sassCompilerOptions)
            .on('error', sass.logError)
        )
        .pipe(sourcemaps.write())
        .pipe(gulp.dest(cssTargetPath))
});

gulp.task('scss:watch', function() {
    gulp.watch(scssSourcePath, ['scss']);
});