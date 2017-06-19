

function colorizeDetails() {
    $("#status:contains('Completed')").css({ "color": "#00ff21", "font-weight": "Bold" });

    $("#priority:contains('High')").css({"color" : "red", "font-weight": "Bold"});
    $("#priority:contains('Low')").css({ "color": "#02c873", "font-weight": "Bold" });
    $("#priority:contains('Medium')").css({ "color": "orange", "font-weight": "Bold" });

    $("#effort:contains('Big')").css({"color": "red", "font-weight": "Bold"});
    $("#effort:contains('Small')").css({ "color": "#02c873", "font-weight": "Bold" });
    $("#effort:contains('Medium')").css({"color": "orange", "font-weight": "Bold"});

    $("#dstatus:contains('Red')").css({"color": "red", "font-weight": "Bold"});
    $("#dstatus:contains('Green')").css({ "color": "#02c873", "font-weight": "Bold" });
    $("#dstatus:contains('Amber')").css({ "color": "orange", "font-weight": "Bold" });
};

function colorizeIndex() {
    $("tr td:nth-child(6):contains('Completed')").css({ "color": "green", "font-weight": "Bold" });

    $("tr td:nth-child(7):contains('High')").css({ "color": "red", "font-weight": "Bold" });
    $("tr td:nth-child(7):contains('Low')").css({ "color": "#02c873", "font-weight": "Bold" });
    $("tr td:nth-child(7):contains('Medium')").css({ "color": "orange", "font-weight": "Bold" });

    $("tr td:nth-child(8):contains('Big')").css({ "color": "red", "font-weight": "Bold" });
    $("tr td:nth-child(8):contains('Small')").css({ "color": "#02c873", "font-weight": "Bold" });
    $("tr td:nth-child(8):contains('Medium')").css({ "color": "orange", "font-weight": "Bold" });

    $("tr td:nth-child(9):contains('Red')").css({ "color": "red", "font-weight": "Bold" });
    $("tr td:nth-child(9):contains('Green')").css({ "color": "#02c873", "font-weight": "Bold" });
    $("tr td:nth-child(9):contains('Amber')").css({ "color": "orange", "font-weight": "Bold" });
};

function ShowCreate() {
    $('#AddComment').slideToggle("fast")
}
//    var AddCommentField = document.getElementById("AddComment")
//    var CommentButton = document.getElementById("AddButton")
//    if (AddCommentField.hidden == true) {
//        AddCommentField.hidden = false;
//        CommentButton.innerHTML = "Cancel comment"
//    }
//    else {
//        AddCommentField.hidden = true;
//        CommentButton.innerHTML = "Add new comment"
//    };
//}

//$('#AddComment').slideDown("fast")

function ShowAddFile() {
    var AddFileField = document.getElementById("UploadField")
    var FileButton = document.getElementById("AddFileButton")
    if (AddFileField.hidden == true) {
        AddFileField.hidden = false;
        FileButton.innerHTML = "Cancel adding"
    }
    else {
        AddFileField.hidden = true;
        FileButton.innerHTML = "Add file"
    };
}

//Table sorting

var compare = {
    name: function (a, b) {                  
        a = a.replace(/^the /i, '');         
        b = b.replace(/^the /i, '');          

        if (a < b) {                        
            return -1;                         
        } else {                              
            return a > b ? 1 : 0;               
        }                                    
    },


    date: function(a, b) {                 
        a = new Date(a);                     
        b = new Date(b);                     

        return a - b;                        
    }

};

$('.table-hover').each(function () {
    var $table = $(this);
    var $tbody = $table.find('tbody');        
    var $controls = $table.find('th');
    var rows = $tbody.find('tr').toArray();  

        $controls.on('click', function () {
            var $header = $(this);                  
            var order = $header.data('sort');       
            var column;         
            
     
            if ($header.is('.ascending') || $header.is('.descending')) {  
                $header.toggleClass('ascending descending');  
                $tbody.append(rows.reverse());               
            } else {
                $header.addClass('ascending');                
         
                $header.siblings().removeClass('ascending descending'); 
                if (compare.hasOwnProperty(order)) {  
                    column = $controls.index(this);       

                    rows.sort(function(a, b) {               
                        a = $(a).find('td').eq(column).text(); 
                        b = $(b).find('td').eq(column).text();
                        return compare[order](a, b);           
                    });

                    $tbody.append(rows);
                }
            }
        });
});


//document.getElementById("AddFileButton").addEventListener("click", ShowAddFile)


$(function () {

    // We can attach the `fileselect` event to all file inputs on the page
    $(document).on('change', ':file', function () {
        var input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [numFiles, label]);
    });

    // We can watch for our custom `fileselect` event like this
    $(document).ready(function () {
        $(':file').on('fileselect', function (event, numFiles, label) {

            var input = $(this).parents('.input-group').find(':text'),
                log = numFiles > 1 ? numFiles + ' files selected' : label;

            if (input.length) {
                input.val(log);
            } else {
                if (log) alert(log);
            }

        });
    });

});

//function Priority() {
    
//    var $table = $('.table-hover:first');
//    var $tbody = $table.find('tbody'); 
//    var $rows = $tbody.find('tr').toArray();
//    for (var i = 0; i < $rows.length; i++) {
        
//        var $cells = $('td', $rows[i]).toArray();
//        if($cells.indexOf('Big')) {$rows.('danger')};
//        //if ($cells[7].innerHTML == 'Big') { $rows[i].addClass('danger') };
//        $cells = null;
//    }
//}

