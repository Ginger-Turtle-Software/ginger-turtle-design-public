
function maskInput(id, mask, pattern, characterPattern) {
    const el = document.getElementById(id);
    const value = el.value;
    if (el) {
        const formatted = formatMaskInput(value, mask, pattern, characterPattern);
        el.value = formatted;
    }
}

function restrictInput(id, characterPattern) {
    const el = document.getElementById(id);
    const value = el.value;
    if (el) {
        const chars = value.match(new RegExp(characterPattern, "g"));

        if (chars === null || chars === undefined) {
            el.value = "";
            return "";
        }

        el.value = chars.join("");
        return el.value;
    }
    return "";
}

function formatMaskInput(value, mask, pattern, characterPattern) {
    const chars = !characterPattern ? value.replace(new RegExp(pattern, "g"), "").split('') : value.match(new RegExp(characterPattern, "g"));
    let count = 0;

    let formatted = '';
    for (const element of mask) {
        let c = element;
        if (chars && chars[count]) {
            if (/\*/.test(c)) {
                formatted += chars[count];
                count++;
            } else {
                formatted += c;
            }
        }
    }
    return formatted;
}

function padDate(id) {
    const value = getElementValueById(id);
    if (isEmpty(value))
        return;
    if (value.length === 1) {
        const newValue = `0${value}`;
        setElementValueById(id, newValue);
    }
}


function formatDateInputAndShiftFocus(id, inputLength, nextId) {
    formatInput(id, "[0-9]", inputLength);
    const value = getElementValueById(id);
    if (value.length === inputLength) {
        focusInput(nextId);
    }
}


function formatInput(id, pattern, inputLength) {
    const value = getElementValueById(id);
    if (isEmpty(value))
        return;
    const chars = value.match(new RegExp(pattern, "g"));
    if (chars) {
        let formatted = "";
        formatted = chars.join("");
        if (inputLength) {
            formatted = formatted.substring(0, inputLength);
        }
        setElementValueById(id, formatted);
    }
    else {
        setElementValueById(id, "");
    }
}

function formatMoney(id, pattern, timeout) {
    setTimeout(function () {
        let value = hideChars(pattern, id);
        value = value.replaceAll("£", "").replaceAll(",", "");
        if (isEmpty(value))
            return;
        writeMoneyToValue(id, value);
    }, timeout);
}

function hideChars(pattern, id) {
    let initValue = getElementValueById(id);
    if (isEmpty(initValue)) return "";
    initValue = initValue.match(new RegExp(pattern, "g"));
    if (isEmpty(initValue))
        initValue = [];
    writeMoneyToValue(id, initValue.join(""));
    return initValue.join("");
}

function writeMoneyToValue(id, value) {
    let moneyFormat = "";
    if (value !== "") {
        moneyFormat = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD', minimumFractionDigits: 0, maximumFractionDigits: 0 }).format(value);
    }
    setElementValueById(id, moneyFormat);
}

function formatMoneyToFloat(id) {
    const value = getElementValueById(id);
    if (isEmpty(value) || value === "$")
        return;
    const formatted = parseFloat(value.replaceAll("$", "").replaceAll(",", ""));
    writeMoneyToValue(id, formatted);
}
