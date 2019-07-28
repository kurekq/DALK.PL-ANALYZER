function setMaxHeightForAllElementsInClass(className) {
    var maxCallback = (max, cur) => Math.max(max, cur);

    var allElements = document.querySelectorAll(className);
    if (allElements.length > 0)
    {
        var elementsHeights = Array.from(allElements, m => m.offsetHeight);
        var hMax = elementsHeights.reduce(maxCallback);
        Array.from(allElements).forEach(function (el) {
            el.style.height = hMax + "px";
        });
    }
}

function setMaxHeightForAllElementsInClassFromSum(className, sumOfHFromClasses) {
    var maxCallback = (max, cur) => Math.max(max, cur);

    var allElements = document.querySelectorAll(className);
    if (allElements.length > 0) {
        var elementsHeights = new Array();
        Array.from(allElements).forEach(function (el) {
            var elementHeight = 0;
            sumOfHFromClasses.forEach(
                function (c) {
                    var subEl = el.querySelector(c);
                    if (subEl != undefined) {
                        elementHeight += subEl.offsetHeight;
                    }
                });
            elementsHeights.push(elementHeight);
        });

        var hMax = elementsHeights.reduce(maxCallback);
        Array.from(allElements).forEach(function (el) {
            el.style.height = hMax + "px";
        });
    }
}

function verticalAlignAllElements()
{
    setHeightForMvpAndDesc();
    setMarginInNotPlayedMatchNavigation();
}

function setHeightForMvpAndDesc() {
     
    setMaxHeightForAllElementsInClass(".js-matchMVP");
    setMaxHeightForAllElementsInClass(".js-matchDesc");
    setMaxHeightForAllElementsInClassFromSum(".js-matchResult", [".js-matchTeam1", ".js-matchTeam2"]);

}

function setMarginInNotPlayedMatchNavigation() {
    var allNotPlayedMatch = document.getElementsByClassName("js-NotPlayedMatch");
    Array.from(allNotPlayedMatch).forEach(function (notPlayedMatch) {

        var navigations = notPlayedMatch.getElementsByClassName("js-matchNav");
        if (navigations != undefined) {
            var navigation = navigations[0];
            navigation.style.marginTop = (getMVPMaxHeight() + 4) + "px";

        }        
    });
}

function getMVPMaxHeight()
{
    var maxCallback = (max, cur) => Math.max(max, cur);
    var allElements = document.querySelectorAll(".js-matchMVP");
    var hMax = 0;
    if (allElements.length > 0) {
        var elementsHeights = Array.from(allElements, m => m.offsetHeight);
        hMax = elementsHeights.reduce(maxCallback);
    }
    return hMax;
}


function updateMatchesFilters()
{
    start();
    $.ajax({
        url: '/Matches/GetMatchesJson',
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            end('updateMatchesFilters');
            changeJsonAndSend(data);          
        },
        error: function (xhr, status, error) {
            console.log('no ok');
        }
    });

}

function changeJsonAndSend(jsonObj)
{
    jsonObj.AllFiters.forEach(function (filterEl) {

        var selectedFilterName = document.getElementById(filterEl.CSSId).innerText.trim();
        filterEl.items.forEach(function (filterItem) {
            filterItem.filterData.Selected = filterItem.filterData.Text === selectedFilterName;
        });

    });
    sendMatches(JSON.stringify(jsonObj));
}

function setInnerHtml(id, innerHtml)
{
    document.getElementById(id).innerHTML = innerHtml;
}

function sendMatches(stringifiedJsonObj) {
    start();
    var matchesMV = stringifiedJsonObj;
    var jsonAnswer = JSON.stringify({ Json: matchesMV });
    $.ajax({
        url: '/Matches/FilteredIndex',
        type: 'post',
        dataType: 'text',
        contentType: 'application/json',
        success: function (data) {
            end('sendMatches');
            start();
            $(".content").html(data);
            verticalAlignAllElements();
            end('setContent');
        },
        error: function (xhr, status, error) {
            console.log('no ok');
        },
        data: jsonAnswer
    });
}
    var startTime, endTime;

    function start() {
        startTime = new Date();
    };

    function end(what) {
        endTime = new Date();
        var timeDiff = endTime - startTime; //in ms

        console.log(what + ': ' + timeDiff);
    }