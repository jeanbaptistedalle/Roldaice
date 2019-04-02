
var firstInit = true;
$(document).ready(function () {
    prepareSite();
    firstInit = false;
});


function prepareSite() {
    try {

        showLoader();
        prepareDataTable();
        prepareToaster();
        prepareDatetimepicker();
        prepareSelectpicker();
        prepareToggle();
        prepareTooltip();
        prepareSlider();
        prepareIdenticon();

        // Après les préparations globales, on appelle la fonction de préparation liée à la page si elle existe
        if (typeof preparePage === 'function') {
            preparePage();
        }
    } catch{
        toastr['error']("Une erreur est survenue. Si celle-ci persiste, contactez l'administrateur");
    }
    hideLoader();
}

//Appel : await sleep(10)
async function sleep(time) {
    await new Promise(resolve => setTimeout(resolve, time * 1000/*seconds*/));
}

function offOnHandle(selector, event, handler) {
    //Définit un handler lié à l'evenement fourni pour le selecteur donné
    var namespacedEvent = event;
    if (!selector.startsWith('.')) {
        namespacedEvent += '.';
    }
    namespacedEvent += selector;
    //Afin d'éviter les doublons de listener, on supprime tous les handler existant mais uniquement sur ce namespace
    $(document).off(namespacedEvent).on(namespacedEvent, selector, handler);
    //Sans le namespace, off retirerait tous les évènement du même type et pas uniquement celui qu'on veut appliquer 
    //exemple : off('click') retire tous les évènements click, pas uniquement celui qu'on va réaffecter. off('click.<selector>') est plus restreint et dépend de la classe qu'on observe
}

function isMobile() {
    return jQuery.browser.mobile || $(document).width() < 1200 /*medium device size*/;
}


