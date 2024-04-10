import React from 'react'

const Result = (curElem) => {
    const { userName, userAvatar, caption, tags, timeofPost, numberOfComments } = curElem;
    return (
        <div>

            <figure>
                <figcaption className='capt'>
                    {userName}
                </figcaption>
            </figure>
            <div>
                <h1>{userAvatar}</h1>
            </div>
            <div>
                <h2>{caption}</h2>
            </div>
            <div>
                <h2>{tags}</h2>
            </div>
            <div>
                <h2>{timeofPost}</h2>
            </div>
            <div>
                <h2>{numberOfComments}</h2>
            </div>
        </div>
    )
}

export default Result
