/**
 * angular-timers - v1.3.5 - 2017-07-23 2:18 PM
 * https://github.com/siddii/angular-timers
 *
 * Copyright (c) 2017 Adrian Wardell
 * Licensed MIT <https://github.com/siddii/angular-timers/blob/master/LICENSE.txt>
 */
var timersModule = angular.module("timers", [])
    .directive("timers", ["$compile",
        function (a) {
            return {
                restrict: "EA", replace: !1, scope: { interval: "=interval", startTimeAttr: "=startTime", endTimeAttr: "=endTime", countdownattr: "=countdown", finishCallback: "&finishCallback", autoStart: "&autoStart", language: "@?", fallback: "@?", maxTimeUnit: "=", seconds: "=?", minutes: "=?", hours: "=?", days: "=?", months: "=?", years: "=?", secondsS: "=?", minutesS: "=?", hoursS: "=?", daysS: "=?", monthsS: "=?", yearsS: "=?" },
                controller: ["$scope", "$element", "$attrs", "$timeout", "I18nService", "$interpolate", "progressBarService",
                    function (b, c, d, e, f, g, h) {
                        function i() { b.timeoutId && clearTimeout(b.timeoutId) }
                        function j() { var a = {}; void 0 !== d.startTime && (b.millis = moment().diff(moment(b.startTimeAttr))), a = k.getTimeUnits(b.millis), b.maxTimeUnit && "day" !== b.maxTimeUnit ? "second" === b.maxTimeUnit ? (b.seconds = Math.floor(b.millis / 1e3), b.minutes = 0, b.hours = 0, b.days = 0, b.months = 0, b.years = 0) : "minute" === b.maxTimeUnit ? (b.seconds = Math.floor(b.millis / 1e3 % 60), b.minutes = Math.floor(b.millis / 6e4), b.hours = 0, b.days = 0, b.months = 0, b.years = 0) : "hour" === b.maxTimeUnit ? (b.seconds = Math.floor(b.millis / 1e3 % 60), b.minutes = Math.floor(b.millis / 6e4 % 60), b.hours = Math.floor(b.millis / 36e5), b.days = 0, b.months = 0, b.years = 0) : "month" === b.maxTimeUnit ? (b.seconds = Math.floor(b.millis / 1e3 % 60), b.minutes = Math.floor(b.millis / 6e4 % 60), b.hours = Math.floor(b.millis / 36e5 % 24), b.days = Math.floor(b.millis / 36e5 / 24 % 30), b.months = Math.floor(b.millis / 36e5 / 24 / 30), b.years = 0) : "year" === b.maxTimeUnit && (b.seconds = Math.floor(b.millis / 1e3 % 60), b.minutes = Math.floor(b.millis / 6e4 % 60), b.hours = Math.floor(b.millis / 36e5 % 24), b.days = Math.floor(b.millis / 36e5 / 24 % 30), b.months = Math.floor(b.millis / 36e5 / 24 / 30 % 12), b.years = Math.floor(b.millis / 36e5 / 24 / 365)) : (b.seconds = Math.floor(b.millis / 1e3 % 60), b.minutes = Math.floor(b.millis / 6e4 % 60), b.hours = Math.floor(b.millis / 36e5 % 24), b.days = Math.floor(b.millis / 36e5 / 24), b.months = 0, b.years = 0), b.secondsS = 1 === b.seconds ? "" : "s", b.minutesS = 1 === b.minutes ? "" : "s", b.hoursS = 1 === b.hours ? "" : "s", b.daysS = 1 === b.days ? "" : "s", b.monthsS = 1 === b.months ? "" : "s", b.yearsS = 1 === b.years ? "" : "s", b.secondUnit = a.seconds, b.minuteUnit = a.minutes, b.hourUnit = a.hours, b.dayUnit = a.days, b.monthUnit = a.months, b.yearUnit = a.years, b.sseconds = b.seconds < 10 ? "0" + b.seconds : b.seconds, b.mminutes = b.minutes < 10 ? "0" + b.minutes : b.minutes, b.hhours = b.hours < 10 ? "0" + b.hours : b.hours, b.ddays = b.days < 10 ? "0" + b.days : b.days, b.mmonths = b.months < 10 ? "0" + b.months : b.months, b.yyears = b.years < 10 ? "0" + b.years : b.years } "function" != typeof String.prototype.trim && (String.prototype.trim = function () { return this.replace(/^\s+|\s+$/g, "") }), b.autoStart = d.autoStart || d.autostart, b.language = b.language || "en", b.fallback = b.fallback || "en", b.$watch("language", function (a, c) { void 0 !== a && k.init(a, b.fallback) }); var k = new f; k.init(b.language, b.fallback), b.displayProgressBar = 0, b.displayProgressActive = "active", 0 === c.html().trim().length ? c.append(a("<span>" + g.startSymbol() + "millis" + g.endSymbol() + "</span>")(b)) : c.append(a(c.contents())(b)), b.startTime = null, b.endTime = null, b.timeoutId = null, b.countdown = angular.isNumber(b.countdownattr) && parseInt(b.countdownattr, 10) >= 0 ? parseInt(b.countdownattr, 10) : void 0, b.isRunning = !1, b.$on("timers-start", function () { b.start() }), b.$on("timers-resume", function () { b.resume() }), b.$on("timers-stop", function () { b.stop() }), b.$on("timers-clear", function () { b.clear() }), b.$on("timers-reset", function () { b.reset() }), b.$on("timers-set-countdown", function (a, c) { b.countdown = c }), b.$watch("startTimeAttr", function (a, c) { a !== c && b.isRunning && b.start() }), b.$watch("endTimeAttr", function (a, c) { a !== c && b.isRunning && b.start() }), b.start = function () { b.startTime = b.startTimeAttr ? moment(b.startTimeAttr) : moment(), b.endTime = b.endTimeAttr ? moment(b.endTimeAttr) : null, angular.isNumber(b.countdown) || (b.countdown = angular.isNumber(b.countdownattr) && parseInt(b.countdownattr, 10) > 0 ? parseInt(b.countdownattr, 10) : void 0), i(), l(), b.isRunning = !0, b.$emit("timers-started", { timeoutId: b.timeoutId, millis: b.millis, seconds: b.seconds, minutes: b.minutes, hours: b.hours, days: b.days }) }, b.resume = function () { i(), b.countdownattr && (b.countdown += 1), b.startTime = moment().diff(moment(b.stoppedTime).diff(moment(b.startTime))), l(), b.isRunning = !0, b.$emit("timers-started", { timeoutId: b.timeoutId, millis: b.millis, seconds: b.seconds, minutes: b.minutes, hours: b.hours, days: b.days }) }, b.stop = b.pause = function () { var a = b.timeoutId; b.clear(), b.$emit("timers-stopped", { timeoutId: a, millis: b.millis, seconds: b.seconds, minutes: b.minutes, hours: b.hours, days: b.days }) }, b.clear = function () { b.stoppedTime = moment(), i(), b.timeoutId = null, b.isRunning = !1 }, b.reset = function () { b.startTime = b.startTimeAttr ? moment(b.startTimeAttr) : moment(), b.endTime = b.endTimeAttr ? moment(b.endTimeAttr) : null, b.countdown = angular.isNumber(b.countdownattr) && parseInt(b.countdownattr, 10) > 0 ? parseInt(b.countdownattr, 10) : void 0, i(), l(), b.isRunning = !1, b.clear(), b.$emit("timers-reseted", { timeoutId: b.timeoutId, millis: b.millis, seconds: b.seconds, minutes: b.minutes, hours: b.hours, days: b.days }) }, c.bind("$destroy", function () { i(), b.isRunning = !1 }), b.countdownattr ? (b.millis = 1e3 * b.countdownattr, b.addCDSeconds = function (a) { b.countdown += a, b.isRunning || b.start() }, b.$on("timers-add-cd-seconds", function (a, c) { b.addCDSeconds(c) }), b.$on("timers-set-countdown-seconds", function (a, c) { b.isRunning || b.clear(), b.countdown = c, b.millis = 1e3 * c, j() })) : b.millis = 0, j(); var l = function m() { var a = null; b.millis = moment().diff(b.startTime); var c = b.millis % 1e3; return b.endTimeAttr && (a = b.endTimeAttr, b.millis = moment(b.endTime).diff(moment()), c = b.interval - b.millis % 1e3), b.countdownattr && (a = b.countdownattr, b.millis = 1e3 * b.countdown), b.millis < 0 ? (b.stop(), b.millis = 0, j(), void (b.finishCallback && b.$eval(b.finishCallback))) : (j(), b.timeoutId = setTimeout(function () { m(), b.$apply() }, b.interval - c), b.$emit("timers-tick", { timeoutId: b.timeoutId, millis: b.millis, seconds: b.seconds, minutes: b.minutes, hours: b.hours, days: b.days }), b.countdown > 0 ? b.countdown-- : b.countdown <= 0 && (b.stop(), b.finishCallback && b.$eval(b.finishCallback)), void (null !== a && (b.progressBar = h.calculateProgressBar(b.startTime, b.millis, b.endTime, b.countdownattr), 100 === b.progressBar && (b.displayProgressActive = "")))) }; (void 0 === b.autoStart || b.autoStart === !0) && b.start()
                    }]
            }
        }]).directive("timersControls",
    function () {
        return {
            restrict: "EA", scope: !0, controller: ["$scope",
                function (a) {
                a.timersStatus = "reset", a.$on("timers-started",
                    function () { a.timersStatus = "started" }),
                    a.$on("timers-stopped",
                        function () { a.timersStatus = "stopped" }),
                    a.$on("timers-reset",
                        function () { a.timersStatus = "reset" }),
                    a.timersStart =
                    function () { a.$broadcast("timers-start") },
                    a.timersStop = function () { a.$broadcast("timers-stop") },
                    a.timersResume =
                    function () { a.$broadcast("timers-resume") },
                    a.timersToggle =
                    function () { switch (a.timersStatus) { case "started": a.timersStop(); break; case "stopped": a.timersResume(); break; case "reset": a.timersStart() } },
                    a.timersAddCDSeconds =
                    function (b) { a.$broadcast("timers-add-cd-seconds", b) }
                }]
        }
    }); "undefined" != typeof module && "undefined" != typeof exports && module.exports === exports && (module.exports = timersModule); var app = angular.module("timers"); app.factory("I18nService", function () { var a = function () { }; return a.prototype.language = "en", a.prototype.fallback = "en", a.prototype.timeHumanizer = {}, a.prototype.init = function (a, b) { var c = humanizeDuration.getSupportedLanguages(); this.fallback = void 0 !== b ? b : "en", -1 === c.indexOf(b) && (this.fallback = "en"), this.language = a, -1 === c.indexOf(a) && (this.language = this.fallback), this.timeHumanizer = humanizeDuration.humanizer({ language: this.language, halfUnit: !1 }) }, a.prototype.getTimeUnits = function (a) { var b = 1e3 * Math.round(a / 1e3), c = {}; return "undefined" != typeof this.timeHumanizer ? c = { millis: this.timeHumanizer(b, { units: ["ms"] }), seconds: this.timeHumanizer(b, { units: ["s"] }), minutes: this.timeHumanizer(b, { units: ["m", "s"] }), hours: this.timeHumanizer(b, { units: ["h", "m", "s"] }), days: this.timeHumanizer(b, { units: ["d", "h", "m", "s"] }), months: this.timeHumanizer(b, { units: ["mo", "d", "h", "m", "s"] }), years: this.timeHumanizer(b, { units: ["y", "mo", "d", "h", "m", "s"] }) } : console.error('i18nService has not been initialized. You must call i18nService.init("en") for example'), c }, a }); var app = angular.module("timers"); app.factory("progressBarService", function () { var a = function () { }; return a.prototype.calculateProgressBar = function (a, b, c, d) { var e, f, g = 0; return b /= 1e3, null !== c ? (e = moment(c), f = e.diff(a, "seconds"), g = 100 * b / f) : g = 100 * b / d, g = 100 - g, g = Math.round(10 * g) / 10, g > 100 && (g = 100), g }, new a });
