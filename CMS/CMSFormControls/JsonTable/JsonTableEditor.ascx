<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JsonTableEditor.ascx.cs" Inherits="CMSApp.CMSFormControls.JsonTable.JsonTableEditor" %>

<style>
    .btn + .btn {
        margin-left: 2px !important;
    }

    .btn-column {
        text-align: center;
        padding: 3px;
    }

    .btn-hidden {
        display: none !important;
    }

    a.btn-table-controls {
        color: black;
        padding-right: 0px !important;
        margin-right: 0px !important;
    }

        a.btn-table-controls:focus,
        a.btn-table-controls:hover {
            color: #0f6194;
        }

    .btn-table-controls.disabled {
        color: black;
        opacity: .3;
        cursor: not-allowed;
        pointer-events: none;
    }

        .btn-table-controls.disabled:hover,
        .btn-table-controls.disabled:focus {
            color: black;
        }

    .btn-table-controls .icon-bin {
        color: #b12628;
    }

    .btn-table-controls .icon-plus {
        color: #497d04;
    }

    .header-label-hidden {
        display: none;
    }

    .header-label {
        color: #b12628;
        display: block !important;
    }

    .cell-warning {
        border: 5px solid #b12628 !important;
    }

    .checkbox-hidden {
        display: none;
    }

    .div-hidden {
        display: none;
    }

    #DynamicTable .table {
        width: auto;
    }

        #DynamicTable .table tr td {
            vertical-align: middle !important;
        }

        #DynamicTable .table th {
            background: #E5E5E5;
        }

        #DynamicTable .table tr:nth-child(odd) td {
            background: #D0E8ED;
        }

        #DynamicTable .table tr td:first-child,
        #DynamicTable .table tr th:first-child {
            padding-left: 8px;
        }

    #DynamicTable .form-control {
        margin-top: 5px;
        margin-bottom: 5px;
        width: auto;
    }
</style>
<div id="DynamicTable">
    <input type="hidden" id="percentCk" runat="server" />
    <input type="hidden" id="json" runat="server" />
    <table id="table" class="table table-striped"></table>
    <asp:HiddenField ID="errorField" runat="server" Value="" />
</div>

