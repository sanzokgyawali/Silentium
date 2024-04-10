import React from 'react';
import Avataruser from './Images_/avatar.png';
import './Msgpage.css';
import ChatFooter from './ChatFooter';

import ChatIconpage from './ChatIconpage';
import Messagecomponent from './Messagecomponent';

const Msgpage = () => {

  return <>
  <div className='pageSetup_Wrap'>
  <ChatIconpage/>
  <Messagecomponent/>
    <div className='msgpage_Messanger'>
        <div className='msgHeader_Component'>
            <div className='userDetails_Msg'>
                <div> <img src={Avataruser} className="avatar" alt="" /></div>
                <div className='userName_Msg'>Barbie</div>
            </div>
            <div className='about_msg'><i class="fa-solid fa-circle-info"></i></div>
        </div>
        <div className='separationLine'></div>
        <div className='display_Msg_Component'>
        </div>
        <ChatFooter/>
      
    </div>
    </div>
  </>
}

export default Msgpage
