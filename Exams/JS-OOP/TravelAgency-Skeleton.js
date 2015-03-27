function processTravelAgencyCommands(commands) {
    'use strict';

    Object.prototype.extend = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    var Models = (function () {

        var CONSTANTS = {
            CRUISE_TRANSPORT: "cruise liner",
            MONTH_NAMES: ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
                "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
        };

        var printDestinations = function printDestinations() {
            var destinations = "";

            if (this._destinations.length > 0) {
                this._destinations.forEach(function (destination) {
                    destinations += destination.toString() + ";";
                });
            } else {
                return "-";
            }

            return destinations.substring(0, destinations.length - 1);
        };

        var Destination = (function () {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }

            Destination.prototype.getLocation = function () {
                return this._location;
            };

            Destination.prototype.setLocation = function (location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            };

            Destination.prototype.getLandmark = function () {
                return this._landmark;
            };

            Destination.prototype.setLandmark = function (landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            };

            Destination.prototype.toString = function () {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            };

            return Destination;
        }());

        var Travel = (function () {
            function Travel(name, startDate, endDate, price) {

                if (this.constructor === Travel) {
                    throw new Error("Invalid command.");
                }

                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);
            }

            Travel.prototype.getName = function getName() {
                return this._name;
            };
            Travel.prototype.setName = function setName(name) {
                if (!name || typeof name !== "string") {
                    throw new Error("Invalid command.");
                }

                this._name = name;
            };

            Travel.prototype.getStartDate = function getStartDate() {
                return this._startDate;
            };
            Travel.prototype.setStartDate = function setStartDate(startDate) {
                if (!new Date(startDate)) {
                    throw new Error("Invalid command.");
                }

                this._startDate = getDateFormat(startDate);
            };

            Travel.prototype.getEndDate = function getEndDate() {
                return this._endDate;
            };
            Travel.prototype.setEndDate = function setEndDate(endDate) {
                if (!new Date(endDate)) {
                    throw new Error("Invalid command.");
                }

                this._endDate = getDateFormat(endDate);
            };

            Travel.prototype.getPrice = function getPrice() {
                return this._price;
            };
            Travel.prototype.setPrice = function setPrice(price) {
                if (typeof price !== "number" || price < 0) {
                    throw new Error("Invalid command.");
                }

                this._price = price;
            };

            Travel.prototype.toString = function () {
                return " * " + this.constructor.name +
                    ": name=" + this._name +
                    ",start-date=" + this._startDate +
                    ",end-date=" + this._endDate +
                    ",price=" + this._price.toFixed(2);
            };

            var getDateFormat = function formatDate(date) {
                var d = new Date(date),
                    date = d.getDate(),
                    month = d.getMonth(),
                    year = d.getFullYear();

                return date + "-" + CONSTANTS.MONTH_NAMES[month] + "-" + year;
            };

            return Travel;

        }());

        var Excursion = (function () {
            function Excursion(name, startDate, endDate, price, transport) {
                Travel.call(this, name, startDate, endDate, price);

                this.setTransport(transport);
                this._destinations = [];
            }

            Excursion.extend(Travel);

            Excursion.prototype.getTransport = function getTransport() {
                return this._transport;
            };
            Excursion.prototype.setTransport = function (transport) {
                if (typeof transport !== "string" || !transport) {
                    throw new Error("Invalid command.");
                }

                this._transport = transport;
            };

            Excursion.prototype.addDestination = function addDestination(destination) {
                if (!(destination instanceof Destination)) {
                    throw new Error("Invalid command.");
                }

                this._destinations.push(destination);
            };
            Excursion.prototype.removeDestination = function removeDestination(destination) {
                if (!(destination instanceof Destination) || this._destinations.length <= 0) {
                    throw new Error("Invalid command.");
                }

                var destinationIndex = this._destinations.indexOf(destination);
                this._destinations.splice(destinationIndex, 1);
            };

            Excursion.prototype.toString = function () {
                return Travel.prototype.toString.call(this) +
                    ",transport=" + this._transport +
                    "\r\n ** Destinations: " + printDestinations.call(this);
            };

            return Excursion;

        }());

        var Vacation = (function () {
            function Vacation(name, startDate, endDate, price, location, accommodation) {
                Travel.call(this, name, startDate, endDate, price);

                this.setLocation(location);
                this.setAccommodation(accommodation);
            }

            Vacation.extend(Travel);

            Vacation.prototype.getLocation = function getLocation() {
                return this._location;
            };
            Vacation.prototype.setLocation = function (location) {
                if (typeof location !== "string" || !location) {
                    throw new Error("Invalid command.");
                }

                this._location = location;
            };

            Vacation.prototype.getAccommodation = function getAccommodation() {
                return this._accommodation;
            };
            Vacation.prototype.setAccommodation = function (accommodation) {
                if ((location && typeof location !== "string") || accommodation === "") {
                    throw new Error("Invalid command.");
                }

                this._accommodation = accommodation;
            };

            Vacation.prototype.toString = function () {
                return Travel.prototype.toString.call(this) +
                    ",location=" + this._location +
                    (this._accommodation ? ",accommodation=" + this._accommodation : "");
            };

            return Vacation;

        }());

        var Cruise = (function () {
            function Cruise(name, startDate, endDate, price, startDock) { // Always "cruise liner"
                Excursion.call(this, name, startDate, endDate, price, CONSTANTS.CRUISE_TRANSPORT);

                this.setStartDock(startDock);
            }

            Cruise.extend(Excursion);

            Cruise.prototype.getStartDock = function getStartDock() {
                return this._startDock;
            };
            Cruise.prototype.setStartDock = function setStartDock(startDock) {
                if (this._startDock === "") {
                    throw new Error("Invalid command.");
                }

                this._startDock = startDock;
            };

            Cruise.prototype.toString = function () {
                return Travel.prototype.toString.call(this) +
                    ",transport=" + this._transport +
                        //(this._startDock ? ",start-dock=" + this._startDock : "") +
                    "\r\n ** Destinations: " + printDestinations.call(this);
            };

            return Cruise;

        }());

        return {
            Destination: Destination,
            Travel: Travel,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise
        }
    }());

    var TravellingManager = (function () {
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function () {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function (t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processFilterTravelsCommand(command) {
                var filter = {
                    type: command["type"],
                    minPrice: command["price-min"],
                    maxPrice: command["price-max"]
                };

                return formatTravelsQuery(_travels, filter);
            }

            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.getName() + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.getName() + ".";
            }

            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travelsQuery, filter) {
                if (travelsQuery.length <= 0) {
                    return "No results.";
                }

                var queryString = "";

                if (filter && filter.type !== "all") {
                    queryString += travelsQuery.filter(function (travel) {
                        return travel.constructor.name.toLowerCase() === filter.type.toLowerCase() &&
                            travel._price > filter.minPrice && travel._price < filter.maxPrice;
                    }).join("\n");
                } else {
                    queryString += travelsQuery.join("\n");
                }

                return queryString;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand,
                processFilterTravelsCommand: processFilterTravelsCommand
            }
        }());

        var Command = (function () {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }

    var output = "";
    TravellingManager.init();

    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

//(function () {
//    var arr = [];
//    if (typeof (require) == 'function') {
//        // We are in node.js --> read the console input and process it
//        require('readline').createInterface({
//            input: process.stdin,
//            output: process.stdout
//        }).on('line', function (line) {
//            arr.push(line);
//        }).on('close', function () {
//            console.log(processTravelAgencyCommands(arr));
//        });
//    }
//})();