<script type="text/javascript">
    var jsonVal = $cmsj('#<%=json.ClientID%>').val();
    jsonVal = jsonVal.replace(/&quot;/g, '"');
    var myList = JSON.parse(jsonVal);

    // Builds the HTML Table out of myList.
    function buildHtmlTable(selector) {

        jsonVal = $cmsj('#<%=json.ClientID%>').val();
        jsonVal = jsonVal.replace(/&quot;/g, '"');
        myList = JSON.parse(jsonVal);

        var columns = addAllColumnHeaders(myList, selector);

        for (var i = 0; i < myList.length; i++) {
            var row$cmsj = $cmsj('<tr/>');
            for (var colIndex = 0; colIndex < columns.length; colIndex++) {
                var cellValue = myList[i][columns[colIndex]];
                try {
                    var cellValDec = decodeURIComponent(cellValue);
                }
                catch (err) {
                    console.log("Cell value not an encoded URI")
                }
                if (cellValue == null) cellValue = "";
                var cellLocation = "r" + i + "c" + colIndex;
                row$cmsj.append($cmsj('<td/>').html('<textarea id="' + cellLocation + '" rows="1" oninput="cellInput(this)" onchange="updateTable(this)" class="form-control auto-height">' + cellValDec + '</textarea>'));
            }
            var checkBox = '<input class="checkbox-hidden" type="checkbox" id="ck' + i + '" value="' + i + '" name="row" />';
            var upArrow = '<a class="btn-table-controls" href=\'javascript:buttonClick("up' + i + '");\'><i class="icon-chevron-up" aria-hidden="true"></i></a>';
            var downArrow = '<a class="btn-table-controls" href=\'javascript:buttonClick("down' + i + '");\'><i class="icon-chevron-down" aria-hidden="true"></i></a>';
            var upArrowDisabled = '<a class="btn-table-controls disabled" href=\'javascript:void(0);\' disabled tabindex="-1"><i class="icon-chevron-up" aria-hidden="true"></i></a>';
            var downArrowDisabled = '<a class="btn-table-controls disabled" href=\'javascript:void(0);\' disabled tabindex="-1"><i class="icon-chevron-down" aria-hidden="true"></i></a>';
            var addRow = '<a class="btn-table-controls" href=\'javascript:buttonClick("insertRow' + i + '");\'><i class="icon-plus" aria-hidden="true"></i></a>';
            var deleteRow = '<a class=" btn-table-controls" href=\'javascript:buttonClick("deleteRow' + i + '");\'><i class="icon-bin" aria-hidden="true"></i></a>';
            var deleteRowDisabled = '<a class=" btn-table-controls disabled" href=\'javascript:buttonClick("deleteRow' + i + '");\'><i class="icon-bin" aria-hidden="true"></i></a>';

            if (i === 0) {
                row$cmsj.append($cmsj('<td/>').html(checkBox + upArrowDisabled));
                if (myList.length == 1) { row$cmsj.append($cmsj('<td/>').html(downArrowDisabled)); }
                else { row$cmsj.append($cmsj('<td/>').html(downArrow)); }
                row$cmsj.append($cmsj('<td/>').html(addRow));
                if (myList.length == 1) { row$cmsj.append($cmsj('<td/>').html(deleteRowDisabled)); }
                else { row$cmsj.append($cmsj('<td/>').html(deleteRow)); }
            }
            else if (i === myList.length - 1) {
                row$cmsj.append($cmsj('<td/>').html(checkBox + upArrow));
                row$cmsj.append($cmsj('<td/>').html(downArrowDisabled));
                row$cmsj.append($cmsj('<td/>').html(addRow));
                row$cmsj.append($cmsj('<td/>').html(deleteRow));
            }
            else {
                row$cmsj.append($cmsj('<td/>').html(checkBox + upArrow));
                row$cmsj.append($cmsj('<td/>').html(downArrow));
                row$cmsj.append($cmsj('<td/>').html(addRow));
                row$cmsj.append($cmsj('<td/>').html(deleteRow));
            }
            $cmsj(selector).append(row$cmsj);
        }

        // check necessary checkboxes
        var pctCkVal = $cmsj('#<%=percentCk.ClientID%>').val();
        if (pctCkVal != "") {
            ckValArray = pctCkVal.split(",");
            $cmsj.each(ckValArray, function (index, value) {
                var ckId = "#percent" + value;
                $cmsj(ckId).prop('checked', true);
            });
        }
    }

    // Adds a header row to the table and returns the set of columns.
    // Need to do union of keys from all records as some records may not contain
    // all records.
    function addAllColumnHeaders(myList, selector) {
        var columnSet = [];
        var headerTr$cmsj = $cmsj('<tr/>');

        var cell = 0;
        for (var i = 0; i < myList.length; i++) {
            var rowHash = myList[i];
            for (var key in rowHash) {
                if ($cmsj.inArray(key, columnSet) == -1) {
                    var keyDecoded = "";
                    try {
                        keyDecoded = decodeURIComponent(key);
                    }
                    catch (err) {
                        keyDecoded = key;
                    }
                    var cellID = "h" + cell;
                    if (keyDecoded == cellID) {
                        keyDecoded = "";
                    }
                    var textInput = '<span class="resizeable-input"><textarea class="header form-control auto-height" rows="1" id="h' + cell + '" oninput="cellInput(this)" onchange="updateTable(this)">' + keyDecoded + '</textarea>';
                    var textLabel = '<label class="header-label-hidden" id="h' + cell + 'label" for="h' + cell + '" style="color: red;">&nbsp</label>';
                    var checkBox = '<input class="checkbox-hidden" type="checkbox" id="col' + cell + '" value="' + cell + '" name="column" />';
                    var leftArrow = '<a class="btn-table-controls" id="left' + cell + '" href=\'javascript:buttonClick("left' + cell + '");\'><i class="icon-chevron-left" aria-hidden="true"></i></a>';
                    var rightArrow = '<a class="btn-table-controls" id="right' + cell + '" href=\'javascript:buttonClick("right' + cell + '");\'><i class="icon-chevron-right" aria-hidden="true"></i></a>';
                    var addColumn = '<a class="btn-table-controls" id="insert' + cell + '" href=\'javascript:buttonClick("insertColumn' + cell + '");\'><i class="icon-plus" aria-hidden="true"></i></a>';
                    var deleteColumn = '<a class="btn-table-controls icon-style-critical icon-only" id="delete' + cell + '" href=\'javascript:buttonClick("deleteColumn' + cell + '");\'><i class="icon-bin" aria-hidden="true"></i></a>';
                    var percentCheckbox = '<input class="btn-table-controls" type="checkbox" id="percent' + cell + '" value="' + cell + '" onchange=\'percentCheck("' + cell + '")\' name="percent" title="Add percent sign to column values" /><label for="percent' + cell + '">&nbsp;<i class="icon-percent-sign" aria-hidden="true"></i></label>'
                    var colControl = '<th id="th' + cell + '">' + textInput + textLabel + checkBox + "<br /><div class='btn-column'>" + leftArrow + rightArrow + addColumn + deleteColumn + percentCheckbox + '</div></th>';
                    columnSet.push(key);
                    headerTr$cmsj.append(colControl);
                    cell++;
                }
            }
        }
        headerTr$cmsj.append('<th colspan="4"><label class="header-label-hidden" id="hlabel"></label></th>');
        $cmsj(selector).append(headerTr$cmsj);

        // Disable buttons from first and last columns
        $cmsj('#left0').addClass('disabled').attr({ 'href': 'javascript:void(0)', 'tabindex': '-1' });
        if (columnSet.length == 1) {
            $cmsj('#delete0').addClass('disabled').attr({ 'href': 'javascript:void(0)', 'tabindex': '-1' });
        }
        var lastRight = "";
        lastRight = '#right' + (columnSet.length - 1).toString();
        $cmsj(lastRight).addClass('disabled').attr({ 'href': 'javascript:void(0)', 'tabindex': '-1' });



        return columnSet;
    }

    $cmsj(document).ready(buildHtmlTable('#table'));

