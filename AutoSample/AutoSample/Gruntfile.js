// JavaScript source code
module.exports = function (grunt) {
    grunt.initConfig({
        //注册任务, 清理文件夹
        clean: ['wwwroot/lib/*'],
        //合并文件
        concat: {
            all: {
                src: ['Typescript/test/js', 'TypeScript/Food.js'],
                dest: 'lib/combined.js'
            }
        },
        //压缩js
        uglify: {
            all: {
                src: ['temp/combined.js'],
                dest: 'wwwroot/bib/combined.min.js'
            }
        }
    });
    //注册任务,可以将多个任务合并为一个，也可以分开注册
    grunt.registerTask('all', ['clean', 'concat', 'uglify']);
    grunt.registerTask('clean');
};