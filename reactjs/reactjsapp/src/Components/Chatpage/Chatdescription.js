import React from 'react';
import './chatdescription.css';
import Logo from './Images_/Silentium_Logo.png';

const Chatdescription = () => {
  return (
    <div className='chat_Description'>
        <div className='logoSilentium'> <img src={Logo} alt="" id='silentiumlogo' /></div>
        <div className='yourMsg'>Your Messages</div>
        <div className='prvMsg'>Send private messages to a group</div>
      
    </div>
  )
}

export default Chatdescription
