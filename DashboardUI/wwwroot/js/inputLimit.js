window.activateTab = function (selector) {
    var tabEl = document.querySelector(selector);
if (tabEl) {
        var tab = new bootstrap.Tab(tabEl);
tab.show();
    }
};

window.isTabActive = function (selector) { 
    var el = document.querySelector(selector);
    return el && el.classList.contains("active");
};