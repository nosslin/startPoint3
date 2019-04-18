"use strict";

var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

var _get = function get(_x, _x2, _x3) { var _again = true; _function: while (_again) { var object = _x, property = _x2, receiver = _x3; _again = false; if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { _x = parent; _x2 = property; _x3 = receiver; _again = true; desc = parent = undefined; continue _function; } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Link = (function (_React$Component) {
    _inherits(Link, _React$Component);

    function Link() {
        _classCallCheck(this, Link);

        _get(Object.getPrototypeOf(Link.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(Link, [{
        key: "render",
        value: function render() {
            return React.createElement(
                "li",
                { className: "bookMarkLi" },
                React.createElement(
                    "a",
                    { className: "bookmarkLink", href: this.props.link.link },
                    React.createElement("img", { src: this.props.link.imgUrl, width: "75", height: "75" }),
                    React.createElement(
                        "div",
                        null,
                        this.props.link.name
                    )
                )
            );
        }
    }]);

    return Link;
})(React.Component);

var LinkSection = (function (_React$Component2) {
    _inherits(LinkSection, _React$Component2);

    function LinkSection() {
        _classCallCheck(this, LinkSection);

        _get(Object.getPrototypeOf(LinkSection.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(LinkSection, [{
        key: "render",
        value: function render() {
            var _this = this;

            var linksToRender = this.props.section.links.map(function (linkA, index) {
                return React.createElement(Link, { key: 'link_' + _this.props.sectionIndex + index, link: linkA });
            });

            return React.createElement(
                "div",
                { className: "container" },
                React.createElement(
                    "h3",
                    null,
                    this.props.section.name
                ),
                React.createElement(
                    "ul",
                    { className: "row" },
                    linksToRender
                )
            );
        }
    }]);

    return LinkSection;
})(React.Component);

var Links = (function (_React$Component3) {
    _inherits(Links, _React$Component3);

    function Links(props) {
        _classCallCheck(this, Links);

        _get(Object.getPrototypeOf(Links.prototype), "constructor", this).call(this, props);
        this.state = getLinkData();
    }

    _createClass(Links, [{
        key: "render",
        value: function render() {

            var sections = this.state.sections.map(function (sectionA, index) {
                return React.createElement(LinkSection, { key: 'section_' + index, section: sectionA, sectionIndex: index });
            });

            return React.createElement(
                "div",
                { className: "container body-content" },
                sections
            );
        }
    }]);

    return Links;
})(React.Component);

ReactDOM.render(React.createElement(Links, null), document.getElementById("root"));