function priority() {
    document.getElementById("dropdownMenu1").innerHTML = 'Colorize by: Priority <span class="caret"></span>'
    var rows = document.getElementById("mainTable").rows;
    for (var i = 0; i < rows.length; i++) {
        cells = rows[i].cells;
            if (cells[7].innerHTML.includes('High')) { rows[i].className = "danger" };
            if (cells[7].innerHTML.includes('Medium')) { rows[i].className = "warning" };
            if (cells[7].innerHTML.includes('Low')) { rows[i].className = "success" };      
    }
}
    
function effort() {
    document.getElementById("dropdownMenu1").innerHTML = 'Colorize by: Effort <span class="caret"></span>'
    var rows = document.getElementById("mainTable").rows;
    for (var i = 0; i < rows.length; i++) {
        cells = rows[i].cells;
            if (cells[8].innerHTML.includes('Big')) { rows[i].className = "danger" };
            if (cells[8].innerHTML.includes('Medium')) { rows[i].className = "warning" };
            if (cells[8].innerHTML.includes('Small')) { rows[i].className = "success" };
    }
}
        
function delivery() {
    document.getElementById("dropdownMenu1").innerHTML = 'Colorize by: Delivery status <span class="caret"></span>'
    var rows = document.getElementById("mainTable").rows;
    for (var i = 0; i < rows.length; i++) {
        cells = rows[i].cells;
        if (cells[9].innerHTML.includes('Red')) { rows[i].className = "danger" };
        if (cells[9].innerHTML.includes('Amber')) { rows[i].className = "warning" };
        if (cells[9].innerHTML.includes('Green')) { rows[i].className = "success" };
    }
}

function status() {
    document.getElementById("dropdownMenu1").innerHTML = 'Colorize by: Project status <span class="caret"></span>'
    var rows = document.getElementById("mainTable").rows;
    for (var i = 0; i < rows.length; i++) {
        cells = rows[i].cells;
        if (cells[6].innerHTML.includes('Cancelled')) { rows[i].className = "danger" };
        if (cells[6].innerHTML.includes('On hold')) { rows[i].className = "warning" };
        if (cells[6].innerHTML.includes('In progress')) { rows[i].className = "success" };
    }
}

function clearColors() {
    document.getElementById("dropdownMenu1").innerHTML = 'Colorize by <span class="caret"></span>'
    //$('#dropdownMenu1').load();
    var rows = document.getElementById("mainTable").rows;
    for (var i = 0; i < rows.length; i++) {
        cells = rows[i].cells;
        rows[i].className = "" };
}

function hideShowCancelled() {
    var hs = document.getElementById("hsCancelled")
    if (hs.innerHTML.includes('Hide')) {
        hs.innerHTML = "Show Cancelled";
    }
    else {
        hs.innerHTML = "Hide Cancelled";
    }
    var rows = document.getElementById("mainTable").rows;
    for (var i = 0; i < rows.length; i++) {
        cells = rows[i].cells;
        if (cells[6].innerHTML.includes('Cancelled') && rows[i].style.display != 'none'){
            rows[i].style.display = 'none';
            hs.innerHTML = "Show Cancelled";
        }
        else if (cells[6].innerHTML.includes('Cancelled') && rows[i].style.display == 'none') {
            rows[i].style.display = 'table-row';
        }
        //else {
        //    rows[i].style.display = 'table-row';
        //}
    }

}

function hideShowNotStarted() {
        var hs = document.getElementById("hsNotStarted")
        if (hs.innerHTML.includes('Hide')) {
            hs.innerHTML = "Show Not Started";
        }
        else {
            hs.innerHTML = "Hide Not Started";
        }
        var rows = document.getElementById("mainTable").rows;
        for (var i = 0; i < rows.length; i++) {
            cells = rows[i].cells;
            if (cells[6].innerHTML.includes('started') && rows[i].style.display != 'none'){
                rows[i].style.display = 'none';
                hs.innerHTML = "Show Not Started";
            }
            else if (cells[6].innerHTML.includes('started') && rows[i].style.display == 'none') {
                rows[i].style.display = 'table-row';
            }
            //else {
            //    rows[i].style.display = 'table-row';
            //}
        }

    }

function hideShowOnHold() {
    var hs = document.getElementById("hsOnHold")
    if (hs.innerHTML.includes('Hide')) {
        hs.innerHTML = "Show On hold";
    }
    else {
        hs.innerHTML = "Hide On Hold";
    }
    var rows = document.getElementById("mainTable").rows;
    for (var i = 0; i < rows.length; i++) {
        cells = rows[i].cells;
        if (cells[6].innerHTML.includes('hold') && rows[i].style.display != 'none') {
            rows[i].style.display = 'none';
            hs.innerHTML = "Show On hold";
        }
        else if (cells[6].innerHTML.includes('hold') && rows[i].style.display == 'none') {
            rows[i].style.display = 'table-row';
        }
        //else {
        //    rows[i].style.display = 'table-row';
        //}
    }

}

function showAll() {
    var rows = document.getElementById("mainTable").rows;

    for (var i = 0; i < rows.length; i++) {
        rows[i].style.display = 'table-row';
        document.getElementById("hsOnHold").innerHTML = "Hide On hold";
        document.getElementById("hsCancelled").innerHTML = "Hide Cancelled";
        document.getElementById("hsNotStarted").innerHTML = "Hide Not Started";

    }
}


document.getElementById("AddButton").addEventListener("click", ShowCreate)