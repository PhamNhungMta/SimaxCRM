import Widget from "./Widget.js";

export default class Table4Widget extends Widget {
    getHtmlId() {
        return "Table4Widget";
    }

    name() {
        return getI18n('table');
    }

    icon() {
        return 'fal fa-table';
    }
    init() {
        super.init();
    }
}