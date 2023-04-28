/**
 *  Document   : table_data.js
 *  Author     : redstar
 *  Description: advance table page script
 *
 **/

$(document).ready(function() {
	'use strict';
	$('#example1').DataTable( {
		"scrollX": true
	} );

	var table = $('#example2').DataTable( {
		"scrollY": "200px",
		"paging": false
	} );

	$('a.toggle-vis').on( 'click', function (e) {
		e.preventDefault();

		// Get the column API object
		var column = table.column( $(this).attr('data-column') );

		// Toggle the visibility
		column.visible( ! column.visible() );
	} );

	var t = $('#example3').DataTable( {
		"scrollX": true
	} );
	var counter = 1;

	$('#addRow').on( 'click', function () {
		t.row.add( [
		            counter +'.1',
		            counter +'.2',
		            counter +'.3',
		            counter +'.4',
		            counter +'.5'
		            ] ).draw( false );

		counter++;
	} );

	// Automatically add a first row of data
	$('#addRow').click();

	$('#example4').DataTable( {
		"scrollX": true
	} );

	$('#saveStage').DataTable( {
		"scrollX": true,
		stateSave: true
	});


	var table = $('#tableGroup').DataTable({
		"columnDefs": [
		               { "visible": false, "targets": 2 }
		               ],
		               "order": [[ 2, 'asc' ]],
		               "scrollX": true,
		               "displayLength": 25,
		               "drawCallback": function ( settings ) {
		            	   var api = this.api();
		            	   var rows = api.rows( {page:'current'} ).nodes();
		            	   var last=null;

		            	   api.column(2, {page:'current'} ).data().each( function ( group, i ) {
		            		   if ( last !== group ) {
		            			   $(rows).eq( i ).before(
		            					   '<tr class="group"><td colspan="5">'+group+'</td></tr>'
		            			   );

		            			   last = group;
		            		   }
		            	   } );
		               }
	} );

	// Order by the grouping
	$('#tableGroup tbody').on( 'click', 'tr.group', function () {
		var currentOrder = table.order()[0];
		if ( currentOrder[0] === 2 && currentOrder[1] === 'asc' ) {
			table.order( [ 2, 'desc' ] ).draw();
		}
		else {
			table.order( [ 2, 'asc' ] ).draw();
		}
	} );

	$('#exportTable').DataTable( {
		dom: 'Bfrtip',
		buttons: [
		          'copy', 'csv', 'excel', 'pdf', 'print'
		          ]
	} );


	var dataSet = [
	               ["400400", "Wood,Charles", "Medicare Part B","Medicaid", "02/08/2020"],                                                                                                             
                   ["7581", "Marlow, Vera", "Medicare Part B", "Medicaid", "02/08/2020"],
                   ["12345", "Marlow, Vera", "Medicare Part B", "Medicaid", "02/08/2020"],
                   ["6849", "Wheeler, Miriam", "Medicare Part B", "Medicaid", "02/08/2020"],
                   ["68745", "Wheeler, Miriam ", "Medicare Part B", "Medicaid", "02/08/2020"]

	               ];

	$('#dataTable').DataTable( {
		"scrollX": true,
		data: dataSet,
		columns: [
		          { title: "MR" },
		          { title: "Name" },
		          { title: "Auth By" },
		          { title: "DOS" }
		          ]
	} );

	// Child Row table data
	childRowTable();

} );

