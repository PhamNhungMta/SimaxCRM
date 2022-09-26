function ajaxCall(endpoint, type, param, callback, dataType = 'json') {
    $(".ajax-loader").show();
    $.ajax({
        url: window.location.origin + endpoint,
        data: param,
        dataType: dataType,
        type: type,
        success: function (data) {
            $(".ajax-loader").hide();
            callback(data)
        },
        error: function (err) {
            $("#loading").hide();
            $(".ajax-loader").hide();
        }
    })
}

function ajaxFormPost(endpoint, formData, callback, showLoader = true) {
    if (showLoader) {
        $(".ajax-loader").show();
    }
    $.post(endpoint, formData, function (data) {
        $(".ajax-loader").hide();
        callback(data);
    })
        .fail(function (response) {
            $(".ajax-loader").hide();
        });
}

/* JS comes here */
function runSpeechRecognition(txtInput) {
    // get output div reference
    var output = document.getElementById("output");
    // get action element reference
    var action = document.getElementById("action");
    // new speech recognition object
    var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition;
    var recognition = new SpeechRecognition();

    // This runs when the speech recognition service starts
    recognition.onstart = function () {
        action.innerHTML = "<small>listening, please speak...</small>";
    };

    recognition.onspeechend = function () {
        action.innerHTML = "<small>stopped listening.</small>";
        recognition.stop();
    }

    // This runs when the speech recognition service returns result
    recognition.onresult = function (event) {
        var transcript = event.results[0][0].transcript;
        var confidence = event.results[0][0].confidence;
        $("#" + txtInput).val($("#" + txtInput).val() + " " + transcript);
        //output.classList.remove("hide");
    };

    // start recognition
    recognition.start();
}

function toast(status, title, text) {
    var noti = new Notify({
        status: status,
        title: title,
        text: text,
        effect: 'fade',
        speed: 300,
        customClass: null,
        customIcon: null,
        showIcon: true,
        showCloseButton: true,
        autoclose: true,
        autotimeout: 5000,
        gap: 10,
        distance: 10,
        type: 1,
        position: 'right top'
    });
}

var numberToText = {
    a: ['', 'one ', 'two ', 'three ', 'four ', 'five ', 'six ', 'seven ', 'eight ', 'nine ', 'ten ', 'eleven ', 'twelve ', 'thirteen ', 'fourteen ', 'fifteen ', 'sixteen ', 'seventeen ', 'eighteen ', 'nineteen '],
    b: ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'],
    inWords: function (num) {
        if ((num = num.toString()).length > 9) return 'overflow';
        n = ('000000000' + num).substr(-9).match(/^(\d{2})(\d{2})(\d{2})(\d{1})(\d{2})$/);
        if (!n) return; var str = '';
        str += (n[1] != 0) ? (numberToText.a[Number(n[1])] || numberToText.b[n[1][0]] + ' ' + numberToText.a[n[1][1]]) + 'crore ' : '';
        str += (n[2] != 0) ? (numberToText.a[Number(n[2])] || numberToText.b[n[2][0]] + ' ' + numberToText.a[n[2][1]]) + 'lakh ' : '';
        str += (n[3] != 0) ? (numberToText.a[Number(n[3])] || numberToText.b[n[3][0]] + ' ' + numberToText.a[n[3][1]]) + 'thousand ' : '';
        str += (n[4] != 0) ? (numberToText.a[Number(n[4])] || numberToText.b[n[4][0]] + ' ' + numberToText.a[n[4][1]]) + 'hundred ' : '';
        str += (n[5] != 0) ? ((str != '') ? 'and ' : '') + (numberToText.a[Number(n[5])] || numberToText.b[n[5][0]] + ' ' + numberToText.a[n[5][1]]) + 'only ' : '';
        return str;
    },

    enable: function () {
        setTimeout(function () {
            $(".inwords").each(function () {
                $(this).after("<span style='color:green'></span>");
            });
            $(".inwords").off().on('change', function () {
                if ($(this).val()) {
                    var text = numberToText.inWords(parseInt($(this).val()));
                    $(this).next().html(text);
                }
                else {
                    $(this).next().html('');
                }
            });
        }, 3000);
    }
};

