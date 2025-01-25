'use strict'
var gulp = require('gulp');
var merge = require('merge-stream');
var concat = require('gulp-concat');
const del = require('del');

gulp.task('clean:vendors', function () {
    return del([
      './assets/vendors/**/*'
    ]);
});

/*Building vendor scripts needed for basic template rendering*/
gulp.task('buildBaseVendorScripts', function() {
    return gulp.src([
        '../node_modules/jquery/dist/jquery.min.js', 
        // '../node_modules/popper.js/dist/umd/popper.min.js',
        '../node_modules/bootstrap/dist/js/bootstrap.bundle.min.js', 
        '../node_modules/perfect-scrollbar/dist/perfect-scrollbar.min.js'
    ])
      .pipe(concat('vendor.bundle.base.js'))
      .pipe(gulp.dest('./assets/vendors/js'));
});

/*Building vendor styles needed for basic template rendering*/
gulp.task('buildBaseVendorStyles', function() {
    return gulp.src(['../node_modules/perfect-scrollbar/css/perfect-scrollbar.css'])
      .pipe(concat('vendor.bundle.base.css'))
      .pipe(gulp.dest('./assets/vendors/css'));
});

/*Scripts for addons*/
gulp.task('buildOptionalVendorScripts', function() {
    var aScript1 = gulp.src(['../node_modules/chart.js/dist/chart.umd.js'])
        .pipe(gulp.dest('./assets/vendors/chart.js'));
    var aScript39 = gulp.src(['../node_modules/select2/dist/js/select2.min.js'])
        .pipe(gulp.dest('./assets/vendors/select2'));
    var aScript46 = gulp.src(['../node_modules/bootstrap-maxlength/dist/bootstrap-maxlength.min.js'])
        .pipe(gulp.dest('./assets/vendors/bootstrap-maxlength'));
    var aScript33 = gulp.src(['../node_modules/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js'])
        .pipe(gulp.dest('./assets/vendors/bootstrap-datepicker'));
    var aScript5 = gulp.src(['../node_modules/moment/moment.js'])
        .pipe(gulp.dest('./assets/vendors/moment'));
    var aScript34 = gulp.src(['../node_modules/moment/min/moment.min.js'])
        .pipe(gulp.dest('./assets/vendors/moment'));
    var aScript71 = gulp.src(['../node_modules/daterangepicker/daterangepicker.js'])
        .pipe(gulp.dest('./assets/vendors/daterangepicker'));
    var aScript4 = gulp.src(['../node_modules/progressbar.js/dist/progressbar.min.js'])
        .pipe(gulp.dest('./assets/vendors/progressbar.js'));
    var aScript21 = gulp.src(['../node_modules/progressbar.js/dist/progressbar.min.js'])
        .pipe(gulp.dest('./assets/vendors/progressbar.js'));
    var aScript52 = gulp.src(['../node_modules/jvectormap/jquery-jvectormap.min.js'])
        .pipe(gulp.dest('./assets/vendors/jvectormap'));
    var aScript53 = gulp.src(['../node_modules/jvectormap/tests/assets/jquery-jvectormap-world-mill-en.js'])
        .pipe(gulp.dest('./assets/vendors/jvectormap'));
    var aScript54 = gulp.src(['../node_modules/jvectormap/tests/assets/jquery-jvectormap-world-mill-en.js'])
        .pipe(gulp.dest('./assets/vendors/jvectormap'));
    var aScript9 = gulp.src(['../node_modules/chartist/dist/chartist.min.js'])
        .pipe(gulp.dest('./assets/vendors/chartist'));

       return merge(aScript1, aScript46, aScript39, aScript33, aScript9, aScript34, aScript71, aScript4, aScript21, aScript52, aScript53, aScript54)
});


