window.onscroll = function () { windowIsScrolling() };
let navbarHeight;

function setStoreValue(keyName, keyValue){
    localStorage.setItem(keyName, keyValue);
}

function getStoreValue(keyName) {
    return localStorage.getItem(keyName);
}

function removeStoreValue(keyName){
    localStorage.removeItem(keyName);
}

function getDeviceInformation() {
    return navigator.userAgent;
}

function triggerClick(elementId) {
    const element = document.getElementById(elementId);
    if (element !== undefined && element != null) {
        element.click();
    }
}

function isEmpty(value) {
    return (value === undefined || value === "" || value == null);
}

function getElementValueById(elementId) {
    const el = document.getElementById(elementId);
    if (isEmpty(el))
        return;
    return el.value;
}

function setElementValueById(elementId, value) {
    const el = document.getElementById(elementId);
    el.value = value;
}


function debounce(func, wait, immediate) {
    let timeout;
    return function () {
        const context = this, args = arguments;
        const later = function () {
            timeout = null;
            if (!immediate) func.apply(context, args);
        };
        const callNow = immediate && !timeout;
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
        if (callNow) func.apply(context, args);
    };
}

function focusInput(elementId) {
    if (elementId) {
        const input = document.getElementById(elementId);
        input.focus();
        input.select();
    }
}

function removeFocus() {
    document.activeElement.blur();
}

function navigateToNewTab(url) {
    window.open(url, '_blank');
}

function focusInputAfterTimeout(elementId, timeout = 250) {
    setTimeout(function () {
        const input = document.getElementById(elementId);
        input.focus();
    }, timeout);
}

function scrollToCurrentSelected(firstOptionElementId, containerElementId, itemPosition) {
    setTimeout(function () {
        const container = document.getElementById(containerElementId);
        const firstItem = document.getElementById(firstOptionElementId);
        if (firstItem == null)
            return;
        const pixelsPerItem = firstItem.scrollHeight;
        const yScroll = pixelsPerItem * itemPosition;
        container.scroll(0, yScroll);
    }, 25);
}

function scrollToElementIfOffModal(elementId) {
    setTimeout(function () {
        // get element
        const element = document.getElementById(elementId);
        if (element === undefined)
            return;

        // check if modal is open
        const modal = document.getElementsByClassName("modal");
        if (modal.length === 0)
            return;

        // check if the element is off the modal
        const modalRect = modal[0].getBoundingClientRect();
        const elementRect = element.getBoundingClientRect();
        const modalBottomY = modalRect.y + modalRect.height - 75;
        const elementBottomY = elementRect.y + elementRect.height;

        if (elementBottomY < modalBottomY)
            return;

        const modalBody = document.getElementsByClassName('modal-body')[0];
        modalBody.scrollBy(
            {
                top: 250,
                left: 0,
                behavior: "smooth"
            });
    }, 25);
}

let invalidInterval;

function scrollTo(el, amount) {
    if (!el || !el.scrollTo) return;
    el.scrollTo({
        top: amount,
        behavior: 'smooth'
    });
}

function windowIsScrolling() {
    // Get the navbar height
    if(!navbarHeight) {
        getNavBarHeight();
    }

    let yScroll = document.documentElement.scrollTop || document.body.scrollTop;

    cleanUpBodyClasses();

    // if yScroll is greater than the nav height then add sticky
    if(yScroll > navbarHeight) {
        applySticky();
    }

    // if yScroll is less than the nav height then remove sticky
    if(yScroll <= navbarHeight) {
        removeSticky();
    }
}

function getNavBarHeight() {
    const navBar = document.getElementsByClassName('navbar');
    if (navBar.length === 0)
        return;
    navbarHeight = navBar[0].getBoundingClientRect().height;
}

function applySticky() {
    const body = document.getElementsByTagName("body")[0];
    body.classList.add("sticky");
}

function removeSticky() {
    cleanUpBodyClasses();
}

function resetScrollSections()
{
    const leftSplit = document.getElementsByClassName("split left")[0];
    const rightSplit = document.getElementsByClassName("split right")[0];
    scrollTo(leftSplit, 0);
    scrollTo(rightSplit, 0);
    if (leftSplit) {
        window.scrollBy({
            top: -window.pageYOffset,
            behavior: 'smooth'
        });
    }

}

function cleanUpBodyClasses() {
    const body = document.getElementsByTagName("body")[0];
    if (body.classList.contains("invalid")) {
        body.setAttribute("class", "");
        body.classList.add("invalid");
    } else {
        body.setAttribute("class", "");
    }
    body.classList.add(returnPageName());
}

function returnPageName() {
    const pathname = window.location.pathname.split("/")[1];
    if (!pathname)
        return "home";
    else
        return pathname;
}

function openPanelAndScrollToFirstErrorAfterTimeout(panelIndex) {
    setTimeout(() => { openPanelAndScrollToFirstError(panelIndex) }, 100);

}

function openPanelAndScrollToFirstError(panelIndex) {

    panelIndex = panelIndex - 1;
    const collection = document.getElementsByClassName("panel");
    const targetElement = collection[panelIndex].querySelector(".make-clickable");
    if (targetElement.title === "Show Details") {
        targetElement.click();
    }

    setTimeout(scrollToError, 100);
}

function clearTextInput(inputName){
    let element = document.getElementById(inputName);
    if(element === undefined)
        return;
    element.value = "";
}


var saveAsFile = function (filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}