import React from 'react';
import './chatpage.css';

import Messagecomponent from './Messagecomponent';
import Chatdescription from './Chatdescription';
import ChatIconpage from './ChatIconpage';


const Chatpage = () => {
    return <>
        <div className='chatComponent_page'>

            <div>
                <ChatIconpage/>
            </div>

            <div>
                <Messagecomponent/>
            </div>
            <div>
                <Chatdescription/>
            </div>
        </div>
   </>
}

export default Chatpage
