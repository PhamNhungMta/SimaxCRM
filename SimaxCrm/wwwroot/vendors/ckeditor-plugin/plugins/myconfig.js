
// get path of directory ckeditor
var basePath = CKEDITOR.basePath;
basePath = basePath.substr(0, basePath.indexOf("ckeditor/"));

    (function () {
        CKEDITOR.plugins.addExternal('simaxprofilemergefield', basePath + 'ckeditor-plugin/plugins/profilemergefield/', 'plugin.js');
    })();

// config for toolbar, extraPlugins,...
CKEDITOR.editorConfig = function (config) {
    config.extraPlugins = 'simaxprofilemergefield';
    //     Can use default toolbar or custom toolbar if you want
    //   config.toolbar_Basic.push(['helloworld.btn']);   
    //config.toolbar_MyToolbarSet.push(['helloworld.btn']);
};