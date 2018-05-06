export const LINKS_LOADED = 'LINKS_LOADED';
export const CreateLinksLoaded = (links, currentPage, maxPage) => {
    return {
        type: LINKS_LOADED,
        content: {
            links:links,
            currentPage,
            maxPage
        }
    }
}

export const CHANGE_PAGE = 'CHANGE_PAGE';
export const CreateChangePage = function (selectedPage) {
    return {
        type: CHANGE_PAGE,
        content: {
            selectedPage
        }
    }
}