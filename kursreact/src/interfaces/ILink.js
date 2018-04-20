import PropTypes from "prop-types";

const ILink = PropTypes.shape({
    OriginalLink: PropTypes.number.required,
    Hash: PropTypes.string.required,
    Visitors: PropTypes.number.required
})

export default ILink