var helper = {
    variable: {
        templateData: [],
        hideNotiPanel: 1
    },
    getFastSelectValue: function (ddl) {
        var arr = [];
        $("#" + ddl).prev().find(".fstChoiceItem").each(function (i, v) {
            arr.push($(v).attr('data-value'));
        });
        return arr.join(",");
    },

    fillCallStatus: function (ddl, leadStatus) {
        var allowedStatus = ["FollowUp", "Postpone", "Converted", "Comment", "Surrender"];
        if (leadStatus && leadStatus == "All") {
            allowedStatus.push('Reopen');
            allowedStatus.push('Closed');
        }
        else {
            if (leadStatus && leadStatus == "Closed") {
                allowedStatus = [];
                allowedStatus.push('Reopen');
            }
            else {
                allowedStatus.push('Closed');
            }
        }

        var str = '<option value=""></option>';
        $.each(allowedStatus, function (i, v) {
            var disp = v;
            if (disp == 'Closed') {
                disp = "Cancel";
            }
            str += '<option value="' + v + '">' + disp + '</option>';
        });
        $(ddl).html(str);
    },

    fillProductCallStatus: function (ddl, leadStatus) {
        var allowedStatus = ["FollowUp", "Soldout", "Comment"];
        var str = '<option value=""></option>';
        $.each(allowedStatus, function (i, v) {
            str += '<option value="' + v + '">' + v + '</option>';
        });
        $(ddl).html(str);
    },

    fillCallRemarks: function (status, ddl) {
        var param = { status: status };
        var str = '<option value=""></option>';
        if (status) {
            ajaxCall("/Admin/LeadRemarks/GetByStatus", "GET", param, function (data) {
                $.each(data, function (i, v) {
                    str += '<option value="' + v.name + '">' + v.name + '</option>';
                });
                $("#" + ddl).html(str);
            });
        }
        else {
            $("#" + ddl).html(str);
        }
    },

    getReminder: function () {
        setInterval(helper.getReminderFn(), 1000 * 60 * 2);
    },

    getWalletBalance: function () {
        ajaxCall("/Admin/Wallet/GetPoints", "GET", null, function (data) {
            if (data && data.totalPoints) {
                $(".lblWalletAmount").html(data.totalPoints);
            }
            else {
                $(".lblWalletAmount").html("0");
            }
        });
    },


    getReminderFn: function () {
        ajaxCall("/Admin/Dashboard/GetFollowUp", "GET", null, function (data) {
            if (data && !data.isUserActive) {
                $("#btnLogout").click();
                return;
            }
            if (data && data.pending) {
                $.each(data.pending, function (i, v) {
                    let audio = new Audio(window.location.origin + "/audio/whatsapp.mp3");
                    audio.play();
                    toast('success', v.title, v.text);
                });
            }

            if (data && data.shown) {
                $(".lblNotiCount").html(data.shown.length);

                var str = "";
                $.each(data.shown, function (i, v) {
                    str += "<a class=\"dropdown-item\" href=\"javascript:helper.notiClick('" + v.idStr + "','" + v.type + "');\">";
                    str += v.text;
                    //str += "<span>" + v.text + "</span>";
                    str += "<span onclick=\"helper.removeReminder(" + v.id + ",'" + v.type + "')\">x</span>";
                    str += "</a>";
                });

                $(".lblNotiData").html(str);

                $('#myDropdown').off().on('hide.bs.dropdown', function (e) {
                    if (helper.variable.hideNotiPanel != 2) {
                        e.preventDefault();
                        e.stopPropagation();

                        setTimeout(function () {
                            if (helper.variable.hideNotiPanel == 1) {
                                helper.variable.hideNotiPanel = 2;
                                $('#myDropdown').trigger('hide.bs.dropdown');
                            }
                        }, 2000);
                    }
                });
            }
        });
    },

    notiClick: function (id, type) {
        helper.variable.hideNotiPanel = 0;
        setTimeout(function () { helper.variable.hideNotiPanel = 1; }, 1000);

        if (type == "Lead") {
            window.location.href = "/View/Lead/" + id;
        }
        else if (type == "Inventory") {
            window.location.href = "/View/Product/" + id;
        }
    },

    removeReminder: function (id, type) {
        helper.variable.hideNotiPanel = 0;
        setTimeout(function () { helper.variable.hideNotiPanel = 1; }, 1000);

        var param = { id: id, type: type };
        ajaxCall("/Admin/Dashboard/DeleteFollowUp", "POST", param, function (data) {
            if (data && data.success) {
                helper.getReminderFn();
            }
        });
    },

    fillTextData: function (type, ddl) {
        var param = { type: type };
        var str = '<option value=""></option>';
        helper.variable.templateData = [];
        if (type) {
            ajaxCall("/Admin/Template/GetByType", "GET", param, function (data) {
                helper.variable.templateData = data;
                $.each(data, function (i, v) {
                    str += '<option value="' + v.id + '">' + v.name + '</option>';
                });
                $("#" + ddl).html(str);
            });
        }
        else {
            $("#" + ddl).html(str);
        }
    },

    getFormData: function ($form) {
        var unindexed_array = $form.serializeArray();
        var indexed_array = {};

        $.map(unindexed_array, function (n, i) {
            indexed_array[n['name']] = n['value'];
        });

        return indexed_array;
    },

    getTimeFormated: function () {
        var today = new Date(),
            h = today.getHours(),
            m = today.getMinutes(),
            s = today.getSeconds();
        return [h + ":" + m + ":" + s, h + ":" + m]
    },


    addErrorInForm: function (div, message) {
        $("#" + div).removeClass("validation-summary-valid");
        $("#" + div).removeClass("alert-success");
        $("#" + div).addClass("validation-summary-errors");
        $("#" + div).addClass("alert-danger");
        $("#" + div + " ul").html('');
        $.each(message, function (i, v) {
            $("#" + div + " ul").append("<li>" + v + "</li>");
        });
        helper.scrollToTop();
        helper.clearMessage(div);
    },

    addSuccessInForm: function (div, message, scroll = true) {
        $("#" + div).removeClass("validation-summary-valid");
        $("#" + div).removeClass("alert-danger");
        $("#" + div).addClass("validation-summary-errors");
        $("#" + div).addClass("alert-success");
        $("#" + div + " ul").html('');
        $.each(message, function (i, v) {
            $("#" + div + " ul").append("<li>" + v + "</li>");
        });
        $("#" + div).focus();
        if (scroll) {
            helper.scrollToTop();
        }
        helper.clearMessage(div);
    },

    scrollToTop: function () {
        window.scrollTo(0, 0);
    },

    clearMessage: function (div) {
        setTimeout(function () {
            $("#" + div).addClass("validation-summary-valid");
            $("#" + div).removeClass("validation-summary-errors");
        }, 5000);
    },

    parseLeadText: function (text) {
        Object.keys(leadJson).forEach(function (key) {
            var find = '@' + key + '@';
            text = text.replace(new RegExp(find, 'g'), leadJson[key]);
        })
        return text;
    },

    openMasterPopup: function (field, isMulti) {
        $("#btnMasterModalPopup").attr('onclick', "helper.saveMasterPopup('" + field + "', " + isMulti + ")");
        $("#masterModalPopup").modal('show');
        $("#txtMasterName").val('');
    },

    saveMasterPopup: function (field, isMulti) {
        var param = {
            name: $("#txtMasterName").val(),
            field: field,
            cityId: $("#CityId").val()
        };

        if (!param.name) {
            alert("Please enter valid name");
            return;
        }

        if (!param.cityId) {
            alert("Please select City");
            return;
        }

        ajaxCall("/Admin/View/SaveMaster", "POST", param, function (data) {
            var str = '<option value="">Select</option>';
            if (data) {
                $.each(data, function (i, v) {
                    str += '<option value="' + v.id + '">' + v.name + '</option>';
                });
                $("#" + field).html(str);
                $("#masterModalPopup").modal('hide');
                //if (isMulti) {
                //    $("#" + field).data('fastselect').destroy();
                //    $("#" + field).fastselect();
                //}
                //else {
                $("#" + field).val("");
                //}
            }
        });
    }
}



