import React from 'react';
import UtilsApi from '../utils/utils_api';
import CFG_HTTP from '../cfg/cfg_http';
import LinksTable from './LinkTable';
import Pagination from './Pagination';
import { Link } from 'react-router-dom';
import Icon from 'material-ui/Icon';
import { CreateLinksLoaded, CreateChangePage } from '../actions/links.actions'
import { connect } from 'react-redux';

class LinksContainer extends React.Component {
    onPageChange = (pageNumber) => {
        this.props.dispatch(CreateChangePage(pageNumber));
    }
    
    fetchLinks = (Page=1) => {
        UtilsApi
            .get(CFG_HTTP.URL_LINKS, { Page })
            .then((returnedData) => {
                this.props.dispatch(CreateLinksLoaded(returnedData.links, returnedData.pageInformation.currentPage, returnedData.pageInformation.maxPage));
            })
    }

    componentDidMount() {
        this.fetchLinks();
    }

    constructor() {
        super();
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.state.currentPage !== nextProps.state.currentPage) {
            this.fetchLinks(nextProps.state.currentPage);
        }
    }
    
    render() {
        return (
            <React.Fragment>
                <Link to="/add">
                    <Icon className='searchbarIcons-icon'>
                        add
                     </Icon>
                </Link>
                <Pagination currentPage={this.props.state.currentPage}
                    maxPage={this.props.state.maxPage}
                    onPageChange={this.onPageChange} />
                <LinksTable links={this.props.state.links}
                    fetchLinks={this.fetchLinks} />

            </React.Fragment>
            )
    }
}

const mapStateToProps = state => {
    return {
        state: state.links
    };
};

const Links = connect(mapStateToProps)(LinksContainer);
export default Links;