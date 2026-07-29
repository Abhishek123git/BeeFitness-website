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

window.hiveScrollIntoView = (selector) => {
    const el = document.querySelector(selector);
    if (el) el.scrollIntoView({ behavior: "smooth", block: "start" });
};