var report = {
    reportTypeEnum: {
        Preview: 0,
        doc: 1,
        pdf: 2,
        xls: 3
    },

    reportFormTypeEnum: {
        Invoice: 0,
    },

    reportAction: function (id, reportFormType, reportType) {
        if (reportType == report.reportTypeEnum.Preview) {
            var param = {
                id: id,
                reportFormType: reportFormType,
                reportType: reportType
            };

            ajaxCall("/Admin/Report/InvoicePreview", "GET", param, function (data) {
                if (data && data.absoluteUrl) {
                    $("#invoiceModalPopup").modal('show');
                    $("#invoice-frame").attr('src', '/' + data.absoluteUrl);
                }
            });
        }
        else {
            var cacheBuster = new Date().getTime();
            var url = "/Report/InvoiceDownload?id=" + id + "&reportFormType=" + reportFormType + "&reportType=" + reportType + "&time=" + cacheBuster;
            $("#invoice-frame").attr('src', url);
        }
    },
};

var imageUpload = {
    newRow: function () {
        ajaxCall("/Admin/Helper/NewUploadRow", "GET", null, function (data) {
            $("#tblImageUpload").append(data);
        }, 'html');
    },
    deleteRow: function (recId) {
        $("#" + recId).remove();
        if ($("#tblImageUpload tr").length == 0) {
            imageUpload.newRow();
        }
    },
    uploadImage: function (fileId) {
        let photo = document.getElementById(fileId).files[0];  // file from input
        let req = new XMLHttpRequest();
        let formData = new FormData();

        formData.append("photo", photo);
        req.open("POST", '/helper/image');
        req.send(formData);
    }
}

