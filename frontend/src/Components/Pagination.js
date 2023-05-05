import React from "react";

export default function Pagination({gotoNextPage, gotoPrevPage}) {
    return(
        <div>
            {gotoNextPage && <button onClick={gotoNextPage} className="pagination-button"> Next </button> }
            {gotoNextPage && <button onClick={gotoNextPage} className="pagination-button"> Next </button> }
        </div>
    )
}