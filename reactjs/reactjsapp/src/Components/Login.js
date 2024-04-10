import './login.css';
import PhoneInput from 'react-phone-input-2';
import 'react-phone-input-2/lib/style.css';
import Logo from './Images/Silentium_Logo.png';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
//import {useHistory} from 'react-router-dom';
import Cookies from 'js-cookie';

import LoadingSpinner from './LoadingSpinner.js'


import React, { useState, useEffect } from 'react';


const Login = () => {
    const navigate = useNavigate();
    const [userPhoneNumber, setph] = useState("");
    const [countryCode, setCountryCode] = useState('');
    const [countryisAvailable, setcountryIsAvailable] = useState(true);
    const [isValid, setValid] = useState(true);
    const [isLoading, setLoader] = useState(false);
    const [clickCount, setClickCount] = useState(0);
    
    const[data, setData] =useState([]);
    const [isInputFocused, setIsInputFocused] = useState(false);

    //const navigate = useNavigate();

    const handleInputFocus = () => {
        setIsInputFocused(true);
    };

    const handleInputBlur = () => {
    setIsInputFocused(false);
    };
        
    
    const stringWithoutSpaces = userPhoneNumber.replace(/\s/g, '');
      //done to remove spaces from the phone number

    const urlEncodedPhoneNumber = encodeURIComponent(stringWithoutSpaces);

    const handlePhoneChange = (value, country, e, formattedValue) => {
        
       
        //setValid(true);
        setph(formattedValue);
        setCountryCode(country);
        setValid(validatePhoneNumber(value));
      
       
        // Store the phone number in local storage whenever it changes
    };
    const validatePhoneNumber = (userPhoneNumber) =>
    {
        // for 10 digit phone number only
        const PhoneNumberPattern = /^\d{13}$/;
       
         
        return PhoneNumberPattern.test(userPhoneNumber);
    }
    
    
       
    
    function sendPhoneNumberToBackend(e) {
        e.preventDefault();
       
        console.log(stringWithoutSpaces)

        //http://localhost:3002/
        setClickCount(prevCount => prevCount +1);
        setLoader(true);

        const apiUrl = `https://localhost:44311/api/services/app/OTP/SendOTP?userPhoneNumber=${urlEncodedPhoneNumber}`;
    
        
        if ((stringWithoutSpaces.substring(0, 4) === "+977") && (stringWithoutSpaces.length === 14)&&(clickCount <2))  //check if the country code is available
        //if not available then show the error message in the same page
        {
            //setClickCount(prevCount => prevCount +1);
            console.log(stringWithoutSpaces)

            

            fetch(apiUrl, {
                method: 'POST', // Use the appropriate HTTP method
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ userPhoneNumber }),  //no need to send the number in body
            }
            )
            
                .then((response) => {
                    if (response.status >= 200 && response.status < 300) {
                        localStorage.setItem('userPhoneNumber', stringWithoutSpaces);


                        // Request was successful
                        //navigate to next page
                        console.log("ok");
                        navigate('/Verificationpage');

                        return response.json();



                    } else {

                        console.log("error", response.status);
                        window.location.reload();
                        // Handle errors here
                        //remain in the same page and show the error message
                        throw new Error('Failed to send phone number to the backend');
                        
                    }
                }
                )

                .then((data) => {                   
                    setData(data);
                    setLoader(false);
                    return <Link to='/Verificationpage' />
                   

                })
                .catch((error) => {
                    // Handle errors here
                    console.error(error);
                    if (error instanceof TypeError && error.message === 'Failed to fetch') {
                        console.error('Network error:', error);
                    } else {
                        console.error('Other error:', error);
                    }
                    window.location.reload();
                });


            

        } else {
           

            setcountryIsAvailable(false); //country code not available
            window.location.reload();
        }
    
}

       

useEffect(()=>
{
    const cookieName = 'token';
    if(Cookies.get(cookieName) !== undefined)
        {
            navigate('/Homepage');
        }
},[]);
    


    // const sendPhoneNumberToBackend = async () => {
    //     const apiUrl = `https://localhost:44311/api/services/app/OTP/SendOTP?userPhoneNumber=${urlEncodedPhoneNumber}`;
    //     if (stringWithoutSpaces.substring(0, 4) === "+977") {
    //         try {

    //             const response = await fetch(apiUrl, {
    //                 method: 'POST',
    //                 headers: {
    //                     'Content-Type': 'application/json',
    //                 },
    //                 body: JSON.stringify({ userPhoneNumber }),
    //             });

    //             if (response.ok) {
    //                 // Request was successful
    //                 console.log("ok");

    //             } else {
    //                 console.log("error", response.status);
    //                 window.alert('This is an alert message!');
    //                 throw new Error('Failed to send phone number to the backend');
    //             }

    //         } catch (error) {
    //             // Handle errors here
    //             console.error(error);
    //             if (error instanceof TypeError && error.message === 'Failed to fetch') {
    //                 console.error('Network error:', error);
    //             } else {
    //                 console.error('Other error:', error);
    //             }
    //         }
    //     } else {
    //         setcountryIsAvailable(false);
    //     }

    // };

    useEffect(() => {
        // Retrieve phone number from local storage on component mount
        const storedPhoneNumber = localStorage.getItem('userPhoneNumber');
        if (storedPhoneNumber) {
            setph(storedPhoneNumber);

        }
    }, []);


    



    // submit=async(e)=>{
    //     e.preventDefault()

    //     try{
    //         await axios.post("",{
    //             ph
    //         })

    //     }
    //     catch{
    //         console.log(e);

    //     }
    // }



    return (
        <section className='loginPage'>
            <div className='appComponents'>
                <div className='appLogo'>
                    <img src={Logo} alt="" id='logo' />
                </div>
                <div className='Features'>
                    <div className='FQA'>FAQ</div>
                    <div className='aboutUs'>About us</div>
                </div>

            </div>
            <div className='loginTitle'>
                Login into Your Account
            </div>
            <form >

                <div className='phone'>


                    <div className='phoneComponent'>
                        <PhoneInput containerClass='react-tel-input' 
                        country={"np"}  onlyCountries={['np']}
                        value={userPhoneNumber} countryCodeEditable={false}
                        onChange={handlePhoneChange} 
                        onFocus={handleInputFocus}
                        onBlur={handleInputBlur} limitMaxLength={true}
                        disabled={false} enableSearch={true}
                       />
                        </div>
                      </div>
              
                        { !isValid &&(
                        <div className="notAvailableMessage">
                        <p>Please enter a valid phone number.</p> 
                        </div>) 
                        }

                        {/* !countryisAvailable &&(
                            <div className="notAvailableMessage">
                            <p>Please enter a valid country code.</p> 
                            </div>) */
                        }

                           <div className='otpComponent'>
                            
                            {
                                (isInputFocused ?(
                                <>
                                
                                    <button className='sendOtp' onClick={sendPhoneNumberToBackend}> Send Otp</button>
                                
                                </>
                                ):
                                (<>{(isValid && isLoading )?<span><LoadingSpinner/></span>:
                                <button className='sendOtp'onClick={sendPhoneNumberToBackend}> Send Otp</button>
                                }
                                </>
                                ))
                                 
                            }           
                    </div>
            </form>

        </section>
    )
};            
export default Login;
