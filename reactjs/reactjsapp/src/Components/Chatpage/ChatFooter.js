import React, { useState } from 'react';
import './chatfooter.css';

const ChatFooter = () => {
  const [message, setMessage] = useState('');

  const handleSendMessage = (e) => {
    e.preventDefault();
    console.log({ userName: localStorage.getItem('userName'), message });
    setMessage('');
  };
  return (
    <div className="chat__footer">
      <form className="chat_Box" onSubmit={handleSendMessage}>
        <div className='smileSticker'><i class="fa-regular fa-face-smile"></i></div>
        <input
          type="text"
          placeholder="Messages..."
          className="message_box"
          value={message}
          onChange={(e) => setMessage(e.target.value)}
        />
        <div className='microphone'><i class="fa-solid fa-microphone"></i></div>
        <div className='reactsIcon'><i class="fa-regular fa-heart"></i></div>
        <button className="sendBtn"><i class="fa-solid fa-paper-plane"></i></button>
      </form>
    </div>
  );
};

export default ChatFooter;