</script>
<%-- table control js --%>
<script type="text/javascript">
    function buttonClick(button) {
        var idx = "";
        var dir = "";
        var ckBox = "";
        switch (button.substring(0, 2)) {
            case 'up':
                idx = button.substring(2);
                dir = "up";
                ckBox = "ck" + idx;
                break;
            case 'do':
                idx = button.substring(4);
                dir = "down";
                ckBox = "ck" + idx;
                break;
            case 'le':
                idx = button.substring(4);
                dir = "left"
                ckBox = "col" + idx;
                break;
            case 'ri':
                idx = button.substring(5);
                dir = "right";
                ckBox = "col" + idx;
                break;
            case 'in':
                rowOrColumn = button.substring(6);
                if (rowOrColumn.substring(0, 1) === 'R') {
                    idx = button.substring(9);
                    ckBox = "ck" + idx;
                }
                else {
                    idx = button.substring(12);
                    ckBox = "col" + idx;
                }
                dir = "insert";
                break;
            case 'de':
                rowOrColumn = button.substring(6);
                if (rowOrColumn.substring(0, 1) === 'R') {
                    idx = button.substring(9);
                    ckBox = "ck" + idx;
                }
                else {
                    idx = button.substring(12);
                    ckBox = "col" + idx;
                }
                dir = "delete";
                break;
            default:
                break;
        }
        document.getElementById(ckBox).checked = true;

        switch (dir) {
            case 'up':
                moveUp(ckBox);
                break;
            case 'down':
                moveDown(ckBox);
                break;
            case 'left':
                moveLeft(ckBox);
                break;
            case 'right':
                moveRight(ckBox);
                break;
            case 'insert':
                if (ckBox.substring(0, 2) === 'ck') { insertRow(ckBox); }
                else { insertCol(ckBox); }
                break;
            case 'delete':
                if (ckBox.substring(0, 2) === 'ck') { deleteRow(ckBox); }
                else { deleteCol(ckBox); }
                break;
            default:
                break;
        }
    };
    function moveUp(ckBox) {
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);

        var toMove = Number.parseInt(ckBox.substring(2));
        // remove with splice
        var removed = jsonArray.splice(toMove, 1);
        // add back in with splice
        var moveTo = toMove - 1;
        jsonArray.splice(moveTo, 0, removed);
        var newJsonVal = "[";
        for (var x = 0; x < jsonArray.length; x++) {
            if (x === moveTo) {
                var jsonValue = JSON.stringify(jsonArray[x]).substring(1);
                jsonValue = jsonValue.substring(0, jsonValue.length - 1);
                newJsonVal += jsonValue;
            }
            else {
                newJsonVal += JSON.stringify(jsonArray[x]);
            }
            if (x != jsonArray.length - 1) {
                newJsonVal += ",";
            }
            else {
                newJsonVal += "]";
            }
        }

        var jsonString = newJsonVal;
        $cmsj('#<%=json.ClientID%>').val(jsonString);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };

    function moveDown(ckBox) {
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        var toMove = Number.parseInt(ckBox.substring(2));
        // remove with splice
        var removed = jsonArray.splice(toMove, 1);
        // add back in with splice
        var moveTo = toMove + 1;
        jsonArray.splice(moveTo, 0, removed);
        var newJsonVal = "[";
        for (var x = 0; x < jsonArray.length; x++) {
            if (x === moveTo) {
                var jsonValue = JSON.stringify(jsonArray[x]).substring(1);
                jsonValue = jsonValue.substring(0, jsonValue.length - 1);
                newJsonVal += jsonValue;
            }
            else {
                newJsonVal += JSON.stringify(jsonArray[x]);
            }
            if (x != jsonArray.length - 1) {
                newJsonVal += ",";
            }
            else {
                newJsonVal += "]";
            }
        }
        var jsonString = newJsonVal;
        $cmsj('#<%=json.ClientID%>').val(jsonString);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };

    function moveLeft(ckBox) {
        // ckBox will be "col#"
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        var toMove = Number.parseInt(ckBox.substring(3));
        var moveTo = toMove - 1;
        var columns = [];
        // get column names
        var rowArray = $cmsj.parseJSON(JSON.stringify(jsonArray[0]));

        for (var i in rowArray) {
            columns.push(i);
        }
        //columns[toMove] is the column name that is moving
        // loop thru the array
        var rowArray = [];

        for (var obj in jsonArray) {
            var toMoveColumn = "";
            var preColumn = [];
            var postColumn = [];
            var jstring = JSON.stringify(jsonArray[obj]);

            // split string and remove curly braces
            var prepstarray = jstring.substring(1, jstring.length - 1);
            var starray = prepstarray.split(',');

            toMoveColumn = starray[toMove];
            for (var x = 0; x < starray.length; x++) {
                if (x < moveTo) {
                    preColumn.push(starray[x]);
                }
                if (x === moveTo || x > toMove) {
                    postColumn.push(starray[x]);
                }
            }

            var row = "";
            if (preColumn.length > 0) {
                row += preColumn.join(',') + ",";
            }
            row += toMoveColumn + ",";
            row += postColumn.join(',');
            rowArray.push(row);
        }

        // rowArray should now contain the correct order of the needed json
        // just need to format it correctly before saving back to the json value
        var jsonString = "[";
        for (x = 0; x < rowArray.length; x++) {
            jsonString += "{" + rowArray[x] + "},";
        }
        jsonString = jsonString.substring(0, jsonString.length - 1);
        jsonString += "]";
        $cmsj('#<%=json.ClientID%>').val(jsonString);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };

    function moveRight(ckBox) {
        // ckBox will be "col#"
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        var toMove = Number.parseInt(ckBox.substring(3));
        var moveTo = toMove + 1;
        var columns = [];
        // get column names
        var rowArray = $cmsj.parseJSON(JSON.stringify(jsonArray[0]));

        for (var i in rowArray) {
            columns.push(i);
        }
        //columns[toMove] is the column name that is moving
        // loop thru the array
        var rowArray = [];

        for (var obj in jsonArray) {
            var toMoveColumn = "";
            var preColumn = [];
            var postColumn = [];
            // jsonArray[obj] > {"new column":"new row","new column1":"1"}
            var jstring = JSON.stringify(jsonArray[obj]);

            // split string and remove curly braces
            var prepstarray = jstring.substring(1, jstring.length - 1);
            var starray = prepstarray.split(',');

            toMoveColumn = starray[toMove];
            for (var x = 0; x < starray.length; x++) {
                if (x < toMove || x === moveTo) {
                    preColumn.push(starray[x]);
                }
                if (x > moveTo) {
                    postColumn.push(starray[x]);
                }
            }

            var row = "";
            row += preColumn.join(',') + ",";
            row += toMoveColumn;
            if (postColumn.length > 0) {
                row += "," + postColumn.join(',');
            }
            rowArray.push(row);
        }

        // rowArray should now contain the correct order of the needed json
        // just need to format it correctly before saving back to the json value
        var jsonString = "[";
        for (x = 0; x < rowArray.length; x++) {
            jsonString += "{" + rowArray[x] + "},";
        }
        jsonString = jsonString.substring(0, jsonString.length - 1);
        jsonString += "]";
        $cmsj('#<%=json.ClientID%>').val(jsonString);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };

    function insertRow(ckBox) {
        // ckBox will be "ck#"
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        var ckRow = Number.parseInt(ckBox.substring(2));
        var addTo = ckRow + 1;
        var columns = [];
        // get column names
        var rowArray = $cmsj.parseJSON(JSON.stringify(jsonArray[0]));
        for (var i in rowArray) {
            columns.push(i);
        }
        // build string for new row
        var newRow = "{";
        for (var col in columns) {
            newRow += "\"" + columns[col] + "\":\"\",";
        }
        newRow = newRow.substring(0, newRow.length - 1);
        newRow += "}";
        jsonArray.splice(addTo, 0, newRow);
        var newJsonVal = "[";
        for (var x = 0; x < jsonArray.length; x++) {
            if (x === moveTo) {
                var jsonValue = JSON.stringify(jsonArray[x]).substring(1);
                jsonValue = jsonValue.substring(0, jsonValue.length - 1);
                newJsonVal += jsonValue;
            }
            else {
                newJsonVal += JSON.stringify(jsonArray[x]);
            }
            if (x != jsonArray.length - 1) {
                newJsonVal += ",";
            }
            else {
                newJsonVal += "]";
            }
        }

        var jsonString = newJsonVal.replace(/\\/g, '');
        jsonString = jsonString.replace("\"{", "{").replace("}\"", "}");
        $cmsj('#<%=json.ClientID%>').val(jsonString);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };

    function deleteRow(ckBox) {
        // ckBox will be "ck#"
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        var ckRow = Number.parseInt(ckBox.substring(2));
        jsonArray.splice(ckRow, 1);

        var newJsonVal = "[";
        for (var x = 0; x < jsonArray.length; x++) {
            if (x === moveTo) {
                var jsonValue = JSON.stringify(jsonArray[x]).substring(1);
                jsonValue = jsonValue.substring(0, jsonValue.length - 1);
                newJsonVal += jsonValue;
            }
            else {
                newJsonVal += JSON.stringify(jsonArray[x]);
            }
            if (x != jsonArray.length - 1) {
                newJsonVal += ",";
            }
            else {
                newJsonVal += "]";
            }
        }

        $cmsj('#<%=json.ClientID%>').val(newJsonVal);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };

    function insertCol(ckBox) {
        // ckBox will be "col#"
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        var addAfter = Number.parseInt(ckBox.substring(3));
        var columns = [];
        // get column names
        var rowArray = $cmsj.parseJSON(JSON.stringify(jsonArray[0]));

        var nextColNum = 0;
        for (var i in rowArray) {
            columns.push(i);
            var decoded = decodeURIComponent(i);
            if (decoded.substring(0, 10) === "New Column") {
                if (decoded.length == 10) {
                    nextColNum = 1;
                }
                else {
                    var currentColNum = Number.parseInt(decoded.substring(10));
                    if (currentColNum >= nextColNum) {
                        nextColNum = currentColNum + 1;
                    }
                }
            }
        }
        var newColName = "New Column";
        if (nextColNum > 0) {
            newColName = newColName + nextColNum;
        }
        var newColNameEnc = encodeURIComponent(newColName);
        var newColumn = "\"" + newColNameEnc + "\":\"\"";
        var newJson = [];
        for (var y = 0; y < jsonArray.length; y++) {
            var jRow = JSON.stringify(jsonArray[y]);
            jRow = jRow.replace("{", "").replace("}", "");
            var jRowArray = jRow.split(',');
            for (var r = 0; r < jRowArray.length; r++) {
                if (r === addAfter) {
                    newJson.push(jRowArray[r]);
                    newJson.push(newColumn);
                }
                else {
                    newJson.push(jRowArray[r]);
                }
            }
        }
        // build the row strings from the newJson array
        var columnCount = columns.length + 1;
        var jsonRows = [];
        for (var n = 0; n < newJson.length; n = n + columnCount) {
            var z = n;
            var whileCount = n + columnCount;
            var currentRow = "{";
            while (z != whileCount) {
                currentRow += newJson[z] + ",";
                z++;
            }
            currentRow = currentRow.substring(0, currentRow.length - 1);
            currentRow += "}";
            jsonRows.push(currentRow);
        }
        var newJsonVal = "[" + jsonRows.join(',') + "]";
        $cmsj('#<%=json.ClientID%>').val(newJsonVal);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };

    function deleteCol(ckBox) {
        // ckBox will be "col#"
        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        var delCol = Number.parseInt(ckBox.substring(3));
        var columns = [];
        // get column names
        var rowArray = $cmsj.parseJSON(JSON.stringify(jsonArray[0]));
        for (var i in rowArray) {
            columns.push(i);
        }
        // go thru the array and get all data except the deleted column
        var newJson = [];
        for (var y = 0; y < jsonArray.length; y++) {
            var jRow = JSON.stringify(jsonArray[y]);
            jRow = jRow.replace("{", "").replace("}", "");
            var jRowArray = jRow.split(',');
            for (var r = 0; r < jRowArray.length; r++) {
                if (r != delCol) {
                    newJson.push(jRowArray[r]);
                }
            }
        }
        // build the row strings from the newJson array
        var columnCount = columns.length - 1;
        var jsonRows = [];
        for (var n = 0; n < newJson.length; n = n + columnCount) {
            var z = n;
            var whileCount = n + columnCount;
            var currentRow = "{";
            while (z != whileCount) {
                currentRow += newJson[z] + ",";
                z++;
            }
            currentRow = currentRow.substring(0, currentRow.length - 1);
            currentRow += "}";
            jsonRows.push(currentRow);
        }
        var newJsonVal = "[" + jsonRows.join(',') + "]";
        $cmsj('#<%=json.ClientID%>').val(newJsonVal);
        $cmsj("#table").empty();
        buildHtmlTable('#table');
    };
