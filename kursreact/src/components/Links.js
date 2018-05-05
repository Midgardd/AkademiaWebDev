import React from 'react';
import UtilsApi from '../utils/utils_api';
import CFG_HTTP from '../cfg/cfg_http';
import LinksTable from './LinkTable';
import Pagination from './Pagination';
import { Link } from 'react-router-dom';
import Icon from 'material-ui/Icon';


class Links extends React.Component {
    onPageChange = (pageNumber) => {
        this.fetchLinks(this.state.search, pageNumber);
    }
    
    fetchLinks = (searchedLink='',pageNumber=1) => {
        let message = {
            Page: pageNumber,
            Search: searchedLink,
        }

        UtilsApi
            .get(CFG_HTTP.URL_LINKS, message)
            .then((returnedData) => {
                this.setState({
                    links: returnedData.links,
                    currentPage: returnedData.pageInformation.currentPage,
                    pagesLimit: returnedData.pageInformation.maxPage
                })
            })
    }

    componentDidMount() {
        this.fetchLinks();
    }

    constructor() {
        super();
        this.state = {
            links: [],
            search: '',
            currentPage: 1,
            pagesLimit:0
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
                <Pagination currentPage={this.state.currentPage}
                    pagesLimit={this.state.pagesLimit}
                    onPageChange={this.onPageChange} />
                <LinksTable links={this.state.links}
                    fetchLinks={this.fetchLinks} />

            </React.Fragment>
            )
    }
}

export default Links;