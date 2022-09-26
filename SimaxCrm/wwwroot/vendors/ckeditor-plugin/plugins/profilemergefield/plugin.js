
CKEDITOR.plugins.add('simaxprofilemergefield',
{
    requires: ['richcombo'],
    init: function (editor) {
        // array of strings to choose from that'll be inserted into the editor
        var strings = [];

        strings.push(['@Id@', 'LeadId', 'LeadId']);
        strings.push(['@Name@', 'Name', 'Name']);
        strings.push(['@PhoneNumber@', 'PhoneNumber', 'PhoneNumber']);
        strings.push(['@Email@', 'Email', 'Email']);
        strings.push(['@Address@', 'Address', 'Address']);
        strings.push(['@City@', 'City', 'City']);
        strings.push(['@State@', 'State', 'State']);
        strings.push(['@Country@', 'Country', 'Country']);
        strings.push(['@PostalCode@', 'PostalCode', 'PostalCode']);

        // add the menu to the editor
        editor.ui.addRichCombo('simaxprofilemergefield',
        {
            label: 'Lead Fields',
            title: 'Lead Fields',
            voiceLabel: 'Lead Fields',
            className: 'cke_format',
            multiSelect: false,
            width: 150,
            panel:
            {
                css: [editor.config.contentsCss, CKEDITOR.skin.getPath('editor')],
                voiceLabel: editor.lang.panelVoiceLabel
            },

            init: function () {
                //this.startGroup("Select Merge Fields");
                for (var i = 0; i < strings.length; i++) {
                    this.add(strings[i][0], strings[i][1], strings[i][2]);
                }
            },

            onClick: function (value) {
                editor.focus();
                editor.fire('saveSnapshot');
                editor.insertHtml(value);
                editor.fire('saveSnapshot');
            }
        });
    }
});