/*Styles for addons*/
gulp.task('buildOptionalVendorStyles', function() {
    var aStyle1 = gulp.src(['../node_modules/@mdi/font/css/materialdesignicons.min.css'])
        .pipe(gulp.dest('./assets/vendors/mdi/css'));
    var aStyle2 = gulp.src(['../node_modules/@mdi/font/fonts/*'])
        .pipe(gulp.dest('./assets/vendors/mdi/fonts'));
    var aStyle3 = gulp.src(['../node_modules/font-awesome/css/font-awesome.min.css'])
        .pipe(gulp.dest('./assets/vendors/font-awesome/css'));
    var aStyle4 = gulp.src(['../node_modules/font-awesome/fonts/*'])
        .pipe(gulp.dest('./assets/vendors/font-awesome/fonts'));
    var aStyle5 = gulp.src(['../node_modules/flag-icon-css/css/flag-icons.min.css'])
        .pipe(gulp.dest('./assets/vendors/flag-icon-css/css'));
    var aStyle6 = gulp.src(['../node_modules/flag-icon-css/flags/**/*'])
        .pipe(gulp.dest('./assets/vendors/flag-icon-css/flags'));
    var aStyle7 = gulp.src(['../node_modules/simple-line-icons/css/simple-line-icons.css'])
        .pipe(gulp.dest('./assets/vendors/simple-line-icons/css'));
    var aStyle8 = gulp.src(['../node_modules/simple-line-icons/fonts/*'])
        .pipe(gulp.dest('./assets/vendors/simple-line-icons/fonts'));
    var aStyle9 = gulp.src(['../node_modules/ti-icons/css/themify-icons.css'])
        .pipe(gulp.dest('./assets/vendors/ti-icons/css'));
    var aStyle10 = gulp.src(['../node_modules/ti-icons/fonts/*'])
        .pipe(gulp.dest('./assets/vendors/ti-icons/fonts'));         
    var aStyle34 = gulp.src(['../node_modules/select2/dist/css/select2.min.css'])
        .pipe(gulp.dest('./assets/vendors/select2'));
   
    var aStyle35 = gulp.src(['../node_modules/select2-bootstrap-theme/dist/select2-bootstrap.min.css'])
        .pipe(gulp.dest('./assets/vendors/select2-bootstrap-theme')); 
    var fonts = gulp.src(['./assets/fonts/fonts/*'])
        .pipe(gulp.dest('./assets/vendors/bootstrap-datepicker/fonts'))
    
    var aStyle58 = gulp.src(['../node_modules/typicons.font/src/font/*'])
        .pipe(gulp.dest('./assets/vendors/typicons'));
    var aStyle32 = gulp.src(['../node_modules/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css'])
        .pipe(gulp.dest('./assets/vendors/bootstrap-datepicker'));
    var aStyle59 = gulp.src(['../node_modules/daterangepicker/daterangepicker.css'])
        .pipe(gulp.dest('./assets/vendors/daterangepicker'));
    var aStyle41 = gulp.src(['../node_modules/jvectormap/jquery-jvectormap.css'])
        .pipe(gulp.dest('./assets/vendors/jvectormap'));
    var aStyle13 = gulp.src(['../node_modules/chartist/dist/chartist.min.css'])
        .pipe(gulp.dest('./assets/vendors/chartist'));
    return merge(aStyle1, aStyle2, aStyle3, aStyle4, aStyle5, aStyle6, aStyle7, aStyle8, aStyle9, aStyle10, aStyle13, aStyle34, aStyle35, aStyle58, aStyle32, aStyle59, aStyle41, fonts)
});

//Copy essential map files
gulp.task('copyMapFiles', function() {
    var map1 = gulp.src('../node_modules/bootstrap/dist/js/bootstrap.min.js.map')
        .pipe(gulp.dest('./assets/vendors/js'));
    var map2 = gulp.src('../node_modules/@mdi/font/css/materialdesignicons.min.css.map')
        .pipe(gulp.dest('./assets/vendors/mdi/css'));
    var map11 = gulp.src('../node_modules/chartist/dist/chartist.css.map')
        .pipe(gulp.dest('./assets/vendors/chartist'));
            return merge(map1, map2, map11);
});

/*sequence for building vendor scripts and styles*/
gulp.task('bundleVendors', gulp.series('clean:vendors', 'buildBaseVendorStyles','buildBaseVendorScripts', 'buildOptionalVendorStyles', 'buildOptionalVendorScripts', 'copyMapFiles'));