import React from 'react';
import Logo from './Images/Silentium_Logo.png';
import './screensaver.css';

const Screensaver = () => {
  return (
    <div className='screenSaverPage'>
      <img src={Logo} alt="" id='screenLogo' />
    </div>
  )
}

export default Screensaver
