﻿
function colorizeDetails() {
    $("#status:contains('Completed')").css({"color" : "green", "font-weight": "Bold"});
    $("#status:contains('progres')").css({"color": "black", "font-weight": "Bold"});

    $("#priority:contains('High')").css({"color" : "red", "font-weight": "Bold"});
    $("#priority:contains('Low')").css({"color" : "green", "font-weight": "Bold"});
    $("#priority:contains('Medium')").css({ "color": "orange", "font-weight": "Bold" });

    $("#effort:contains('Big')").css({"color": "red", "font-weight": "Bold"});
    $("#effort:contains('Small')").css({"color": "green", "font-weight": "Bold"});
    $("#effort:contains('Medium')").css({"color": "orange", "font-weight": "Bold"});

    $("#dstatus:contains('Red')").css({"color": "red", "font-weight": "Bold"});
    $("#dstatus:contains('Green')").css({"color": "green", "font-weight": "Bold"});
    $("#dstatus:contains('Amber')").css({ "color": "orange", "font-weight": "Bold" });
};

function colorizeIndex() {
    $("tr td:nth-child(6):contains('Completed')").css({ "color": "green", "font-weight": "Bold" });
    $("tr td:nth-child(6):contains('progres')").css({ "color": "black", "font-weight": "Bold" });

    $("tr td:nth-child(7):contains('High')").css({ "color": "red", "font-weight": "Bold" });
    $("tr td:nth-child(7):contains('Low')").css({ "color": "green", "font-weight": "Bold" });
    $("tr td:nth-child(7):contains('Medium')").css({ "color": "orange", "font-weight": "Bold" });

    $("tr td:nth-child(8):contains('Big')").css({ "color": "red", "font-weight": "Bold" });
    $("tr td:nth-child(8):contains('Small')").css({ "color": "green", "font-weight": "Bold" });
    $("tr td:nth-child(8):contains('Medium')").css({ "color": "orange", "font-weight": "Bold" });

    $("tr td:nth-child(9):contains('Red')").css({ "color": "red", "font-weight": "Bold" });
    $("tr td:nth-child(9):contains('Green')").css({ "color": "green", "font-weight": "Bold" });
    $("tr td:nth-child(9):contains('Amber')").css({ "color": "orange", "font-weight": "Bold" });
};

function ShowCreate() {
    var AddCommentField = document.getElementById("AddComment")
    var CommentButton = document.getElementById("AddButton")
    if (AddCommentField.hidden == true) {
        AddCommentField.hidden = false;
        CommentButton.innerHTML = "Cancel comment"
    }
    else {
        AddCommentField.hidden = true;
        CommentButton.innerHTML = "Add new comment"
    };
}

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
    }


    //duration: function(a, b) {             
    //    a = a.split(':');                    
    //    b = b.split(':');                    

    //    a = Number(a[0]) * 60 + Number(a[1]);
    //    b = Number(b[0]) * 60 + Number(b[1]); 

    //    return a - b;                         
    //},
    //date: function(a, b) {                 
    //    a4 = new Date(a);                     
    //    b = new Date(b);                     

    //    return a - b;                        
    //}

};

$('.sortable').each(function () {
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