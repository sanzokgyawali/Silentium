import React from 'react';
import './messagecomponent.css';
import Avataruser from './Images_/avatar.png';
import { NavLink } from 'react-router-dom';

const Messagecomponent = () => {
    return (
        <div className='msgPage'>
            <div className='user_Name'>Rabbit_Trial</div>
            <div className='msg_feature_Component'>
                <button className='msg'>Messages</button>
                <button className='req'>Requests</button>
            </div>
            <div className='all_Message_Details'>


                <NavLink to='/Msgpage' className='info_Test'>
                    <div className='message_user_Component'>
                        <div>
                            <img src={Avataruser} className="avatar" alt="" />
                        </div>

                        <div className='user_Info'>

                            <div className='userName_Info'>Flower_</div>
                            <div className='user_Msg_Info'>What's up?</div>

                        </div>

                    </div>
                </NavLink>

                <div className='message_user_Component'>
                    <div>
                        <img src={Avataruser} className="avatar" alt="" />
                    </div>
                    <div className='user_Info'>
                        <div className='userName_Info'>Flower_</div>
                        <div className='user_Msg_Info'>What's up?</div>
                    </div>
                </div>
                <div className='message_user_Component'>
                    <div>
                        <img src={Avataruser} className="avatar" alt="" />
                    </div>
                    <div className='user_Info'>
                        <div className='userName_Info'>Flower_</div>
                        <div className='user_Msg_Info'>What's up?</div>
                    </div>
                </div>
                <div className='message_user_Component'>
                    <div>
                        <img src={Avataruser} className="avatar" alt="" />
                    </div>
                    <div className='user_Info'>
                        <div className='userName_Info'>Flower_</div>
                        <div className='user_Msg_Info'>What's up?</div>
                    </div>
                </div>
                <div className='message_user_Component'>
                    <div>
                        <img src={Avataruser} className="avatar" alt="" />
                    </div>
                    <div className='user_Info'>
                        <div className='userName_Info'>Flower_</div>
                        <div className='user_Msg_Info'>What's up?</div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Messagecomponent