function prepareDataTable() {
    if (firstInit) {
        //On modifie le prototype de datatable afin de cacher les lignes disponsant de la classe "data-row-hide"
        $.fn.dataTable.ext.search.push(
            function (settings, data, dataIndex) {
                //On retrouve le node de la ligne
                var api = new $.fn.dataTable.Api(settings);
                var row = api.row(dataIndex).node();
                //Elle n'est affichée que si elle ne dispose pas de la classe "data-row-hide"
                return !$(row).hasClass('data-row-hide');
            }
        );
    }
    var enterForFilter = $('input#enter-filter-label').val();
    $('table.table.js-apply-data-table:not(.data-table-applyed)').each(function (index, val) {
        var $this = $(val);
        //Permet de n'appliquer qu'une seule fois la datatable sur chaque table (grâce au :not(.data-table-applyed) du selecteur)
        $this.addClass("data-table-applyed");
        var noPaging = $this.hasClass('no-paging');
        var dom = noPaging ? 'rt' : 'rtlip';
        var responsive = !$this.hasClass('no-responsive');
        var fixedHeader = $this.hasClass('fixed-header');
        try {

            var options = {
                info: false,
                retrieve: true, //Si on rappelle datatable, on récupère la table ayant déjà été préparée
                responsive: responsive,
                scrollX: !responsive, //Il n'y a pas de scroll lorsque les datatables sont responsive
                columnDefs: [
                    { targets: 'no-sort', orderable: false } //Toutes les entête de colonnes disposant de la classe "no-sort" ne peuvent pas être triées.
                ],
                paging: !noPaging,
                dom: dom,
                language: {
                    //TODO traduction des autres langues
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/French.json"
                },
            };

            var length = 25;
            if ($this.data('page-length')) {
                //Si une taille de page par défaut est définie, on l'utilise, sinon elle est de 25
                length = $this.data('page-length');
            }
            options.pageLength = length;

            if (fixedHeader) {
                options.fixedHeader = {
                    header: true,
                    //Les headers des tableaux doivent être décalée vers le bas de la taille de la navbar (sinon, le header sera en dessous de la navbar)
                    //Fait automatiquement en ajoutant la classe fh-fixedHeader à la navbar
                    //headerOffset: $('nav#page-header').outerHeight(), //Décommenter si besoin d'un header avec une taille particulière
                };
            }

            if ($this.hasClass('table-header-filter')) {
                options.initComplete = function () {
                    var atLeastOneSelectFilter = false;
                    this.api().columns().every(function () {
                        var column = this;
                        //Si le header a la classe "no-filter", aucun filtre ne sera prévue pour cette colonne
                        if (!$(column.header()).hasClass('no-filter')) {
                            var title = $(column.header()).text().replace('\t', '').trim();
                            //Si la classe select-filter est défini, le filtre devra être sous forme de select
                            if ($(column.header()).hasClass('select-filter')) {
                                //On crée un select avec les différentes valeurs de la colonne
                                var select = $('<select class="form-control" data-toggle="tooltip" title="' + title + '"><option value="">Tout</option></select>')
                                    .appendTo($(column.header()).empty())
                                    .on('click', function (event) {
                                        //Le click n'est pas propagé afin d'éviter que le tri soit lancé quand on veut accéder au select
                                        event.stopPropagation();
                                    })
                                    .on('change', function () {
                                        var val = $.fn.dataTable.util.escapeRegex(
                                            $(this).val()
                                        );
                                        column
                                            .search(val ? '^' + val + '$' : '', true, false)
                                            .draw();
                                    });
                                var values = [];
                                //Pour créer la liste de valeur, on viens récupérer le contenu de chaque cellule.
                                column.data().unique().each(function (d, j) {
                                    //On récupère la valeur des cellules et on supprime le html pour n'obtenir que le texte qu'il contient.
                                    var valueWithoutTags = d.replace(/(<([^>]+)>)/ig, '').trim();
                                    if (values.indexOf(valueWithoutTags) === -1) {
                                        values.push(valueWithoutTags);
                                    }
                                });
                                values = values.sort();
                                $.each(values, function (idx, value) {
                                    select.append('<option value="' + value + '">' + value + '</option>');
                                });
                            } else {
                                //Sinon, il devra être sous forme de champ texte
                                var input = $('<input class="form-control" type="text" placeholder="' + title + '" data-toggle="tooltip" title="' + title + '" />');

                                input.appendTo($(column.header()).empty())
                                    .on('click', function (event) {
                                        event.stopPropagation();
                                    });
                                if (checkIfIE()) {
                                    //Sur IE, le filtrage n'est effectuée qu'en appuyant sur Entrée (un bug rend le filtre trop lent pour le cas d'utilisation normal)
                                    input.on('keydown', function (e) {
                                        if (e.which === 13) {//Enter key
                                            e.preventDefault();
                                            e.stopPropagation();
                                            var value = $(this).val();
                                            if (column.search() !== value) {
                                                column.search(value).draw();
                                            }
                                        }
                                    });
                                    input.attr('title', input.attr('title') + '<br/>' + enterForFilter);
                                } else {
                                    //Sur les autres navigateurs, le filtrage est effectué dès que la saisie change
                                    input.on('keyup change', function () {
                                        var value = $(this).val();
                                        if (column.search() !== value) {
                                            column.search(value).draw();
                                        }
                                    });
                                }
                            }
                        }
                    });
                }
            }

            var table = $this.DataTable(options);
            if (fixedHeader) {
                table.fixedHeader.adjust();
            }

        } catch (ex) {
            //On intercepte les exception TypeError. Celles-ci surviennent quand une table n'a pas le format imposé par datatable (ce qui peut arriver avec grid.mvc)
            if (!ex instanceof TypeError) {
                throw ex;
            }
        }
    });
}

//Applique des filtres aux différents header des datatables
function addDatatableFilterHeader(table) {
    var filterRow = '<tr>';
    //On vérifie chaque case du header afin de construire pour chacune les filtres équivalents
    table.find('thead tr th').each(function () {
        var $this = $(this);
        if ($this.hasClass('no-filter')) {
            //Si le header a la classe "no-filter", aucun filtre ne sera prévue pour cette colonne
            filterRow += '<th></th>';
        } else {
            //Sinon, on crée un filtre
            var title = $this.text();
            filterRow += '<th><input type="text" placeholder="' + title + '" /><i class="fa fa-filter"></i></th>';
        }
    });
    filterRow += '</tr>';
    table.find('thead tr').after(filterRow);
}

