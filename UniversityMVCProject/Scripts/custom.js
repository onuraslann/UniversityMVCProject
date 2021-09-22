﻿$(function () {
   
    $("#tblDepartmanlar").on("click", ".btnDepartmanDelete", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Departman/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {

    $("#tblLecturers").on("click", ".btnLecturerDelete", function () {
        var btn = $(this);
        bootbox.confirm("Öğretim üyesini silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Lecturer/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {

    $("tblLesson").on("click", ".btnLessonDelete", function () {
        var btn = $(this);
        bootbox.confirm("Dersi silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Lesson/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {

    $("#tblNotes").on("click", ".btnNoteDelete", function () {
        var btn = $(this);
        bootbox.confirm("Dersi silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Note/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {

    $("#tblStudent").on("click", ".btnStudentDelete", function () {
        var btn = $(this);
        bootbox.confirm("Dersi silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Student/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});