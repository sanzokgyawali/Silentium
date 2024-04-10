import React from 'react';
import './newsfeed.css';
import Avataruser from './Img/avatar.png';
import { Link } from 'react-router-dom';

import Createpostpage from './Createpostpage';
import { useContext } from 'react';
import { AppContext, useGlobalContext } from '../Context/context';
import NewsPost from './NewsPost';

const Newsfeed = () => {
    const { app_Name } = useGlobalContext();
    return <>
        <div>

            <div className='newsFeed'>

                <div className='post_User_Info'>

                    <div>
                        <img src={Avataruser} className="avatars" alt="" />
                    </div>
                    <Link to='/Createpostpage'>
                        <div className='post_page_Button'>What’s on your mind?</div>
                    </Link>
                </div>


            </div>
            <NewsPost/>
        </div>

    </>
}
export default Newsfeed
