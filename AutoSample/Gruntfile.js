// JavaScript source code
module.exports = function (grunt) {
    grunt.initConfig({
        //ע������, �����ļ���
        clean: ['wwwroot/lib/*'],
        //�ϲ��ļ�
        concat: {
            all: {
                src: ['Typescript/test/js', 'TypeScript/Food.js'],
                dest: 'lib/combined.js'
            }
        },
        //ѹ��js
        uglify: {
            all: {
                src: ['temp/combined.js'],
                dest: 'wwwroot/bib/combined.min.js'
            }
        }
    });
    //ע������,���Խ��������ϲ�Ϊһ����Ҳ���Էֿ�ע��
    grunt.registerTask('all', ['clean', 'concat', 'uglify']);
    grunt.registerTask('clean');
};