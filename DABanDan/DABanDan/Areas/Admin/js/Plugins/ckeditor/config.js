/**  * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.  * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license  */  CKEDITOR.editorConfig = function( config ) { 	// Define changes to default configuration here. For example: 	// config.language = 'fr';     // config.uiColor = '#AADC6E';     config.allowedContent = true;     config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '~/Areas/Admin/js/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '~/Areas/Admin/js/plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '~/Areas/Admin/js/plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '~/Areas/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '~/Areas/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '~/Areas/Admin/js/plugins/ckfinder/');
};
