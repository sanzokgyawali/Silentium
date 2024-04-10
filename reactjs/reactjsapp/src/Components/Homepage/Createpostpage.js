import React,{useState} from 'react';
import './createpostpage.css';
import Header from "./Header";
import Category from './Category';
import Avataruser from './Img/avatar.png';
import Cookies from 'js-cookie';
import { NavLink, useNavigate } from "react-router-dom";

const Createpostpage = () => {

    const storedUsername = localStorage.getItem('anonymousName');
    const [postText, setPostText] = useState('');
    const [isPostSuccessful, setIsPostSuccessful] = useState('');
    const navigate = useNavigate();

    const cookieName = 'token';
    const isCookieSet = Cookies.get(cookieName);
    const handlePostTextChange = (e) => {
        setPostText(e.target.value);
        
    };
    

    const handleCancelMarkChange=(e)=>
    {
        navigate('/HomePage');
    };

    function SendPostToBackend() {

        if (isCookieSet !== undefined)
        {
        const apiUrl = `https://localhost:44311/api/services/app/AppPost/PostPosts`;
        const tags = postText.match(/#(\w+)/g);
        var combinedTags="";
        if (tags) {
             combinedTags = tags.join(' ');

        }
        
       
       


        fetch(apiUrl, {
            method: 'POST', // Use the appropriate HTTP method
            headers: {
                'Authorization': `Bearer ${cookieName}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                caption: postText,
                keywords: "",
                tags: combinedTags, }),  
            })
            .then((response) => {
                if (response.ok) {
                    // Request was successful
                    //navigate to next page
                    setIsPostSuccessful(true);
                    return response.json();
                } else {
                    // Handle errors here
                    //remain in the same page and show the error message
                    setIsPostSuccessful(false);
                    throw new Error('Failed to send to the backend');
                }
            })
            .then((data) => {
                console.log(data);
                //navigate to next page
            })
            .catch((error) => {
                // Handle errors here
                //remain in the same page and show the error message
               
                console.log(error);
            });
        }



    }

        

     
    return <>
        <Header />
        <div className='wrap_Page'>
            <Category />
            <div className='createpost_Page'>

                <div className='create_post'>
                    <button className='cancel_Mark' onClick={handleCancelMarkChange} ><i class="fa-solid fa-xmark"></i></button>
                </div>
                <div className='create_Heading_Title'>Create Post</div>
                <div className='separateLine'></div>
                <div className='user_post_Details'>
                    <div><img src={Avataruser} className="avatar" alt="" /></div>
                    <div className='user_Name_Details'>
                        <div className='avater_user_Name'>{storedUsername}</div>
                        <button className='status_user'><i class="fa-solid fa-earth-americas"></i> Public</button>
                    </div>
                </div>


                <div className='textInput_Details'>
                    <textarea
                        placeholder="What's on your mind?"
                        value={postText}
                        onChange={handlePostTextChange}
                    />
                </div>

                <button onClick={SendPostToBackend} className='postButton_function' disabled={postText.length === 0}>
                   
                    <span>Post</span>
                    {isPostSuccessful && (
                        
                            navigate('/HomePage')
                    )}
                       
                    
                </button>
            </div>
        </div>

 

         
        </>
}

export default Createpostpage
