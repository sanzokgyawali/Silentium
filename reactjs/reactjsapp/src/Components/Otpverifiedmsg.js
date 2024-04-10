import React from 'react';
import checkedTickMark from './Images/Checked.png';
import './otpverified.css';
import { Link } from 'react-router-dom';
import {useEffect} from 'react';





const Otpverifiedmsg = () => {

    useEffect(()=>
    {
      const handleGoingBack = (event)=>
      {
       event.preventDefault();
       const message = "You are not allowed to go back" ;
       event.returnValue= message;
       return message;
      };

      window.addEventListener('beforeunload', handleGoingBack);

     return () =>
      {
        window.removeEventListener('beforeunload', handleGoingBack);
      };
    },[]);



    return (
        <section>
            <Link to='/Homepage'>
            <div className='checkedLogo'>
                <img src={checkedTickMark} alt="" id='checkedTickMark' />
            </div>
            <div className='verifiedMsg'>
            Phone Number Verified
            </div>
            <div className='msgre'>
            <div className='redirectMsg'>
            You will be redirected to the main page 
                  in a few moments
            </div>
            </div>
            </Link>

        </section>
    )
}

export default Otpverifiedmsg
