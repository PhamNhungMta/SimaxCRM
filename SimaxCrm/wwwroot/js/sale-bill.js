var saleBill = {
    init: function (callback) {
        //saleBill.getAllProducts(function () {
        saleBill.grid.addRow();
        saleBill.grid.addRow();
        saleBill.grid.addRow();
        saleBill.grid.addRow();
        saleBill.grid.addRow();
        callback();
        //});
    },

    variable: {
        productList: [],
        productTaxList: [],
        deletedRaw: [],
        varLocale: function () {
            return $("#Locale").val() || "";
        },
        gridHtml: '<tr id="grid_raw_[[id]]">' +
            '<td>' +
            '<input value="0" id="grid_id_[[id]]" type="hidden" />' +
            '<input value="1" id="grid_action_[[id]]" type="hidden" />' +
            '<input class="no-border-select form-control" style="width:100%;text-align: left" id="grid_product_[[id]]" type="text" />' +
            '</select>' +
            '</td>' +
            '<td><input min="0" class="no-border-select form-control" style="width:100%;" value="0" id="grid_qty_[[id]]" type="number" onchange="saleBill.grid.grid_change([[id]])" /></td>' +
            '<td><input min="0" class="no-border-select form-control" style="width:100%;" value="0" id="grid_price_[[id]]" type="number" onchange="saleBill.grid.grid_change([[id]])" /></td>' +
            '<td id="grid_amount_[[id]]" style="text-align:center"></td>' +
            '<td>' +
            '<a href="javascript:saleBill.grid.grid_delete([[id]])" class="btn btn-sm btn-danger"><i class="nav-icon icon-trash"> </i></a>' +
            '<a style="margin-left:5px" href="javascript:saleBill.grid.addRow()" class="btn btn-sm btn-success"><i class="nav-icon icon-plus"> </i></a>' +
            '</td>' +
            '</tr>',
    },

    //getAllProducts: function (callback) {
    //    saleBill.variable.productList = [];
    //    ajaxCall("/Admin/Invoice/AllProducts", "GET", null, function (data) {
    //        if (data) {
    //            saleBill.variable.productList = data;
    //        }
    //        if (callback) {
    //            callback();
    //        }
    //    });
    //},

    populateDropdown: function (data, id, name) {
        var html = "<option value=''></option>";
        $.each(data, function (index, item) {
            html += '<option value="' + item[id] + '">' + item[name] + '</option>';
        });
        return html;
    },

    grid: {
        grid_delete: function (id) {
            if (confirm("Do you want to delete selected raw?")) {
                var rec_id = parseInt($("#grid_id_" + id).val());
                if (rec_id > 0) {
                    saleBill.variable.deletedRaw.push({
                        id: $("#grid_id_" + id).val(),
                        actionType: 3,
                        productName: $("#grid_product_" + id).val(),
                        qty: $("#grid_qty_" + id).val(),
                        price: $("#grid_price_" + id).val(),
                        amount: $("#grid_amount_" + id).html(),
                    })
                }
                $("#grid_raw_" + id).remove();
            }
            saleBill.bottomCalculation();
        },

        grid_change: function (id, colIdx) {
            var productid = $("#grid_product_" + id).val();

            //var productData = saleBill.variable.productList.filter(function (e) {
            //    return e.id == productid;
            //});

            //if (productData.length > 0) {
            //    var productItem = productData[0];

            //    var price = 0;
            //    if (colIdx == 0) {
            //        price = productItem.price || "0";
            //    }
            //    else {
            price = parseFloat($("#grid_price_" + id).val() || "0");
            //}

            var qty = $("#grid_qty_" + id).val() || "0";
            var amount = parseFloat(qty) * parseFloat(price);

            $("#grid_price_" + id).val(price);
            $("#grid_amount_" + id).html(amount.toFixed(2));
            //}
            //else {
            //    price = "0";
            //    qty = $("#grid_qty_" + id).val() || "0";
            //    amount = parseFloat(qty) * parseFloat(price);

            //    $("#grid_price_" + id).val(price);
            //    $("#grid_amount_" + id).html(amount.toFixed(2));
            //}
            saleBill.bottomCalculation();
        },

        getLastGridIndex: function () {
            return $("#gridData tr").length;
        },

        addRow: function () {
            var id = saleBill.grid.getLastGridIndex();
            var html = saleBill.variable.gridHtml.replace(/\[\[id]]/g, id);
            $("#gridData").append(html);

            var productHtml = saleBill.populateDropdown(saleBill.variable.productList, "id", "name");
            $("#grid_product_" + id).html(productHtml);
        },

        fillGridRowsFromDB: function (invoiceDetail) {
            $("#gridData tr").each(function (i, v) {
                var id = v.id.split('_')[2];
                $("#grid_raw_" + id).remove();
            });

            $.each(invoiceDetail, function (id, v) {
                saleBill.grid.addRow();
                $("#grid_id_" + id).val(v.id);
                $("#grid_action_" + id).val(2);
                $("#grid_product_" + id).val(v.productName);
                $("#grid_qty_" + id).val(v.qty);
                $("#grid_price_" + id).val(v.price);
                $("#grid_amount_" + id).html(v.amount);
            });
            saleBill.grid.addRow();
        }
    },

    changeTaxDecision: function () {
        $("#gridData tr").each(function (i, v) {
            var id = v.id.split('_')[2];
            if ($("#grid_product_" + id).val()) {
                saleBill.grid.grid_change(id);
            }
        })
    },

    bottomCalculation: function () {
        var amount = 0;
        $("#gridData tr").each(function (i, v) {
            var id = v.id.split('_')[2];
            if ($("#grid_product_" + id).val()) {
                amount += parseFloat($("#grid_amount_" + id).html());
            }
        })

        $("#TotalAmount").val(amount.toFixed(2));

        var otherCharges = parseFloat($("#OtherCharges").val() || "0");
        var discountAmount = parseFloat($("#DiscountAmount").val() || "0");
        var taxPercent = parseFloat($("#TaxPercent").val() || "0");
        var taxAmount = (amount * taxPercent) / 100;
        var grandTotal = amount + taxAmount + otherCharges - discountAmount;
        $("#TaxAmount").val(taxAmount.toFixed(2));
        $("#GrandTotal").val(grandTotal.toFixed(2));
    },

    bindMissedData: function () {
        var detail = [];
        $("#gridData tr").each(function (i, v) {
            var id = v.id.split('_')[2];
            if ($("#grid_product_" + id).val()) {
                detail.push({
                    id: $("#grid_id_" + id).val(),
                    actionType: $("#grid_action_" + id).val(),
                    productName: $("#grid_product_" + id).val() || 0,
                    qty: $("#grid_qty_" + id).val() || 0,
                    price: $("#grid_price_" + id).val() || 0,
                    amount: $("#grid_amount_" + id).html() || 0,
                })
            }
        })

        for (var i = 0; i < saleBill.variable.deletedRaw.length; i++) {
            detail.push(saleBill.variable.deletedRaw[i]);
        }
        $("#InvoiceDetailJson").val(JSON.stringify(detail));
    },

    update: function (e) {
        e.preventDefault();
        if ($('#formBill').valid()) {
            saleBill.bindMissedData();
            var formData = helper.getFormData($("#formBill"));
            ajaxFormPost($("#formBill").attr('action'), formData, function (data) {
                if (!data.success) {
                    helper.addErrorInForm('divErrorSummary', [data.response]);
                }
                else {
                    $("#btnPrint").show();
                    helper.addSuccessInForm('divErrorSummary', ["Invoice Saved Successfully"]);
                    saleBill.variable.deletedRaw = [];
                    if (data.data) {
                        $("#Id").val(data.data.id);
                        saleBill.grid.fillGridRowsFromDB(data.data.invoiceDetail);
                    }
                }
            });
        }
        else {
            clearMessage('divErrorSummary');
        }
    },

    fillDetail: function (data) {
        if (data) {
            $("#gridData tr").each(function (i, v) {
                var id = v.id.split('_')[2];
                $("#grid_raw_" + id).remove();
            });

            var invoiceDetail = JSON.parse(data);
            saleBill.grid.fillGridRowsFromDB(invoiceDetail);

            $("#btnPrint").show();
        }
    }
}



