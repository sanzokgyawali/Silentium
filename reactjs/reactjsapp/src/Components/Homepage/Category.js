import React from 'react';
import './category.css';
import { NavLink } from 'react-router-dom';
import Avataruser from './Img/avatar.png';
const Category = () => {
    
  return (
    <div className='category_page_Container'>
        <div>
            <div className='category_Features'>
                <div className='category_Icon'>
                <i class="fa-solid fa-house"></i>
                </div>
                <div className='category_Title'><NavLink to='/Homepage'>Home</NavLink></div>
            </div>
            <div className='category_Features'>
                <div className='category_Icon'>
                <i class="fa-solid fa-magnifying-glass"></i>
                </div>
                <div className='category_Title'>Search</div>
            </div>
            <div className='category_Features'>
                <div className='category_Icon'>
                <i class="fa-solid fa-compass"></i>
                </div>
                <div className='category_Title'>Explore</div>
            </div>
            <div className='category_Features'>
                <div className='category_Icon'>
                <i class="fa-regular fa-message"></i>
                </div>
                <div className='category_Title'><NavLink to='/Chatpage'>Message</NavLink></div>
            </div>
            <div className='category_Features'>
                <div className='category_Icon'>
                <i class="fa-solid fa-circle-plus"></i>
                </div>
                <div className='category_Title'><NavLink to='/Createpostpage'>Create</NavLink></div>
            </div>
            <div className='category_Features'>
                <div className='category_Icon'>
                <i class="fa-regular fa-heart"></i>
                </div>
                <div className='category_Title'>Notification</div>
            </div>
            <div className='category_Features'>
                <div className='category_Icon'>
                <div className='avatarImg_profile'>
                    <img src={Avataruser} className="avatar_photo" alt="" />
                    </div>
                </div>
                <div className='category_Title'>Profile</div>
            </div>
        </div>
     
    </div>
  )
}

export default Category
