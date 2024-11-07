function getBodyScrollPosition() {
    let position=window.scrollY;
    return Math.ceil(position);
}

function setBodyScrollPosition(yOffSet) {
    window.scroll({
        top: yOffSet,
        left: 0
    });
}

function disableBodyScrolling() {
    document.getElementById("appHolder").classList.add("no-scroll");
    document.body.classList.add("no-scroll");
}

function enableBodyScrolling() {
    document.getElementById("appHolder").classList.remove("no-scroll");
    document.body.classList.remove("no-scroll");
}

function scrollToTop() {
    window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });
}

function scrollOptionIntoView(elementId, containerElementId) {

    const container = document.getElementById(containerElementId);
    const element = document.getElementById(elementId);
    if (element == null || containerElementId == null)
        return;

    let parentRect = container.getBoundingClientRect();
    let childRect = element.getBoundingClientRect();
    let topPos = element.offsetTop;

    if (parentRect.bottom <= childRect.bottom)
    {
        container.scrollTop = topPos - 160;
    }
    else if (parentRect.top >= childRect.top)
    {
        container.scrollTop = topPos;
    }

}