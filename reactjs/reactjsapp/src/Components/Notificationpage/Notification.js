import React from 'react';
import Header from '../Homepage/Header';
import Category from '../Homepage/Category';
import './notification.css';
import profile_Img from './Img_files/profile_Img.png';


const Notification = () => {
  return <>

            <div className='notification_Page'>
                <div className='info_More'><i class="fa-solid fa-ellipsis"></i></div>
                <div className='user_Profile_Details'>
                    <div><img src={profile_Img} className="profile" alt="" /></div>
                    <div className='profile_UserInfo'>
                        <div className='notify_Msg'>Flower has accepted your request</div>
                        <div className='notify_Time'>1m ago</div>
                    </div>
                   
                </div>

            </div>


  </>
}

export default Notification

