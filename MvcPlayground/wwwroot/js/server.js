var app = new Vue({
  el: "#PaginationExamples",
  data() {
    return {$table: [], checked: []};
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
        // scrollY: 200,  // set true for deffered rows deferRender: true, // set true
        // for deffered rows scroller: true, // set true for deffered rows
        ajax: {
          url: "/Home/GetData",
          type: "POST"
        },
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
            render: function (data, type, full, meta) {
              // generate unique identifier
              var id = app.uniqID(full);
              // default is unselected
              if (!app.checked[id]) {
                app.checked[id] = false;
              }

              var check = app.checked[id]
                ? "checked"
                : "";

              // return state of checkbox
              return `<input class="tcb" type="checkbox" name="tcb_${
              meta.row}" value="${id}" ${check}>`;
            }
          }
        ],
        order: [
          1, "asc"
        ],
        columns: [
          {
            title: "✔️",
            data: "_"
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
    checkBoxHandler(elem) {
      var $elem = $(elem);
      var checked = $elem.prop("checked");
      var id = $elem.val();
      var row = $elem
        .prop("name")
        .split("_")[1];

      console.log(`checked box : ${checked};row : ${row}; id: ${id}`);
      app.checked[id] = checked;

      // do something
    },
    // generates a unique id using object property values requires a primary key of
    // some sort in object
    uniqID(elem) {
      return R.pipe(R.valuesIn, R.join(""), encodeURIComponent)(elem);
    },
    addRow() {
      // call to server
    },
    removeRows() {
      console.log("remove rows");
      // call to server
    }
  },
  created() {
    console.log("created");
  },
  mounted() {
    console.log("mounted");
    this.initTable();
  }
});
