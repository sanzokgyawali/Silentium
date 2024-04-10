import axios, { Axios } from "axios";
import React, { useContext, useEffect, useReducer } from "react";
import { createContext } from "react";
import reducer from '../reducer/newsPostReducer';

const AppContext = React.createContext();

const API = `https://localhost:44311/api/services/app/AppPost/GetRandomPosts`;

const initialState = {
    isLoading: false,
    isError: false,
    result: [],
    /*successValue: [],*/
};
const AppProvider = ({ children }) => {

    const [state, dispatch] = useReducer(reducer, initialState);

    //const getNews = async (url) => {
    //    dispatch({ type: "SET_LOADING" });
    //    try {
    //        const resp = await axios.get(url);
    //        const data = await resp.json();
    //        console.log(data);
    //        dispatch({
    //            type: "SET_API_DATA",
    //            payLoad: {
    //                result: data.result,
    //            }
    //        });
    //    } catch (error) {
    //        dispatch({ type: "API_ERROR" });
    //    }

    //};
    const getNews = async (url) => {
        dispatch({ type: "SET_LOADING" });
        try {
            const resp = await fetch(url);
            const result = await resp.json();
            console.log("API Response:", result);
            dispatch({ type: "SET_API_DATA", payload: { result: result.result, } });
        } catch (error) {
            console.error("API Error:", error);
            dispatch({ type: "API_ERROR" });
        }
    };

    //const getNews = async (url) => {
    //    dispatch({ type: "SET_LOADING" });
    //    try {
    //        const resp = await axios.get(url);
    //        console.log("API Response:", resp);
    //        const result = resp.data;
    //        dispatch({ type: "SET_API_DATA", payload: result });
    //    } catch (error) {
    //        console.error("API Error:", error);
    //        dispatch({ type: "API_ERROR" });
    //    }
    //};
    useEffect(() => {
        getNews(API);

    }, []);
    return <AppContext.Provider value={{ ...state }}>
        {children}
    </AppContext.Provider>

};

//custom hooks

const useGlobalContext = () => {
    return useContext(AppContext);
}

export { AppProvider, AppContext, useGlobalContext };