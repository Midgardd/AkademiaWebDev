import Grid from 'material-ui/Grid';
import PropTypes from 'prop-types';
import React from 'react';
import Table, {
    TableBody,
    TableCell,
    TableHead,
    TableRow
} from 'material-ui/Table';
import { Icon } from 'material-ui';
import { Link } from 'react-router-dom';

import ILink from '../interfaces/ILink';

import UtilsApi from '../utils/utils_api';
import CFG_HTTP from '../cfg/cfg_http';

class LinksTable extends React.Component {

    handleDelete(hash){
        UtilsApi.delete(CFG_HTTP.URL_LINKS, { hash }).then(() => {
            console.log('success');
            this.props.fetchLinks();
        });
    };

    generateRow = (item, index) => {
        return (
            <TableRow key={item.hash}>
                <TableCell>{item.originalLink}</TableCell>
                <TableCell>{item.hash}</TableCell>
                <TableCell>{item.visitors}</TableCell>
                <TableCell className="linkTable__delete">
                    <Icon onClick={() => this.handleDelete(item.hash)}>delete</Icon>
                </TableCell>
                <TableCell className="linkTable__edit">
                    <Link to={`/edit/${item.hash}`}>
                        <Icon>mode_edit</Icon>
                    </Link>
                </TableCell>
            </TableRow>
        )
    }

    render() {
        var rowsComponents = this.props.links.map(this.generateRow);

        return (
            <Grid className="linkTable" container>
                <Grid item xs={12} md={8}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Original Link</TableCell>
                                <TableCell>Hash</TableCell>
                                <TableCell>Visitors</TableCell>
                                <TableCell>Delete</TableCell>
                                <TableCell>Edit</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {rowsComponents}
                        </TableBody>
                    </Table>
                </Grid>
            </Grid>
        );
    }
}

LinksTable.PropTypes - {
    links: PropTypes.arrayOf(ILink),
    fetchLinks: PropTypes.func
}

export default LinksTable;