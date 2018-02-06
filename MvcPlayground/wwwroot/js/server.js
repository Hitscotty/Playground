var app = new Vue({
  el: "#PaginationExamples",
  data() {
    return {$table: [], $editModal: [], $editTable: [], checked: {}};
  },
  methods: {
    initTable() {
      console.log("initingTable");
      this.$table = $("#table").DataTable({
        processing: true,
        serverSide: true,
        paging: true,
        stateSave: true,
        deferRender: true,
        scrollY: 300,
        scrollCollapse: true,
        pagingType: "full_numbers",
        dom: "Blfrtip",
        buttons: [
          "copy", "csv", "excel", "pdf", "print"
        ],
        lengthMenu: [
          5,
          10,
          25,
          50,
          75,
          100
        ],
        ajax: {
          url: "/Home/GetData",
          type: "POST"
        },
        rowId: "id",
        language: {
          search: "",
          searchPlaceholder: "Search . . ."
        },
        columnDefs: [
          {
            targets: 0,
            searchable: false,
            orderable: false,
            className: "dt-body-center",
            render: function (data, type, row, meta) {
              // generate unique identifier default is unselected
              var check = "";

              if (app.checked[row.id]) {
                if (app.checked[row.id].state) {
                  check = "checked";
                }
              }

              // return state of checkbox
              return `<input style="height:20px;width:20px" class="tcb" type="checkbox" name="tcb_${
              meta.row}" value="${row.id}" ${check}>`;
            }
          }, {
            targets: 1,
            visible: false
          }
        ],
        order: [
          2, "asc"
        ],
        columns: [
          {
            title: "✔️",
            data: "_"
          }, {
            title: "",
            data: "id"
          }, {
            title: "Name",
            data: "name"
          }, {
            title: "Last",
            data: "last"
          }, {
            title: "Title",
            data: "title"
          }, {
            title: "Location",
            data: "location"
          }, {
            title: "Date",
            data: "date"
          }, {
            title: "Salary",
            data: "salary"
          }
        ],
        drawCallback: function () {
          // give buttons margin
          $(".dt-buttons").css("margin", "10px");
          // give vuetifull css
          $(".paginate_button").each((v, e) => {
            $(e).addClass("paginator-button paginator-page-number");
          });
        }
      });
      // add checkbox event
      $("#table tbody").on("change", ".tcb", function () {
        app.checkBoxHandler(this);
      });
    },
    initEditTable() {
      var selectedRows = Object
        .keys(app.checked)
        .filter(c => app.checked[c].state === true)
        .map(c => app.checked[c].row);

      this.$editTable = $("#editTable").DataTable({
        destroy: true,
        searching: false,
        ordering: false,
        data: selectedRows,
        columns: [
          {
            data: "name",
            title: "Name"
          }, {
            data: "last",
            title: "Last"
          }, {
            data: "title",
            title: "Title"
          }
        ],
        columnDefs: [
          {
            targets: 0,
            render: function (data, display, row, meta) {
              return `
              <div class="field">
                <input style="padding:0;width:100%" type="text" name="${
              row.id}[]" :v-model="checked[${row.id}].row.name" value="${data}"/>
              </div>`;
            }
          }, {
            targets: 1,
            render: function (data, display, row, meta) {
              return `
              <div class="field">
                <input style="padding:0;width:80%" type="text" name="${
              row.id}[]" :v-model="checked[${row.id}].row.last" value="${data}"/>
              </div>`;
            }
          }, {
            targets: 2,
            render: function (data, display, row, meta) {
              return `
                <input style="padding:0;width:80%" type="text" name="${
              row.id}[]" :v-model="checked[${row.id}].row.title" value="${data}"/>
              `;
            }
          }
        ],
        paging: false
      });
    },
    initDialogs() {
      this.$editModal = $("#editModal");
      this
        .$editModal
        .dialog({autoOpen: false, height: 500, width: "80%", modal: true});
    },
    checkBoxHandler(elem) {
      var $elem = $(elem);
      var checked = $elem.prop("checked");
      var id = $elem.val();
      var row = $elem
        .prop("name")
        .split("_")[1];

      app.$set(app.checked, id, {
        state: checked,
        row: app
          .$table
          .row(`#${id}`)
          .data()
      });
    },
    // generates a unique id using object property values requires a primary key of
    // some sort in object
    uniqID(elem) {
      return R.pipe(R.valuesIn, R.join(""), encodeURIComponent)(elem);
    },
    addRow() {
      // call to server
    },
    editChecked() {
      this.initEditTable();
      console.dir(app.checked);
      app
        .$editModal
        .dialog("open");
    },
    applyEdits() {
      var editedRows = $(".ui.form").form("get values");
      console.log("edited rows");
      console.dir(editedRows);
    }
  },
  created() {
    console.log("created");
  },
  mounted() {
    console.log("mounted");
    this.initTable();
    this.initDialogs();
  }
});
