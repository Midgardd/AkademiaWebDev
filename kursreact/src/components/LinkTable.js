import Grid from 'material-ui/Grid';
import PropTypes from 'prop-types';
import React from 'react';
import Table, {
    TableBody,
    TableCell,
    TableHead,
    TableRow
} from 'material-ui/Table';
import '../styles/_table.scss';

import ILink from '../interfaces/ILink';

const LinksTable = function (props) {
    var rowsComponents = props.links.map((item, index) => {
        return (
            <TableRow key={item.hash}>
                <TableCell>{item.originalLink}</TableCell>
                <TableCell>{item.hash}</TableCell>
                <TableCell>{item.visitors}</TableCell>
            </TableRow>
        )
    });

    return (
        <Grid className="linkTable" container>
            <Grid item xs={12} md={8}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Original Link</TableCell>
                            <TableCell>Hash</TableCell>
                            <TableCell>Visitors</TableCell>
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

LinksTable.PropTypes - {
    links: PropTypes.arrayOf(ILink)
}

export default LinksTable;