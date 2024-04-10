import React , {useEffect}from 'react';
import Header from "./Header";
import Category from './Category';
import Notification from '../Notificationpage/Notification';
import Newsfeed from './Newsfeed';
//import {useHistory, redirect} from 'react-router-dom';
import './Homepage.css';








const Homepage = () => {
   
//const history = useHistory();
    /*const token = Cookies.get('token');*/    //get the token from the cookie

    //if (token) {                             //if token is available then only make the request and send the token in the header
    //    const headers = {
    //        Authorization: `Bearer ${token}`,
    //        'Content-Type': 'application/json', 
    //    };


    //const apiUrl = `https://localhost:44311/api/services/app/AppPost/GetRandomPosts`;   //correct the url


    //fetch(apiUrl, {
    //    method: 'GET',
    //    /*   headers:headers,*/
    //    headers: {
    //        'Content-Type': 'application/json',
    //    },
    //})
    //    .then((response) => {
    //        if (response.ok) {
    //            // Request was successful
    //            return response.json();
    //        } else {
    //            // Handle errors here
    //            throw new Error('Failed to load posts');
    //        }
    //    })
    //    .then((data) => {

    //        //here data is the list of posts
    //    });
        

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



  return <>
  <Header/>
  { <redirect to="/Homepage" />}
      
    
  <div className='wrap_Page_Component'>
  <Category/>
          <Newsfeed />
        

  <Notification/>
  </div>
  </>
}

export default Homepage
