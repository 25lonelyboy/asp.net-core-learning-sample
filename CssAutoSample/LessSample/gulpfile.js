var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less");
//创建任务
gulp.task("less", function () {
    return gulp.src("styles/main.less")//选择文件，可以通配符
        .pipe(less())//less编译
        .pipe(gulp.dest("wwwroot/css"));//保存在指定目录
});