</script>
<%-- validation js --%>
<script type="text/javascript">
    function cellInput(cell) {
        //debugger;
        // get hidden field for future use
        var errorField = $cmsj('#<%=errorField.ClientID%>');
        var errorText = "";
        var newText = cell.value;
        // test for special chars
        var pattern = new RegExp(/['\\]/g);
        var foundChars = false;
        if (pattern.test(newText)) {
            foundChars = true;
        }
        if (foundChars) {
            // show warning and highlight cell
            errorText = "Illegal<br />characters";
            $cmsj(cell).addClass("cell-warning");
            $cmsj("#hlabel").removeClass("header-label-hidden").addClass("header-label").html(errorText);
            errorField.val(errorText);
            return false;
        }

        var jsonValue = $cmsj('#<%=json.ClientID%>').val();
        jsonValue = jsonValue.replace(/&quot;/g, '"');
        var jsonArray = $cmsj.parseJSON(jsonValue);
        // columns for columncount later
        // get column names
        var columns = [];
        var rowArray = $cmsj.parseJSON(JSON.stringify(jsonArray[0]));
        for (var i in rowArray) {
            columns.push(i);
        }
        var dupeCol = false;
        for (var x = 0; x < columns.length; x++) {
            if (columns[x] == newText) {
                dupeCol = true;
            }
        }
        if (dupeCol) {
            // show warning and highlight cell
            errorText = "Duplicate<br />headers";
            $cmsj(cell).addClass("cell-warning");
            $cmsj("#hlabel").removeClass("header-label-hidden").addClass("header-label").html("Duplicate<br />headers");
            errorField.val(errorText);
        }
        if (!dupeCol && !foundChars) {
            // clear warning and highlight cell
            $cmsj(cell).removeClass("cell-warning");
            // check for any other cell warnings before removing hlabel warning
            var clearLabel = true;
            $cmsj(".cell-warning").each(function () {
                clearLabel = false;
            });
            if (clearLabel) {
                errorField.val("");
                $cmsj("#hlabel").removeClass("header-label").addClass("header-label-hidden").html("");
            }
        }
    }
    function updateTable(box) {
        //debugger;
        var cellLocation = box.id;
        var newText = box.value;
        // need to encode newText to elimiate special characters breaking things
        // https://www.w3schools.com/jsref/jsref_encodeuricomponent.asp
        // will also need to decode before building table
        var newTextEnc = encodeURIComponent(newText);
        // check for cell-warning class and focus on it
        var stopProcess = false;
        $cmsj(".cell-warning").each(function () {
            stopProcess = true;
            $cmsj(this).focus();
            return false;
        });

        if (!stopProcess) {
            var cLoc = cellLocation.indexOf("c");
            // get current json
            var jsonValue = $cmsj('#<%=json.ClientID%>').val();
            jsonValue = jsonValue.replace(/&quot;/g, '"');
            var jsonArray = $cmsj.parseJSON(jsonValue);
            // columns for columncount later
            // get column names
            var columns = [];
            var rowArray = $cmsj.parseJSON(JSON.stringify(jsonArray[0]));
            for (var i in rowArray) {
                columns.push(i);
            }
            var contProcess = true;
            if (cLoc >= 0) {
                var row = Number.parseInt(cellLocation.substring(1, cLoc));
                var col = Number.parseInt(cellLocation.substring(cLoc + 1));
                // loop thru array and change value
                var newJson = [];
                for (var y = 0; y < jsonArray.length; y++) {
                    var jRow = JSON.stringify(jsonArray[y]);
                    jRow = jRow.replace("{", "").replace("}", "");
                    var jRowArray = jRow.split(',');
                    for (var r = 0; r < jRowArray.length; r++) {
                        if (r === col && y === row) {
                            // replace old value with new
                            var oldVal = jRowArray[r].split(':');
                            var newVal = oldVal[0] + ":\"" + newTextEnc + "\"";
                            newJson.push(newVal);
                        }
                        else { newJson.push(jRowArray[r]); }
                    }
                }

                // build the row strings from the newJson array
                var columnCount = columns.length;
                var jsonRows = [];
                for (var n = 0; n < newJson.length; n = n + columnCount) {
                    var z = n;
                    var whileCount = n + columnCount;
                    var currentRow = "{";
                    while (z != whileCount) {
                        currentRow += newJson[z] + ",";
                        z++;
                    }
                    currentRow = currentRow.substring(0, currentRow.length - 1);
                    currentRow += "}";
                    jsonRows.push(currentRow);
                }
                var newJsonVal = "[" + jsonRows.join(',') + "]";
                $cmsj('#<%=json.ClientID%>').val(newJsonVal);
                $cmsj("#table").empty();
                buildHtmlTable('#table');
                // set focus to next cell
                var newEl = null;
                if (col < columnCount - 1) {
                    var newCol = col + 1;
                    var newCell = "r" + row + "c" + newCol;
                    newEl = document.getElementById(newCell);
                } else {
                    var newEl = null;
                    if (row < jsonArray.length - 1) {
                        var newRow = row + 1;
                        var newCell = "r" + newRow + "c0";
                        newEl = document.getElementById(newCell);
                    } else {
                        newEl = document.getElementById(cellLocation);
                    }
                }
                newEl.focus();
                var val = newEl.value;
                newEl.value = '';
                newEl.value = val;
            }
            else {
                // header being changed
                // cellLocation will be "h0", "h1", etc
                // get header index
                var hIdx = Number.parseInt(cellLocation.substring(1));
                // need to validate that column is not the same as another column
                for (var c = 0; c < columns.length; c++) {
                    if (c != hIdx) {
                        var colDec = decodeURIComponent(columns[c]);
                        if (colDec == newText) {
                            alert("Two columns cannot have the same label!");

                            // set focus to current cell
                            contProcess = false;
                            document.getElementById(cellLocation).focus();
                            return false;
                        }
                    }
                }
                if (contProcess == true) {
                    // go thru the array, get all data, change header when necessary
                    var newJson = [];
                    for (var y = 0; y < jsonArray.length; y++) {
                        var jRow = JSON.stringify(jsonArray[y]);
                        jRow = jRow.replace("{", "").replace("}", "");
                        var jRowArray = jRow.split(',');
                        for (var r = 0; r < jRowArray.length; r++) {
                            if (r != hIdx) {
                                newJson.push(jRowArray[r]);
                            }
                            else {
                                //change column name
                                //jRowArray = "columnname":"rowdata"
                                var midIdx = jRowArray[r].indexOf(":");
                                var newData = "\"" + newTextEnc + "\"" + jRowArray[r].substring(midIdx);
                                newJson.push(newData);
                            }
                        }
                    }
                    // build the row strings from the newJson array
                    var columnCount = columns.length;
                    var jsonRows = [];
                    for (var n = 0; n < newJson.length; n = n + columnCount) {
                        var z = n;
                        var whileCount = n + columnCount;
                        var currentRow = "{";
                        while (z != whileCount) {
                            currentRow += newJson[z] + ",";
                            z++;
                        }
                        currentRow = currentRow.substring(0, currentRow.length - 1);
                        currentRow += "}";
                        jsonRows.push(currentRow);
                    }
                    var newJsonVal = "[" + jsonRows.join(',') + "]";
                    $cmsj('#<%=json.ClientID%>').val(newJsonVal);
                    $cmsj("#table").empty();
                    buildHtmlTable('#table');

                    // set focus to next cell
                    var newEl = null;
                    if (hIdx < columnCount - 1) {
                        var newCol = hIdx + 1;
                        var newCell = "h" + newCol;
                        newEl = document.getElementById(newCell);
                    } else {
                        var newEl = null;
                        var newCell = "r0c0";
                        newEl = document.getElementById(newCell);
                    }
                    newEl.focus();
                    var val = newEl.value;
                    newEl.value = '';
                    newEl.value = val;
                }
            }
        }
    };
</script>
<%-- textarea size js --%>
<script>
    // auto resize at page load - not sure we want this. some html can get very long
    //$cmsj(document).ready(function () {
    //    $cmsj('textarea.auto-height').each(function () {
    //        $cmsj(this).height('auto').height(this.scrollHeight);
    //    });
    //});
    $cmsj(document).on('input', 'textarea.auto-height', function () {
        $cmsj(this).height('auto').height(this.scrollHeight);
    });
    $cmsj('textarea').on('input', function () {
        $cmsj(this).height('auto').height(this.scrollHeight);
    });
</script>
<%-- Percent checkbox controls --%>
<script type="text/javascript">
    function percentCheck(column) {
        // column is the table column number only
        var ckboxID = "percent" + column;
        var pctCk = $cmsj('#<%=percentCk.ClientID%>');
        var ckVal = pctCk.val();
        if ($cmsj('#' + ckboxID).is(":checked")) {
            // checked
            // add value of column to whatever value is currently in percentCk hidden input
            // make it a comma separated field, if possible. if not, use a -

            // get value of percentCk first
            if (ckVal == "") {
                pctCk.val(column);
            } else {
                // check to see if column is already in the percentCk
                var ckValArray = ckVal.split(',');
                if ($cmsj.inArray(column, ckValArray) == -1) {
                    var newCkVal = ckVal + "," + column;
                    pctCk.val(newCkVal);
                }
            }

            //alert("column " + column + " has been checked");
        } else {
            // unchecked
            // remove column value from percentCk val
            if (ckVal != "") {
                var ckValArray = ckVal.split(",");
                var colIdx = $cmsj.inArray(column, ckValArray);
                if (colIdx >= 0) {
                    ckValArray.splice(colIdx, 1);
                    pctCk.val(ckValArray);
                }
            }


            //alert("column " + column + " has been unchecked");
        }
    }
</script>
