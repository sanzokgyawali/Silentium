import React from 'react';
import { useGlobalContext } from '../Context/context';
import './newsPost.css';
import avatar_red from './Img/avatar-red.png';
/*import Result from './Result';*/




const NewsPost = () => {
    const { isLoading, result, isError } = useGlobalContext();
   
   
    if (isLoading) {
        return <div>.......Loading</div>
    }
    if (isError) {
        return <p>Error loading data</p>;
    }
  
  
    return (
        <div className='newsPost_FeedContainer'>

            {result.map(curElem => (
                <div className='newsComponents' key={curElem.postId}>

                    <div className='newsComponentss' key={curElem.userId}>
                        <div className='user_Details_News_Info'>
                            <div className='User_Information_Info'>
                                <img src={avatar_red} className="avatar_Img_photo" alt="" />

                            </div>
                            <div className='user_Info_news'>
                                <div className='UserName_Info_details'>
                                    {curElem.userAvatar}
                                </div>
                            </div>
                            
                      </div>

                        <div className='caption_Details'>
                            {curElem.caption}
                        </div>
                        <div className='tags_Details'>
                            {curElem.tags}
                        </div>
                        {/*<div>*/}
                        {/*    <h2>{curElem.timeofPost}</h2>*/}
                        {/*</div>*/}
                        <div className='comments_Details'>
                            <i class="fa-solid fa-comment-dots"></i>
                        <div className='comments'>
                            {curElem.numberOfComments}  Comments
                            </div>
                        </div>
                    </div>
                </div>
            ))}
               

            </div>

       
   );
}

export default NewsPost;


 