function childRowTable() {
    $("#wait").css("display", "block");
    var childData;
       $.ajax({
                type: "POST",
                url: "http://mcwdemo.com:8283/api/CCM/GetPatients/",
                data: "[{'ProviderGroupId':'1'}]",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (response)
                  
                {
                    $("#wait").css("display", "none");
                     childData = response;
                  
                     fnAfterPull();

                }
            });
	//var childData =  [
	//                  {
	//                      "id": "1",
    //                      "mr":"400400",
    //                      "name": "Wood,Charles",                          
    //                      "dos": "02/08/2020",
    //                      "address": "156 1/2 GROVE STREET ATHENS",
    //                      "dob": "03/02/1957",
    //                      "age": "63",
    //                      "priIns": "MEDICARE PART B",
    //                      "secIns": "",
    //                      "sex": "Male",
    //                      "comment": "1/5 COMP..//AT"
                         
	//                  },
	//                  {
	//                      "id": "2",
	//                      "mr": "7581",
	//                      "name": "Marlow, Vera",	                     
	//                      "dos": "02/08/2020",
	//                      "address": "156 1/2 GROVE STREET ATHENS",
	//                      "dob": "03/02/1957",
	//                      "age": "63",
	//                      "priIns": "AARP",
	//                      "secIns": "MEDICARE PART B",
	//                      "sex": "Male",
	//                      "comment": "01/02--LVM//DRG"
	//                  },
                       
    //                    {
    //                        "id": "3",
    //                        "mr": "12345",
    //                        "name": "Marlow, Vera",                           
    //                        "dos": "02/08/2020",
    //                        "address": "156 1/2 GROVE STREET ATHENS",
    //                        "dob": "03/02/1957",
    //                        "age": "63",
    //                        "priIns": "MEDICARE PART B",
    //                        "secIns": "AARP",
    //                        "sex": "Male",
    //                        "comment": "01/02--LVM//DRG"
    //                    },
    //                     {
    //                         "id": "4",
    //                         "mr": "6849",
    //                         "name": "Wheeler, Miriam",                            
    //                         "dos": "02/08/2020",
    //                         "address": "156 1/2 GROVE STREET ATHENS",
    //                         "dob": "03/02/1957",
    //                         "age": "63",
    //                         "priIns": "BCBS-PPO",
    //                         "secIns": "MEDICARE PART B",
    //                         "sex": "Male",
    //                         "comment": "01/02--LVM//DRG"
    //                     },

    //                      {
    //                          "id": "5",
    //                          "mr": "68745",
    //                          "name": "Marlow, Vera",                             
    //                          "dos": "02/08/2020",
    //                          "address": "156 1/2 GROVE STREET ATHENS",
    //                          "dob": "03/02/1957",
    //                          "age": "63",
    //                          "priIns": "MEDICARE PART B",
    //                          "secIns": "Medicaid",
    //                          "sex": "Male",
    //                          "comment": "01/02--LVM//DRG"
    //                      }


	//                  ];

	/* Formatting function for row details - modify as you need */
	function format ( d ) {
		// `d` is the original data object for the row
	    return '<div class="border" style="border-radius:10px;background-color:gray;color:white;padding:5px;"><div class="row">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label>Full Name:</label">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label>' + d.PatientName + '</label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label>DOB:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label>' + d.Dob + ' </label></div>' +
            '<div class="row">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label>Sex:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label> ' + d.Sex + '</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label>Age:</label> <label> ' +d.Age + '</label></div>' +
             '<div class="row">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label>Insurance:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label>' + d.PriInsurance + '</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label>address:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label>' + d.HomeAddress + '</label></div></div>';
	    //'<table class="form-group row" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
		//'<tr>'+
		//'<td>Full name:</td>'+
		//'<td>'+d.name+'</td>'+h
		//'</tr>'+
		//'<tr>'+
		//'<td>Address:</td>' +
		//'<td>'+d.address+'</td>'+
		//'</tr>'+
		//'<tr>'+
		//'<td>DOB:</td>'+
		//'<td>'+d.dob+'</td>'+
		//'</tr>' +
        //'<td>Age:</td>' +
		//'<td>' + d.age + '</td>' +
		//'</tr>' +
        //'<td>Insurance:</td>' +
		//'<td>' + d.insurance + '</td>' +
		//'</tr>' +
        //'<td>Sex:</td>' +
		//'<td>' + d.sex + '</td>' +
		//'</tr>' +
		//'</table>';
	}
	
	 


	function fnAfterPull() {
	    
	    var table = $('#chieldRow').DataTable({
	        data: childData,
	       
            
	        "columns": [
                        {

                                             
                            "className":'details-control',
                            "orderable": false,
                            "data": null,
                            "defaultContent": ''
                            
                        },
                        
                        { "data": "AccountNo" },
                        { "data": "PatientName" },
                        { "data": "PriInsurance" },
                        { "data": "ScdInsurance" },
                        { "data": "LastVisit" },
                        { "data": "Comment" },
	                    { "data": "IsAWV" },
	        

                          //{
                          //    data: null, "hidden": false,
                          //    className: "center",
                          //    "orderable": false,
                          //    defaultContent: '<i class="fa fa-times-rectangle"></i><br><i class="fa fa-check-square"></i>'
                          //},
                         //{
                         //    data: null,
                         //    className: "center",
                         //    defaultContent: '<input type="checkbox"/>AWV&nbsp;<br><input type="checkbox"/>ACO&nbsp;</br><input type="checkbox"/>CCM'
                         //}
                        
                         {
                             data: null,
                             className: "center",
                             "orderable": false,
                             defaultContent: '<a href="" class="editor_edit"    data-toggle="modal" data-target="#nxtActionModal" onclick="Actionclick(this)"><i class="fa fa-tree"></i></a>'
                         },
                         {
                             data: null,
                             className: "center",
                             "orderable": false,
                             defaultContent: '<div class="dropdown dropdown-action"> <a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a><div class="dropdown-menu dropdown-menu-right"> <a class="dropdown-item" href="#"><i class="fa fa-bandcamp m-r-5"></i> View</a><a class="dropdown-item" href="#"><i class="fa fa-area-chart m-r-5"></i> Chart</a> <a class="dropdown-item" href="#" data-toggle="modal" data-target="#delete_appointment"><i class="fa fa-commenting m-r-5"></i> SMS</a> <a class="dropdown-item" href="#" data-toggle="modal" data-target="#delete_appointment"><i class="fa fa-phone m-r-5"></i> Call</a><a class="dropdown-item" href="#" data-toggle="modal" data-target="#delete_appointment"><i class="fa fa-trash-o m-r-5"></i> Delete</a> </div>'
                         },
                                 {
                                     "data":"PatientId" , "visible":false
                                     
                                 },


	        ],
	      
	  

	        "bProcessing": true,
	        "aoColumnDefs": [{
	            "targets": 7,
	            "bSortable": false,
	            "mRender": function (data, type, full, meta) {
	                return '<input type="checkbox"  class="minimal"' + (data ? ' checked' : '') + '/>';
	            }
               
	        }],
            
	       
	        "order": [[1, 'asc']]
	    });

	    // Add event listener for opening and closing details
	    $('#chieldRow tbody').on('click', 'td.details-control', function () {
	        var tr = $(this).closest('tr');
	        var row = table.row(tr);

	        if (row.child.isShown()) {
	            // This row is already open - close it
	            row.child.hide();
	            tr.removeClass('shown');
	        }
	        else {
	            // Open this row
	            row.child(format(row.data())).show();
	            tr.addClass('shown');
	        }
           
	    });
	}
}

//$('#myBtn').on('click', 'a.editor_edit', function (e) {
//    e.preventDefault();
//    
        
//          editor.edit($(this).closest('tr'), {
              
//        title: 'Edit record',
//        buttons: 'Update'       
       
//    });
//    $('#myModal').modal('show');
//});

		
function Actionclick(row) {
    
    var tr = $(row).closest('tr');

    var comment = tr.find("td:eq(6)").text();
    var PatientId = tr.find("td:eq(10)").text();
    //selectedIndex = table.row(this).data()[10];
   // alert(table.row(this).data()[10]);
    //alert(selectedIndex);
    alert(PatientId);
    $("#txtcomment").val(comment);   
    $("#hiddenPatientId").val(PatientId);
    
}