var googleApi = {
    loadGoogleAddress: function () {
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('Address'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                document.getElementById('Address').value = place.formatted_address;
                document.getElementById('AddressLat').value = place.geometry.location.lat();
                document.getElementById('AddressLng').value = place.geometry.location.lng();
            });
        });

        $(document).on("keydown", "input", function (e) {
            if (e.which == 13) e.preventDefault();
        });
    },

    loadGoogleMap: function (markers, divId, zoomLavel = 16) {
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: zoomLavel,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById(divId), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title
            });
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.description);
                    infoWindow.open(map, marker);
                });
            })(marker, data);
        }
    }
}

var saveFrom = {
    trigger: function (formId, msgDiv, callback) {
        if ($(formId).valid()) {
            var formData = helper.getFormData($(formId));
            formData.productRelatedIds = $("#productRelatedIds").val() || null;
            formData.projectRelatedIds = $("#projectRelatedIds").val() || null;
            ajaxFormPost($(formId).attr('action'), formData, function (data) {
                $("#" + msgDiv).html("<ul></ul>");
                if (!data.success) {
                    helper.addErrorInForm(msgDiv, data.response.split(','));
                }
                else {
                    helper.addSuccessInForm(msgDiv, [data.response], false);
                    $(formId)[0].reset();
                    if (callback) {
                        callback();
                    }
                }
            });
        }
    }
}

var user = {
    addToWishList: function (projectId, productId) {
        var param = {
            projectId: projectId,
            productId: productId
        };
        ajaxCall("/Wishlist/Create", "POST", param, function (data) {
            if (data.success) {
                if (data.response == 'added') {
                    window.showAlert("alert-success", 'Added To Wishlist');
                    if (projectId) {
                        $('#wishlist-' + projectId).find('i').attr('class', 'bi bi-heart-fill');
                    }
                    else if (productId) {
                        $('#wishlist-' + productId).find('i').attr('class', 'bi bi-heart-fill');
                    }
                }
                else {
                    if (projectId) {
                        $('#wishlist-' + projectId).find('i').attr('class', 'bi bi-heart');
                    }
                    else if (productId) {
                        $('#wishlist-' + productId).find('i').attr('class', 'bi bi-heart');
                    }
                }
            }
            else {
                window.location.href = $("#btn-login").attr('href');
            }
        }, 'json');
    }
}

var userAccount = {
    sendOtp: function (phoneNumber) {
        var param = {
            sentTo: phoneNumber
        };
        ajaxCall("/Account/SendOtp", "POST", param, function (data) {
            if (data && data.success) {
                $(".send-otp").hide();
                $(".after-otp").show();
            }
            else {
                alert(data.response);
            }
        });
    },



}
