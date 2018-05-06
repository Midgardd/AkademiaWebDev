import { LINKS_LOADED,CHANGE_PAGE } from '../actions/links.actions'

const links = (state = { links:[],maxPage:1,currentPage:1 }, action) => {
    switch (action.type) {
        case LINKS_LOADED:
            return Object.assign({}, state, action.content);
        case CHANGE_PAGE:
            return Object.assign({}, state, { currentPage: action.content.selectedPage });
        default:
            return state;
    }
}

export default links;