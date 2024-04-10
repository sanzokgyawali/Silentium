import React, { useState, useEffect, useRef } from 'react';
import './verification.css';
import OtpInput, {ResendOTP} from 'otp-input-react';
import {Link} from 'react-router-dom';
import { NavLink, useNavigate } from "react-router-dom";
import Login from './Login.js';
import Cookies from 'js-cookie';


const Verificationpage = () => {
    const [otp, setOtp] = useState("");
    const [isVerified, setIsVerified] = useState(false);
    const [isResending, setIsResending] = useState(false);
    const [resendTimer, setResendTimer] = useState(0);
    const[correctOTP, setCorrectOTP] = useState('');
    const navigate = useNavigate();


    

    const [minutes, setMinutes] = useState(0);
    const [seconds, setSeconds] = useState(15);
    
    
    const storedPhoneNumber = localStorage.getItem('userPhoneNumber');
    
    // remove +977 from the phone number
    const phoneNumber = storedPhoneNumber;
    const handleOTPChange = (value) => {                //check if the otp has four data
        setOtp(value);
        if (value.length === 4)
        { 
            //navigate('/Otpverifiedmsg');
            verifyOTP(value);
            //<Link to='/Otpverifiedmsg' />
        }

        // Automatically verify OTP when it's complete (e.g., 4 digits)     
        
    };

    const verifyOTP = async (otpValue) => {



        const urlEncodedPhoneNumber = encodeURIComponent(phoneNumber);  //get the phone number from the cookie
        const urlEncodedotp = encodeURIComponent(otpValue);
        
        

        const apiUrl = `https://localhost:44311/api/services/app/OTP/GetVerifyOTP?userPhoneNumber=${urlEncodedPhoneNumber}&OTP=${urlEncodedotp}`;


        await fetch(apiUrl,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
                
            })
            .then((response) => response.json())
            .then((data) => {
                // Handle the data from the backend
                //data lai local storage ma store garne
                //avatar and  name in local storage
                //token in cookie
                if(data.result != null)
                    {
                        setIsVerified(true);
                    }

                if (data.success) {   //will receive true if the otp is valid and false if not valid
                    
                    document.cookie = `token=${data.result.token}`;
                    localStorage.setItem('anonymousName', data.result.anonymousName);
                    localStorage.setItem('avatar', data.result.avatar);
                    
                    //navigate('/Otpverifiedmsg');
                    //<Link to='/Otpverifiedmsg'/>
                     // navigate to the next page if true is obtained

                } else {
                    setIsVerified(false);  //remain in the same page and show the error message and  clean the otp field
                }
            })
            .catch((error) => {
                console.error('Error verifying OTP:', error);

            });
    };
            
               


    
    const resendOTP =  (async(otpValue) => {
        setMinutes(0);
        setSeconds(15);

       

            const response= await fetch(``, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ otp:otpValue })
            }
            .then((response) => response.json())
            .then((data) => {
                if (data.success) {
                    setIsResending(true);
                    // OTP has been resent, provide user feedback if needed
                }
            })
        
            .catch((error) => {
                console.error('Error resending OTP:', error);
            }));
            

    });


    useEffect(() => {

        const interval = setInterval (()=>
     {
      // decrease second if more than 0
      if (seconds > 0)
      {
          setSeconds(seconds -1);
      }
      if (seconds === 0)
      {
          if(minutes === 0)
          {
              clearInterval(interval);
          }
      
          else{
          setSeconds(59);
          setMinutes(minutes -1);
        }
        }
    },1000);

  return() =>
  {
      clearInterval(interval);
  };
},[seconds]);

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


useEffect(() => {
        let intervalId;

        if (isResending) {
            // Start the resend timer with a duration of 60 seconds (adjust as needed)
            setResendTimer(60);

            // Decrease the timer every second
            intervalId = setInterval(() => {
                setResendTimer((prevTimer) => prevTimer - 1);
            }, 1000);
        } else {
            // Clear the interval if the timer is not active
            clearInterval(intervalId);
        }

        // Cleanup the interval when the component unmounts
        return () => {
            clearInterval(intervalId);
        };
    }, [isResending]);

    return (
        <section>
            <div className='verificationTitle'>
                 Phone Verification 
            </div>
            <div className='enterMessageText'>
                 Please enter 4 digit verification code
            </div>
            <div className='otpInput'>
                <OtpInput value={otp} OTPLength={4} 
                otpType="number"
                 onChange={handleOTPChange} ></OtpInput>
                {isVerified ? (
                    navigate('/Otpverifiedmsg')
              ) : null}
               

                
            </div>
            
            <div className='resend'>
            
            {seconds > 0 || minutes > 0 ? (
             <div className="countdownText">
                Time Remaining {""}
                <span style={{fontWeight:600}}>
                    {minutes < 10 ? `0${minutes}`: minutes}:
                    {seconds < 10 ? `0${seconds}`: seconds}
                </span>
            </div>):
              (
               <div >
                  <p className="codeNotRecieve">Didn't recieve a code?</p>

                        {isResending? (
                            <p>Otp Resent! Check your inbox.</p>
                        ):
                        (<><button className='resendButton'
                         onResendClick={true}
                              onClick={resendOTP}
                                    disabled={seconds > 0 || minutes > 0}>Resend OTP</button>
                                    <div className={"incorrectPhoneNumber"}>
                                        <Link to="/">
                                            Click here to change Phone Number
                                        </Link>
                                    </div>   </>)
                        }  
                           
                   </div> )}
                    </div>
            {/*<div className={"incorrectPhoneNumber"}>
                <Link to="/">
                    Click here to change Phone Number
                </Link>
            </div>*/}
            
           
        </section>
    )
}

export default Verificationpage