function prepareSlider() {
    $('input.js-input-slider').bootstrapSlider();
}

//http://eonasdan.github.io/bootstrap-datetimepicker/
function prepareDatetimepicker() {

    $(".js-datepicker").each(function () {
        var maxDate = $(this).data("max-date");
        $(this).datetimepicker({
            locale: 'fr',
            format: "DD/MM/YYYY",
            calendarWeeks: true,
            showClear: true,
            // !!! README !!!
            //BUG sur Datetimepicker : maxdate n'est pas selectionnable au premier input.
            //FIX : Mettre la date max au jour suivant, elle devient la nouvelle date max mais grace à disabledDates, 
            // on ne peut pas la selectionner. A supprimer quand lib corrigée
            maxDate: maxDate,
            disabledDates: [maxDate],
            useCurrent: false, //On ne selectionne pas de valeur par défaut
        });
    });

    $(".js-day-month-picker").datetimepicker({
        locale: 'fr',
        format: "DD/MM",
        dayViewHeaderFormat: 'MMMM',
        showClear: true,
        calendarWeeks: true,
    });

    $(".js-year-picker").datetimepicker({
        locale: 'fr',
        format: "YYYY",
        dayViewHeaderFormat: 'YYYY',
        showClear: true,
        calendarWeeks: true,
        //maxDate: nextYear,
        //useCurrent: false
    });
}

function prepareSelectpicker() {
    $('.js-select-picker').each(function () {
        $this = $(this);
        var noLiveSearch = $this.hasClass('no-live-search');
        $this.selectpicker({
            noneSelectedText: "",
            actionsBox: true,
            liveSearch: !noLiveSearch,
            liveSearchStyle: 'startsWith',
            selectAllText: $('input#select-all-label').val(),
            deselectAllText: $('input#deselect-all-label').val(),
            container: 'body',
        });
    });
}

function prepareToggle() {
    $(".js-datatoggle").each(function (index, val) {
        var element = $(this);
        //On utilise les label Oui/Non par défaut
        var on = "Oui";
        var off = "Non";
        //A moins qu'un attribut data-*label* soit présent
        if (element.attr('data-on')) {
            on = element.data('on');
        }
        if (element.attr('data-off')) {
            off = element.data('off');
        }
        $(this).bootstrapToggle({
            on: on,
            off: off,
        });
    });
}

function prepareTooltip() {
    //Avant d'initialiser les tooltip, on supprime les anciennes tooltips qui seraient toujours affichés (problème avec le scroll/ajax sinon)
    $('body > div.tooltip.fade').remove();
    var selector = '[data-toggle="tooltip"][title]';
    $(selector).tooltip({
        html: true,
        container: 'body',
        trigger: 'hover',
    });
    offOnHandle('a' + selector, 'click', function () {
        $(this).tooltip('hide');
    });
}

function prepareToaster() {
    if (firstInit === true) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "5000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }
}

function showLoader() {
    changeLoaderVisibility(true);
}

function hideLoader() {
    changeLoaderVisibility(false);
}

function changeLoaderVisibility(show) {
    var loader = $("#loader-div");

    if (show && loader.css('visibility') == 'hidden') {
        loader.css('visibility', 'visible');
        loader.addClass("overlay-visible");
    } else if (!show && loader.css('visibility') == 'visible') {
        loader.removeClass("overlay-visible");
        loader.css('visibility', 'hidden');

    }
}

function prepareIdenticon() {
    $('img.js-identicon').each(function (index, val) {
        var element = $(this);
        var hash = element.data('hash');
        if (hash) {
            var size = element.data('size');
            if (!size) {
                size = 420;
            }

            var data = new Identicon(hash, size).toString();
            element.attr('width', size);
            element.attr('height', size);
            element.attr('src', 'data:image/png;base64,' + data);
        }
    });
}