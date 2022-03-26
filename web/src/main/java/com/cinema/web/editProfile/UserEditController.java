package com.cinema.web.editProfile;

@RequestMapping(value = "/user/updateProc", method = RequestMethod.POST)
@ResponseBody
public Response<Object> updateProc(HttpServletRequest request,HttpServletResponse response)
        {
        Response<Object> ajaxResponse=new Response<Object>();

        String CookieUserId=CookieUtil.getHexValue(request,AUTH_COOKIE_NAME);

        String userPwd=HttpUtil.get(request,"password");
        String firstName=HttpUtil.get(request,"firstName");
        String lastName=HttpUtil.get(request,"lastName");
        String payment=HttpUtil.get(request,"cardNumber");

        if(!StringUtil.isEmpty(CookieUserId))
        {
        // if cookie user ID is not null
        User user=userService.userSelect(CookieUserId);

        if(user!=null){
        // if user information exist
        if(StringUtil.equals(user.getStatus(),"Y")){

        if(!StringUtil.isEmpty(userPwd)&&!StringUtil.isEmpty(firstName)&&!StringUtil.isEmpty(lastName)&&!StringUtil.isEmpty(cardNumber)){
        // user's first name, last name, password and payment card number cannot be empty
        user.setUserPwd(password);
        user.setUserFirstName(firstName);
        user.setUserLastName(lastName);
        user.setUserPayment(cardNumber);

        if(userService.userUpdate(user)>0){
        ajaxResponse.setResponse(0,"Success");
        }
        else{
        ajaxResponse.setResponse(500,"Internal Server Error");
        }
        }

        else{
        CookieUtil.deleteCookie(request,response,AUTH_COOKIE_NAME);
        ajaxResponse.setResponse(400,"Forbidden User");
        }
        }

        else{

        CookieUtil.deleteCookie(request,response,AUTH_COOKIE_NAME);
        ajaxResponse.setResponse(400,"Forbidden User");
        }
        }
        else
        {
        CookieUtil.deleteCookie(request,response,AUTH_COOKIE_NAME);
        ajaxResponse.setResponse(404,"Not Found");
        }

        }
        else
        {
        ajaxResponse.setResponse(400,"Bad Request");
        }

        return ajaxResponse;
        }