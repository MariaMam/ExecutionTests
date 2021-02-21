function onVerticalGridInit(s, e) {
    var headerPanel = document.querySelector(".header-panel");
    if(headerPanel)
        s.SetFixedRowsTopOffset(headerPanel.offsetHeight);
}