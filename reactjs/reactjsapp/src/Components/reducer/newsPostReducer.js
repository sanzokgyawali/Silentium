const newsPostReducer = (state, action) => {
    // if (action.type === "SET_LOADING"){
    //     return{
    //         ...state,
    //         isLoading:true,
    //     };
    // }
    // if(action.type === "API_ERROR"){
    //     return{
    //         ...state,
    //         isLoading:false,
    //         isError:true,
    //     };

    // }
    switch (action.type) {
        case "SET_LOADING":
            return {
                ...state,
                isLoading: true,
            };

        case "SET_API_DATA":
            //const successValue = action.payLoad.filter((curElem) => {
            //    return curElem.success === true;

            //});
            return {
                ...state,
                isLoading: false,
                result: action.payload.result, 
               /* successValue: successValue,*/
            };
        case "API_ERROR":
            return {
                ...state,
                isLoading: false,
                isError: true,
            };
        default:
            return state;
    }

};

export default newsPostReducer;