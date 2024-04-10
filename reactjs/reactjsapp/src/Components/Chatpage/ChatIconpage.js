import React from 'react';
import { NavLink } from 'react-router-dom';
import Avataruser from './Images_/avatar.png';
import appSymbolLogo from './Images_/appsymbolLogo.png';

const ChatIconpage = () => {
  return <>
   <div className='category_Icons_Components'>
                <div className='appSymbol_Logo'>
                    <img src={appSymbolLogo} className="dashboardlogo" alt="logo" />
                </div>

                <div>
                    <div className='category_Features_chatpage'>
                        <div className='category_Icon'>
                            <NavLink to='/Homepage'>
                            <i class="fa-solid fa-house"></i></NavLink>
                        </div>
                    </div>

                    <div className='category_Features_chatpage'>
                        <div className='category_Icon'>
                            <i class="fa-solid fa-magnifying-glass"></i>
                        </div>
                    </div>
                    <div className='category_Features_chatpage'>
                        <div className='category_Icon'>
                            <i class="fa-solid fa-compass"></i>
                        </div>

                    </div>
                    <div className='category_Features_chatpage'>
                        <div className='category_Icon'>
                            <i class="fa-regular fa-message"></i>
                        </div>
                    </div>
                    <div className='category_Features_chatpage'>
                        <div className='category_Icon'>
                            <NavLink to='/Createpostpage'><i class="fa-solid fa-circle-plus"></i></NavLink>
                        </div>
                        <div className='category_Title'></div>
                    </div>
                    <div className='category_Features_chatpage'>
                        <div className='category_Icon'>
                            <i class="fa-regular fa-heart"></i>
                        </div>
                    </div>
                    <div className='category_Features_chatpage'>
                        <div className='category_Icon'>
                            <img src={Avataruser} className="avatar_photo" alt="" />
                        </div>
                    </div>
                    <div className='category_Features_chatpage_setting'>
                        <div className='category_Icon'>
                        <i class="fa-solid fa-bars"></i>
                        </div>
                    </div>

                </div>





            </div>
  </>
    
}

export default ChatIconpage