// HumanizeDuration.js - http://git.io/j0HgmQ

;(function () {
  var languages = {
    ar: {
      y: function (c) { return c === 1 ? '??????' : '??????????' },
      mo: function (c) { return c === 1 ? '??????' : '????????' },
      w: function (c) { return c === 1 ? '??????????' : '????????????' },
      d: function (c) { return c === 1 ? '??????' : '????????' },
      h: function (c) { return c === 1 ? '????????' : '??????????' },
      m: function (c) { return c === 1 ? '??????????' : '??????????' },
      s: function (c) { return c === 1 ? '??????????' : '??????????' },
      ms: function (c) { return c === 1 ? '?????? ???? ??????????????' : '?????????? ???? ??????????????' },
      decimal: ','
    },
    ca: {
      y: function (c) { return 'any' + (c !== 1 ? 's' : '') },
      mo: function (c) { return 'mes' + (c !== 1 ? 'os' : '') },
      w: function (c) { return 'setman' + (c !== 1 ? 'es' : 'a') },
      d: function (c) { return 'di' + (c !== 1 ? 'es' : 'a') },
      h: function (c) { return 'hor' + (c !== 1 ? 'es' : 'a') },
      m: function (c) { return 'minut' + (c !== 1 ? 's' : '') },
      s: function (c) { return 'segon' + (c !== 1 ? 's' : '') },
      ms: function (c) { return 'milisegon' + (c !== 1 ? 's' : '') },
      decimal: ','
    },
    cs: {
      y: function (c) { return ['rok', 'roku', 'roky', 'let'][getCzechForm(c)] },
      mo: function (c) { return ['m??s??c', 'm??s??ce', 'm??s??ce', 'm??s??c??'][getCzechForm(c)] },
      w: function (c) { return ['t??den', 't??dne', 't??dny', 't??dn??'][getCzechForm(c)] },
      d: function (c) { return ['den', 'dne', 'dny', 'dn??'][getCzechForm(c)] },
      h: function (c) { return ['hodina', 'hodiny', 'hodiny', 'hodin'][getCzechForm(c)] },
      m: function (c) { return ['minuta', 'minuty', 'minuty', 'minut'][getCzechForm(c)] },
      s: function (c) { return ['sekunda', 'sekundy', 'sekundy', 'sekund'][getCzechForm(c)] },
      ms: function (c) { return ['milisekunda', 'milisekundy', 'milisekundy', 'milisekund'][getCzechForm(c)] },
      decimal: ','
    },
    da: {
      y: '??r',
      mo: function (c) { return 'm??ned' + (c !== 1 ? 'er' : '') },
      w: function (c) { return 'uge' + (c !== 1 ? 'r' : '') },
      d: function (c) { return 'dag' + (c !== 1 ? 'e' : '') },
      h: function (c) { return 'time' + (c !== 1 ? 'r' : '') },
      m: function (c) { return 'minut' + (c !== 1 ? 'ter' : '') },
      s: function (c) { return 'sekund' + (c !== 1 ? 'er' : '') },
      ms: function (c) { return 'millisekund' + (c !== 1 ? 'er' : '') },
      decimal: ','
    },
    de: {
      y: function (c) { return 'Jahr' + (c !== 1 ? 'e' : '') },
      mo: function (c) { return 'Monat' + (c !== 1 ? 'e' : '') },
      w: function (c) { return 'Woche' + (c !== 1 ? 'n' : '') },
      d: function (c) { return 'Tag' + (c !== 1 ? 'e' : '') },
      h: function (c) { return 'Stunde' + (c !== 1 ? 'n' : '') },
      m: function (c) { return 'Minute' + (c !== 1 ? 'n' : '') },
      s: function (c) { return 'Sekunde' + (c !== 1 ? 'n' : '') },
      ms: function (c) { return 'Millisekunde' + (c !== 1 ? 'n' : '') },
      decimal: ','
    },
    en: {
      y: function (c) { return 'year' + (c !== 1 ? 's' : '') },
      mo: function (c) { return 'month' + (c !== 1 ? 's' : '') },
      w: function (c) { return 'week' + (c !== 1 ? 's' : '') },
      d: function (c) { return 'day' + (c !== 1 ? 's' : '') },
      h: function (c) { return 'hour' + (c !== 1 ? 's' : '') },
      m: function (c) { return 'minute' + (c !== 1 ? 's' : '') },
      s: function (c) { return 'second' + (c !== 1 ? 's' : '') },
      ms: function (c) { return 'millisecond' + (c !== 1 ? 's' : '') },
      decimal: '.'
    },
    es: {
      y: function (c) { return 'a??o' + (c !== 1 ? 's' : '') },
      mo: function (c) { return 'mes' + (c !== 1 ? 'es' : '') },
      w: function (c) { return 'semana' + (c !== 1 ? 's' : '') },
      d: function (c) { return 'd??a' + (c !== 1 ? 's' : '') },
      h: function (c) { return 'hora' + (c !== 1 ? 's' : '') },
      m: function (c) { return 'minuto' + (c !== 1 ? 's' : '') },
      s: function (c) { return 'segundo' + (c !== 1 ? 's' : '') },
      ms: function (c) { return 'milisegundo' + (c !== 1 ? 's' : '') },
      decimal: ','
    },
    fi: {
      y: function (c) { return c === 1 ? 'vuosi' : 'vuotta' },
      mo: function (c) { return c === 1 ? 'kuukausi' : 'kuukautta' },
      w: function (c) { return 'viikko' + (c !== 1 ? 'a' : '') },
      d: function (c) { return 'p??iv??' + (c !== 1 ? '??' : '') },
      h: function (c) { return 'tunti' + (c !== 1 ? 'a' : '') },
      m: function (c) { return 'minuutti' + (c !== 1 ? 'a' : '') },
      s: function (c) { return 'sekunti' + (c !== 1 ? 'a' : '') },
      ms: function (c) { return 'millisekunti' + (c !== 1 ? 'a' : '') },
      decimal: ','
    },
    fr: {
      y: function (c) { return 'an' + (c !== 1 ? 's' : '') },
      mo: 'mois',
      w: function (c) { return 'semaine' + (c !== 1 ? 's' : '') },
      d: function (c) { return 'jour' + (c !== 1 ? 's' : '') },
      h: function (c) { return 'heure' + (c !== 1 ? 's' : '') },
      m: function (c) { return 'minute' + (c !== 1 ? 's' : '') },
      s: function (c) { return 'seconde' + (c !== 1 ? 's' : '') },
      ms: function (c) { return 'milliseconde' + (c !== 1 ? 's' : '') },
      decimal: ','
    },
    gr: {
      y: function (c) { return c === 1 ? '????????????' : '????????????' },
      mo: function (c) { return c === 1 ? '??????????' : '??????????' },
      w: function (c) { return c === 1 ? '????????????????' : '??????????????????' },
      d: function (c) { return c === 1 ? '????????' : '??????????' },
      h: function (c) { return c === 1 ? '??????' : '????????' },
      m: function (c) { return c === 1 ? '??????????' : '??????????' },
      s: function (c) { return c === 1 ? '????????????????????????' : '????????????????????????' },
      ms: function (c) { return c === 1 ? '???????????????? ?????? ??????????????????????????' : '???????????????? ?????? ??????????????????????????' },
      decimal: ','
    },
    hu: {
      y: '??v',
      mo: 'h??nap',
      w: 'h??t',
      d: 'nap',
      h: '??ra',
      m: 'perc',
      s: 'm??sodperc',
      ms: 'ezredm??sodperc',
      decimal: ','
    },
    id: {
      y: 'tahun',
      mo: 'bulan',
      w: 'minggu',
      d: 'hari',
      h: 'jam',
      m: 'menit',
      s: 'detik',
      ms: 'milidetik',
      decimal: '.'
    },
    is: {
      y: '??r',
      mo: function (c) { return 'm??nu??' + (c !== 1 ? 'ir' : 'ur') },
      w: function (c) { return 'vik' + (c !== 1 ? 'ur' : 'a') },
      d: function (c) { return 'dag' + (c !== 1 ? 'ar' : 'ur') },
      h: function (c) { return 'klukkut??m' + (c !== 1 ? 'ar' : 'i') },
      m: function (c) { return 'm??n??t' + (c !== 1 ? 'ur' : 'a') },
      s: function (c) { return 'sek??nd' + (c !== 1 ? 'ur' : 'a') },
      ms: function (c) { return 'millisek??nd' + (c !== 1 ? 'ur' : 'a') },
      decimal: '.'
    },
    it: {
      y: function (c) { return 'ann' + (c !== 1 ? 'i' : 'o') },
      mo: function (c) { return 'mes' + (c !== 1 ? 'i' : 'e') },
      w: function (c) { return 'settiman' + (c !== 1 ? 'e' : 'a') },
      d: function (c) { return 'giorn' + (c !== 1 ? 'i' : 'o') },
      h: function (c) { return 'or' + (c !== 1 ? 'e' : 'a') },
      m: function (c) { return 'minut' + (c !== 1 ? 'i' : 'o') },
      s: function (c) { return 'second' + (c !== 1 ? 'i' : 'o') },
      ms: function (c) { return 'millisecond' + (c !== 1 ? 'i' : 'o') },
      decimal: ','
    },
    ja: {
      y: '???',
      mo: '???',
      w: '???',
      d: '???',
      h: '??????',
      m: '???',
      s: '???',
      ms: '?????????',
      decimal: '.'
    },
    ko: {
      y: '???',
      mo: '??????',
      w: '??????',
      d: '???',
      h: '??????',
      m: '???',
      s: '???',
      ms: '?????? ???',
      decimal: '.'
    },
    lt: {
      y: function (c) { return ((c % 10 === 0) || (c % 100 >= 10 && c % 100 <= 20)) ? 'met??' : 'metai' },
      mo: function (c) { return ['m??nuo', 'm??nesiai', 'm??nesi??'][getLithuanianForm(c)] },
      w: function (c) { return ['savait??', 'savait??s', 'savai??i??'][getLithuanianForm(c)] },
      d: function (c) { return ['diena', 'dienos', 'dien??'][getLithuanianForm(c)] },
      h: function (c) { return ['valanda', 'valandos', 'valand??'][getLithuanianForm(c)] },
      m: function (c) { return ['minut??', 'minut??s', 'minu??i??'][getLithuanianForm(c)] },
      s: function (c) { return ['sekund??', 'sekund??s', 'sekund??i??'][getLithuanianForm(c)] },
      ms: function (c) { return ['milisekund??', 'milisekund??s', 'milisekund??i??'][getLithuanianForm(c)] },
      decimal: ','
    },
    ms: {
      y: 'tahun',
      mo: 'bulan',
      w: 'minggu',
      d: 'hari',
      h: 'jam',
      m: 'minit',
      s: 'saat',
      ms: 'milisaat',
      decimal: '.'
    },
    nl: {
      y: 'jaar',
      mo: function (c) { return c === 1 ? 'maand' : 'maanden' },
      w: function (c) { return c === 1 ? 'week' : 'weken' },
      d: function (c) { return c === 1 ? 'dag' : 'dagen' },
      h: 'uur',
      m: function (c) { return c === 1 ? 'minuut' : 'minuten' },
      s: function (c) { return c === 1 ? 'seconde' : 'seconden' },
      ms: function (c) { return c === 1 ? 'milliseconde' : 'milliseconden' },
      decimal: ','
    },
    no: {
      y: '??r',
      mo: function (c) { return 'm??ned' + (c !== 1 ? 'er' : '') },
      w: function (c) { return 'uke' + (c !== 1 ? 'r' : '') },
      d: function (c) { return 'dag' + (c !== 1 ? 'er' : '') },
      h: function (c) { return 'time' + (c !== 1 ? 'r' : '') },
      m: function (c) { return 'minutt' + (c !== 1 ? 'er' : '') },
      s: function (c) { return 'sekund' + (c !== 1 ? 'er' : '') },
      ms: function (c) { return 'millisekund' + (c !== 1 ? 'er' : '') },
      decimal: ','
    },
    pl: {
      y: function (c) { return ['rok', 'roku', 'lata', 'lat'][getPolishForm(c)] },
      mo: function (c) { return ['miesi??c', 'miesi??ca', 'miesi??ce', 'miesi??cy'][getPolishForm(c)] },
      w: function (c) { return ['tydzie??', 'tygodnia', 'tygodnie', 'tygodni'][getPolishForm(c)] },
      d: function (c) { return ['dzie??', 'dnia', 'dni', 'dni'][getPolishForm(c)] },
      h: function (c) { return ['godzina', 'godziny', 'godziny', 'godzin'][getPolishForm(c)] },
      m: function (c) { return ['minuta', 'minuty', 'minuty', 'minut'][getPolishForm(c)] },
      s: function (c) { return ['sekunda', 'sekundy', 'sekundy', 'sekund'][getPolishForm(c)] },
      ms: function (c) { return ['milisekunda', 'milisekundy', 'milisekundy', 'milisekund'][getPolishForm(c)] },
      decimal: ','
    },
    pt: {
      y: function (c) { return 'ano' + (c !== 1 ? 's' : '') },
      mo: function (c) { return c !== 1 ? 'meses' : 'm??s' },
      w: function (c) { return 'semana' + (c !== 1 ? 's' : '') },
      d: function (c) { return 'dia' + (c !== 1 ? 's' : '') },
      h: function (c) { return 'hora' + (c !== 1 ? 's' : '') },
      m: function (c) { return 'minuto' + (c !== 1 ? 's' : '') },
      s: function (c) { return 'segundo' + (c !== 1 ? 's' : '') },
      ms: function (c) { return 'milissegundo' + (c !== 1 ? 's' : '') },
      decimal: ','
    },
    ru: {
      y: function (c) { return ['??????', '??????', '????????'][getSlavicForm(c)] },
      mo: function (c) { return ['??????????????', '??????????', '????????????'][getSlavicForm(c)] },
      w: function (c) { return ['????????????', '????????????', '????????????'][getSlavicForm(c)] },
      d: function (c) { return ['????????', '????????', '??????'][getSlavicForm(c)] },
      h: function (c) { return ['??????????', '??????', '????????'][getSlavicForm(c)] },
      m: function (c) { return ['??????????', '????????????', '????????????'][getSlavicForm(c)] },
      s: function (c) { return ['????????????', '??????????????', '??????????????'][getSlavicForm(c)] },
      ms: function (c) { return ['??????????????????????', '????????????????????????', '????????????????????????'][getSlavicForm(c)] },
      decimal: ','
    },
    uk: {
      y: function (c) { return ['??????????', '??????', '????????'][getSlavicForm(c)] },
      mo: function (c) { return ['??????????????', '????????????', '????????????'][getSlavicForm(c)] },
      w: function (c) { return ['????????????', '????????????', '????????????'][getSlavicForm(c)] },
      d: function (c) { return ['????????', '????????', '??????'][getSlavicForm(c)] },
      h: function (c) { return ['??????????', '????????????', '????????????'][getSlavicForm(c)] },
      m: function (c) { return ['????????????', '??????????????', '??????????????'][getSlavicForm(c)] },
      s: function (c) { return ['????????????', '??????????????', '??????????????'][getSlavicForm(c)] },
      ms: function (c) { return ['????????????????????', '??????????????????????', '??????????????????????'][getSlavicForm(c)] },
      decimal: ','
    },
    sv: {
      y: '??r',
      mo: function (c) { return 'm??nad' + (c !== 1 ? 'er' : '') },
      w: function (c) { return 'veck' + (c !== 1 ? 'or' : 'a') },
      d: function (c) { return 'dag' + (c !== 1 ? 'ar' : '') },
      h: function (c) { return 'timm' + (c !== 1 ? 'ar' : 'e') },
      m: function (c) { return 'minut' + (c !== 1 ? 'er' : '') },
      s: function (c) { return 'sekund' + (c !== 1 ? 'er' : '') },
      ms: function (c) { return 'millisekund' + (c !== 1 ? 'er' : '') },
      decimal: ','
    },
    tr: {
      y: 'y??l',
      mo: 'ay',
      w: 'hafta',
      d: 'g??n',
      h: 'saat',
      m: 'dakika',
      s: 'saniye',
      ms: 'milisaniye',
      decimal: ','
    },
    vi: {
      y: 'n??m',
      mo: 'th??ng',
      w: 'tu???n',
      d: 'ng??y',
      h: 'gi???',
      m: 'ph??t',
      s: 'gi??y',
      ms: 'mili gi??y',
      decimal: ','
    },
    zh_CN: {
      y: '???',
      mo: '??????',
      w: '???',
      d: '???',
      h: '??????',
      m: '??????',
      s: '???',
      ms: '??????',
      decimal: '.'
    },
    zh_TW: {
      y: '???',
      mo: '??????',
      w: '???',
      d: '???',
      h: '??????',
      m: '??????',
      s: '???',
      ms: '??????',
      decimal: '.'
    }
  }

  // You can create a humanizer, which returns a function with default
  // parameters.
  function humanizer (passedOptions) {
    var result = function humanizer (ms, humanizerOptions) {
      var options = extend({}, result, humanizerOptions || {})
      return doHumanization(ms, options)
    }

    return extend(result, {
      language: 'en',
      delimiter: ', ',
      spacer: ' ',
      conjunction: '',
      serialComma: true,
      units: ['y', 'mo', 'w', 'd', 'h', 'm', 's'],
      languages: {},
      round: false,
      unitMeasures: {
        y: 31557600000,
        mo: 2629800000,
        w: 604800000,
        d: 86400000,
        h: 3600000,
        m: 60000,
        s: 1000,
        ms: 1
      }
    }, passedOptions)
  }

  // The main function is just a wrapper around a default humanizer.
  var humanizeDuration = humanizer({})

  // doHumanization does the bulk of the work.
  function doHumanization (ms, options) {
    var i, len, piece

    // Make sure we have a positive number.
    // Has the nice sideffect of turning Number objects into primitives.
    ms = Math.abs(ms)

    var dictionary = options.languages[options.language] || languages[options.language]
    if (!dictionary) {
      throw new Error('No language ' + dictionary + '.')
    }

    var pieces = []

    // Start at the top and keep removing units, bit by bit.
    var unitName, unitMS, unitCount
    for (i = 0, len = options.units.length; i < len; i++) {
      unitName = options.units[i]
      unitMS = options.unitMeasures[unitName]

      // What's the number of full units we can fit?
      if (i + 1 === len) {
        unitCount = ms / unitMS
      } else {
        unitCount = Math.floor(ms / unitMS)
      }

      // Add the string.
      pieces.push({
        unitCount: unitCount,
        unitName: unitName
      })

      // Remove what we just figured out.
      ms -= unitCount * unitMS
    }

    var firstOccupiedUnitIndex = 0
    for (i = 0; i < pieces.length; i++) {
      if (pieces[i].unitCount) {
        firstOccupiedUnitIndex = i
        break
      }
    }

    if (options.round) {
      var ratioToLargerUnit, previousPiece
      for (i = pieces.length - 1; i >= 0; i--) {
        piece = pieces[i]
        piece.unitCount = Math.round(piece.unitCount)

        if (i === 0) { break }

        previousPiece = pieces[i - 1]

        ratioToLargerUnit = options.unitMeasures[previousPiece.unitName] / options.unitMeasures[piece.unitName]
        if ((piece.unitCount % ratioToLargerUnit) === 0 || (options.largest && ((options.largest - 1) < (i - firstOccupiedUnitIndex)))) {
          previousPiece.unitCount += piece.unitCount / ratioToLargerUnit
          piece.unitCount = 0
        }
      }
    }

    var result = []
    for (i = 0, pieces.length; i < len; i++) {
      piece = pieces[i]
      if (piece.unitCount) {
        result.push(render(piece.unitCount, piece.unitName, dictionary, options))
      }

      if (result.length === options.largest) { break }
    }

    if (result.length) {
      if (!options.conjunction || result.length === 1) {
        return result.join(options.delimiter)
      } else if (result.length === 2) {
        return result.join(options.conjunction)
      } else if (result.length > 2) {
        return result.slice(0, -1).join(options.delimiter) + (options.serialComma ? ',' : '') + options.conjunction + result.slice(-1)
      }
    } else {
      return render(0, options.units[options.units.length - 1], dictionary, options)
    }
  }

  function render (count, type, dictionary, options) {
    var decimal
    if (options.decimal === void 0) {
      decimal = dictionary.decimal
    } else {
      decimal = options.decimal
    }

    var countStr = count.toString().replace('.', decimal)

    var dictionaryValue = dictionary[type]
    var word
    if (typeof dictionaryValue === 'function') {
      word = dictionaryValue(count)
    } else {
      word = dictionaryValue
    }

    return countStr + options.spacer + word
  }

  function extend (destination) {
    var source
    for (var i = 1; i < arguments.length; i++) {
      source = arguments[i]
      for (var prop in source) {
        if (source.hasOwnProperty(prop)) {
          destination[prop] = source[prop]
        }
      }
    }
    return destination
  }

  // Internal helper function for Czech language.
  function getCzechForm (c) {
    if (c === 1) {
      return 0
    } else if (Math.floor(c) !== c) {
      return 1
    } else if (c % 10 >= 2 && c % 10 <= 4 && c % 100 < 10) {
      return 2
    } else {
      return 3
    }
  }

  // Internal helper function for Polish language.
  function getPolishForm (c) {
    if (c === 1) {
      return 0
    } else if (Math.floor(c) !== c) {
      return 1
    } else if (c % 10 >= 2 && c % 10 <= 4 && !(c % 100 > 10 && c % 100 < 20)) {
      return 2
    } else {
      return 3
    }
  }

  // Internal helper function for Russian and Ukranian languages.
  function getSlavicForm (c) {
    if (Math.floor(c) !== c) {
      return 2
    } else if ((c % 100 >= 5 && c % 100 <= 20) || (c % 10 >= 5 && c % 10 <= 9) || c % 10 === 0) {
      return 0
    } else if (c % 10 === 1) {
      return 1
    } else if (c > 1) {
      return 2
    } else {
      return 0
    }
  }

  // Internal helper function for Lithuanian language.
  function getLithuanianForm (c) {
    if (c === 1 || (c % 10 === 1 && c % 100 > 20)) {
      return 0
    } else if (Math.floor(c) !== c || (c % 10 >= 2 && c % 100 > 20) || (c % 10 >= 2 && c % 100 < 10)) {
      return 1
    } else {
      return 2
    }
  }

  humanizeDuration.getSupportedLanguages = function getSupportedLanguages () {
    var result = []
    for (var language in languages) {
      if (languages.hasOwnProperty(language)) {
        result.push(language)
      }
    }
    return result
  }

  humanizeDuration.humanizer = humanizer

  if (typeof define === 'function' && define.amd) {
    define(function () {
      return humanizeDuration
    })
  } else if (typeof module !== 'undefined' && module.exports) {
    module.exports = humanizeDuration
  } else {
    this.humanizeDuration = humanizeDuration
  }
})();  // eslint-disable-line semi
