function scrollToError(){
    let modalContainer = document.querySelector('.overlay');
    if(modalContainer != null) {
        scrollToErrorWithinElement(modalContainer);
    }
    else{
        // check for tab and click if not select
        let invalidTab = document.querySelector('li.invalid-tab');
        if(invalidTab != null && !invalidTab.classList.contains('active-invalid-tab')){
            invalidTab.click();
        }

        setTimeout(function(){
            // check for a panel on the screen
            let errorPanel = document.querySelector('.panel.invalid-panel');
            if(errorPanel == null || !errorPanel.classList.contains('border-on-hover')){
                scrollToErrorOnWindow();
            }
            else{
                let errorPanelHeader = errorPanel.querySelector('.panel-header');
                errorPanelHeader.click();
                setTimeout(scrollToErrorOnWindow, 200);
            }
        }, 200);
    }
}


function scrollToErrorOnWindow(){
    // check if LHS can scroll is present
    let lhsScroll = document.querySelector('.split.left.can-scroll');
    if(lhsScroll == null) {
        let errorQuestion = document.querySelector('.invalid-input');
        if(errorQuestion != null) {
            let errorRect = errorQuestion.getBoundingClientRect();
            if (errorRect.bottom > window.innerHeight || errorRect.bottom < 0) {
                let currentScroll = window.scrollY + window.innerHeight;
                let scrollOffset = 50;
                let neededScroll = errorRect.bottom - currentScroll;
                let newScrollPosition = neededScroll + scrollOffset;
                window.scroll({
                    top: newScrollPosition,
                    behavior: 'smooth'
                });
            }
        }
    }
    else{
        scrollToErrorWithinElement(lhsScroll);
    }
}

function scrollToErrorWithinElement(elementContainer){
    let errorQuestion = elementContainer.querySelector('.invalid-input');
    if(errorQuestion != null) {
        let parentRect = elementContainer.getBoundingClientRect();
        let childRect = errorQuestion.getBoundingClientRect();
        if(childRect.bottom < parentRect.bottom  && childRect.bottom < 0)
            return;
        let scrollOffset = 50;
        let currentScroll = elementContainer.scrollTop;
        let neededScroll = childRect.bottom - parentRect.bottom;
        let newScrollPosition = currentScroll + neededScroll + scrollOffset;
        elementContainer.scroll({
            top: newScrollPosition,
            behavior: 'smooth'
        });
    }
}