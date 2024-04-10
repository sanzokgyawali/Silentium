import React from 'react';
import appSymbolLogo from './Img/appsymbolLogo.png';
import { LuMessageSquare } from "react-icons/lu";
import { IconContext } from "react-icons";
import Avataruser from './Img/avatar.png';
import './header.css';
import { NavLink } from 'react-router-dom';


const Header = () => {

    const storedUsername = localStorage.getItem('anonymousName');
    return (
        <div className='navBar'>
            <div className='appSymbolLogo'>
                <img src={appSymbolLogo} className="dashboardlogo" alt="logo" />
            </div>

            {/* search */}
            <div className='searchMenu'>
                <div className='magnifying-glass'>

                <i class="fa-solid fa-magnifying-glass"></i>
                </div>

                <div className='searchbar'><input type="text"
                    placeholder=" Search "
                    name="search" className='search' /></div>
            </div>

            <div className='Modes'>
                
                <button className='messageBox_Icon'>
                <NavLink to='/Chatpage'>

                    <IconContext.Provider value={{ className: "msg-box" }}>
                        <div>
                            <LuMessageSquare />
                        </div>
                    </IconContext.Provider>
                    </NavLink>
                </button>
                
                <button className='notifiyIcon'>
                <i class="fa-regular fa-bell"></i>
                </button>
                <div className='avatarInfo'>
                    <div className='avatarName'>
                        <div className='avatar_Name'>{storedUsername}</div>
                        <div className='avatar_shortName'>Trial</div>
                    </div>

                    <div className='avatarImg'>
                    <img src={Avataruser} className="avatar" alt="" />
                    </div>
                </div>

            </div>

        </div>
    )
}

export default Header
