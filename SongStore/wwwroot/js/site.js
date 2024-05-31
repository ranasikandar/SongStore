var csrfToken = 'CSRF_TOKEN_SongStoreAUTH_FORM5';

function SearchSong() {
    var _searchTxt = $("#txtSearchSongTitle").val();
    var _artist = $("#ddlArtist :selected").val();
    var _genre = $("#ddlGenre :selected").val();
    var _year = $("#ddlYear :selected").val();
    GetSongData(true, _searchTxt, _artist, _genre, _year);
}

//ajax load Song
var pageSize = 4;
var pageIndex = 0;
var _incallback = false;
var _EOTL = false;

function GetSongData(isnew, searchTxt, artist, genre, year) {

    if (isnew) {
        pageIndex = 0; _EOTL = false;
    }

    $.ajax({
        type: 'GET',
        url: '/Home/LoadSongs',
        data: { "pageindex": pageIndex, "pagesize": pageSize, "searchTxt": searchTxt, "artist": artist, "genre": genre, "year": year},
        dataType: 'json',
        success: function (response) {
            if (response != null && response.length > 0) {
                if (isnew) {
                    $("#searchResults").html("");
                }
                if (response[0].server_Res && response[0].server_Res === "EOTL") {
                    $("#searchResults").append("<div class='col-12 text-center'><h5>Thats All Folks</h5></div>");
                    _EOTL = true;
                } else {

                    for (var i = 0; i < response.length; i++) {
                        var _yearRecorded;
                        if (response[i].yearRecorded) {
                            _yearRecorded = response[i].yearRecorded;
                        } else {
                            _yearRecorded = "UnKnown";
                        }

                        if (_isAdmin) {
                            var _click4Admin = "onclick='goToSongDetails(" + response[i].id + ")'";
                            var delFn = "onclick='deleteSongFn(" + response[i].id + ")'";

                            $("#searchResults").append("<div class='col-sm-6'><div class='card mb-3 cardH'><div class='row no-gutters'><div class='col-md-4'><img src='" + response[i].imageLocation + "' class='card-img' alt='" + response[i].songTitle + "'></div><div class='col-md-8'><div class='card-body'><h5 class='card-title'>" + response[i].songTitle + "</h5><p class='card-text'><span class='fa fa-user mr-2'></span>" + response[i].artistName + "</p><p class='card-text'><span class='fa fa-cubes mr-2'></span>" + response[i].genreName + "</p><p class='card-text'><span class='fa fa-calendar mr-2'></span><small class='text-muted'>" + _yearRecorded + "</small></p></div></div></div>  <div class='card-body text-center'><a target='_blank' href='" + response[i].songFileLocation + "' class='card-link'>Download</a><a href='#' " + _click4Admin + " class='card-link text-success'>Edit</a><a href='#' " + delFn + " class='card-link text-danger'>Delete</a></div>  </div></div>");
                        }
                        else {
                            $("#searchResults").append("<div class='col-sm-6'><div class='card mb-3 cardH'><div class='row no-gutters'><div class='col-md-4'><img src='" + response[i].imageLocation + "' class='card-img' alt='" + response[i].songTitle + "'></div><div class='col-md-8'><div class='card-body'><h5 class='card-title'>" + response[i].songTitle + "</h5><p class='card-text'><span class='fa fa-user mr-2'></span>" + response[i].artistName + "</p><p class='card-text'><span class='fa fa-cubes mr-2'></span>" + response[i].genreName + "</p><p class='card-text'><span class='fa fa-calendar mr-2'></span><small class='text-muted'>" + _yearRecorded + "</small></p></div></div></div>  <div class='card-body text-center'><a target='_blank' href='" + response[i].songFileLocation + "' class='card-link'>Download</a></div>  </div></div>");
                        }
                        
                    }
                    pageIndex++;
                }
            }
        },
        beforeSend: function () {
            $("#progress").show();
            $("#progress").append("<i class='ml-1 fa fa-spinner'></i>");
        },
        complete: function (event, jqXHR) {
            if (jqXHR.toLocaleLowerCase() === "success") {
                $('#progress').find('svg').remove();
                $('#progress').find('i').remove();
                $("#progress").hide();
            }
            else {
                $('#progress').find('svg').remove();
                $('#progress').find('i').remove();
                $("#progress").append("<i class='text-danger ml-1 fa fa-exclamation-triangle'></i>");
            }
            _incallback = false;
        },
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connected. Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
                console.error(jqXHR);
            }

            $("#progress").append("<i class='text-danger ml-1 fa fa-exclamation-triangle'></i>");
            console.log(msg);
            _incallback = false;
        }
    });
}
//ajax load Songs


function goToSongDetails(sId) {
    location.href = "/Song/Index/" + sId + "";
}

function deleteSongFn(sId) {
    event.preventDefault();

    swal({
        title: "Are you sure?",
        text: "Delete Song",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            location.href = "/Song/Delete/" + sId + "";
        } else {
            //swal("Record was not deleted!");
        }
    });

}

function delArtistFn(aId) {
    event.preventDefault();

    swal({
        title: "Are you sure?",
        text: "Delete Artist",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            location.href = "/Artist/Delete/" + aId + "";
        }
    });

}

function delGenreFn(aId) {
    event.preventDefault();

    swal({
        title: "Are you sure?",
        text: "Delete Genre",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            location.href = "/Genre/Delete/" + aId + "";
        }
    });

}
