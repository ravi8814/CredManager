function fnSaveSate(stateId, PK_CompanyStates)
{
    try {
        //alert($('#chkST' + stateId).is(':checked'));
        debugger;
                var StateDetail = {
                    "PK_States": stateId,
                    "PK_CompanyStates": PK_CompanyStates,
                    "CompanyID": $("#CompanyID").val(),
                    "IsChecked": $('#chkST' + stateId).is(':checked')

                };
                $.ajax({
                    type: "PUT",
                    url:
                    'http://localhost:3959/api/GetState/SaveState/',
                    data: JSON.stringify(StateDetail),
                    contentType: "application/json;charset=utf-8",
                    success: function (data, status, xhr) {
                    if ($('#chkST' + stateId).is(':checked'))
                    {
                        alert("State Added: " + status);
                    }
                    else
                    {
                        alert("State Deleted: " + status);
                    }
                       
                    //alert("The result is : " + status + ": " + data);
                    window.location.reload();
                    },
                    error: function (xhr) {
                        alert(xhr.responseText);
                    }
                });
            

        
    } catch (e) {

    }
}